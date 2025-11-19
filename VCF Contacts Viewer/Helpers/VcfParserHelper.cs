namespace VCF_Contacts_Viewer.Helpers
{
    public static class VcfParserHelper
    {
        public static List<ContactViewModel> Parse(string filePath)
        {
            var contacts = new List<ContactViewModel>();

            string[] lines = File.ReadAllLines(filePath, Encoding.UTF8);

            string name = string.Empty;
            string phone = string.Empty;
            string email = string.Empty;
            string company = string.Empty;

            foreach (var line in lines)
            {
                if (line.StartsWith("BEGIN:VCARD"))
                {
                    name = phone = email = company = string.Empty;
                }
                else if (line.StartsWith("FN:"))
                {
                    name = line[3..];
                }
                else if (line.StartsWith("TEL"))
                {
                    var parts = line.Split(':');
                    if (parts.Length > 1)
                        phone = parts[1];
                }
                else if (line.StartsWith("EMAIL"))
                {
                    var parts = line.Split(':');
                    if (parts.Length > 1)
                        email = parts[1];
                }
                else if (line.StartsWith("ORG:"))
                {
                    company = line[4..].TrimEnd(';');
                }
                else if (line.StartsWith("END:VCARD"))
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

        public static string GetFirstName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return string.Empty;

            var parts = fullName.Trim().Split(' ');
            return parts.Length > 0 ? parts[0] : fullName;
        }

    }
}
