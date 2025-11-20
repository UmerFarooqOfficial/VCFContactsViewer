namespace VCF_Contacts_Viewer
{
    public partial class MainForm : Form
    {
        private string _selectedFilePath = string.Empty;
        private List<ContactViewModel> _contacts = [];

        public MainForm()
        {
            InitializeComponent();
            txtOutput.ReadOnly = true;
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new();
            ofd.Filter = "VCF Files (*.vcf)|*.vcf";
            ofd.Title = "Select a VCF File";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _selectedFilePath = ofd.FileName;

                FileInfo info = new(_selectedFilePath);

                lblInfo.Text =
                    $"File: {info.Name}\n" +
                    $"Size: {info.Length / 1024.0:F2} KB";

                txtOutput.Clear();

                toolStripLblStatus.Text = "File opened";
            }
        }

        private void BtnView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_selectedFilePath))
            {
                MessageBox.Show("Please select a VCF file first.",
                    "No File Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            _contacts = [.. VcfParserHelper.Parse(_selectedFilePath).OrderBy(c => VcfParserHelper.GetFirstName(c.FullName))];

            StringBuilder sb = new();

            foreach (var c in _contacts)
            {
                sb.AppendLine("Contact:");
                sb.AppendLine($"  Name   : {c.FullName}");
                sb.AppendLine($"  Phone  : {c.Phone}");
                sb.AppendLine($"  Email  : {c.Email}");
                sb.AppendLine($"  Company: {c.Company}");
                sb.AppendLine(new string('-', 40));
            }

            txtOutput.Text = sb.ToString();

            toolStripLblStatus.Text = $"File scanned successfully {_contacts.Count} contact(s) found";
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
            return;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            toolStripStatusLblVersion.Text = $"V {Application.ProductVersion}";
            
            int year = DateTime.Now.Year;
            toolStripStatusLblCopyright.Text = $"Umer Farooq © 2025 - {year}";
        }
    }
}
