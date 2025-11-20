namespace VCF_Contacts_Viewer.Helpers
{
    /// <summary>
    /// Provides functionality for parsing VCF (vCard) files into strongly typed contact models.
    /// This class is resilient against malformed lines, missing fields, and unexpected formatting.
    /// </summary>
    public static class VcfParserHelper
    {
        /// <summary>
        /// Parses a VCF (.vcf) file and extracts contact information into a list of <see cref="ContactViewModel"/>.
        /// </summary>
        /// <param name="filePath">The full path of the VCF file to parse.</param>
        /// <returns>A list of parsed contact records.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="filePath"/> is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Thrown when the file does not exist.</exception>
        /// <exception cref="IOException">Thrown when the file cannot be read.</exception>
        /// <exception cref="InvalidDataException">Thrown when the file contains unsupported or invalid VCF formatting.</exception>
        public static List<ContactViewModel> Parse(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentNullException(nameof(filePath), "File path cannot be null or empty.");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("VCF file not found.", filePath);

            var contacts = new List<ContactViewModel>();

            try
            {
                // ReadLines does not lock the file and reads lazily line by line
                IEnumerable<string> lines = File.ReadLines(filePath, Encoding.UTF8);

                string name = string.Empty;
                string phone = string.Empty;
                string email = string.Empty;
                string company = string.Empty;

                foreach (var rawLine in lines)
                {
                    if (rawLine == null)
                        continue;

                    string line = rawLine.Trim();
                    if (line.Length == 0)
                        continue;

                    if (line.StartsWith("BEGIN:VCARD", StringComparison.OrdinalIgnoreCase))
                    {
                        name = phone = email = company = string.Empty;
                    }
                    else if (line.StartsWith("FN:", StringComparison.OrdinalIgnoreCase))
                    {
                        name = SafeExtract(line, 3);
                    }
                    else if (line.StartsWith("TEL", StringComparison.OrdinalIgnoreCase))
                    {
                        phone = SafeSplitAfterColon(line);
                    }
                    else if (line.StartsWith("EMAIL", StringComparison.OrdinalIgnoreCase))
                    {
                        email = SafeSplitAfterColon(line);
                    }
                    else if (line.StartsWith("ORG:", StringComparison.OrdinalIgnoreCase))
                    {
                        company = SafeExtract(line, 4).TrimEnd(';');
                    }
                    else if (line.StartsWith("END:VCARD", StringComparison.OrdinalIgnoreCase))
                    {
                        contacts.Add(new ContactViewModel
                        {
                            FullName = name,
                            Phone = phone,
                            Email = email,
                            Company = company
                        });
                    }
                }

                return contacts;
            }
            catch (DecoderFallbackException ex)
            {
                throw new InvalidDataException("The VCF file contains invalid or unsupported encoding.", ex);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Extracts the substring from the provided start index safely.
        /// </summary>
        private static string SafeExtract(string line, int startIndex)
        {
            if (string.IsNullOrEmpty(line) || line.Length <= startIndex)
                return string.Empty;

            return line[startIndex..].Trim();
        }

        /// <summary>
        /// Splits a VCF line on ':' and returns the right-hand value safely.
        /// </summary>
        private static string SafeSplitAfterColon(string line)
        {
            if (string.IsNullOrEmpty(line))
                return string.Empty;

            int colonIndex = line.IndexOf(':');
            if (colonIndex < 0 || colonIndex == line.Length - 1)
                return string.Empty;

            return line[(colonIndex + 1)..].Trim();
        }

        /// <summary>
        /// Safely extracts the first name from a full name string.
        /// </summary>
        /// <param name="fullName">The full name to process.</param>
        /// <returns>The detected first name, or empty when unavailable.</returns>
        public static string GetFirstName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return string.Empty;

            var parts = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return parts.Length > 0 ? parts[0] : string.Empty;
        }
    }
}
