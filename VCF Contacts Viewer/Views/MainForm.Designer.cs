namespace VCF_Contacts_Viewer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnOpen = new Button();
            lblInfo = new Label();
            btnView = new Button();
            txtOutput = new TextBox();
            btnExit = new Button();
            SuspendLayout();
            // 
            // btnOpen
            // 
            btnOpen.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOpen.BackColor = Color.DodgerBlue;
            btnOpen.Cursor = Cursors.Hand;
            btnOpen.FlatAppearance.BorderSize = 0;
            btnOpen.FlatStyle = FlatStyle.Flat;
            btnOpen.ForeColor = Color.Black;
            btnOpen.Location = new Point(568, 12);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(130, 35);
            btnOpen.TabIndex = 1;
            btnOpen.Text = "Open File";
            btnOpen.UseVisualStyleBackColor = false;
            btnOpen.Click += BtnOpen_Click;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 10F);
            lblInfo.Location = new Point(12, 17);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(40, 46);
            lblInfo.TabIndex = 1;
            lblInfo.Text = "File\r\nInfo";
            // 
            // btnView
            // 
            btnView.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnView.BackColor = Color.DodgerBlue;
            btnView.Cursor = Cursors.Hand;
            btnView.FlatAppearance.BorderSize = 0;
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.ForeColor = Color.Black;
            btnView.Location = new Point(704, 12);
            btnView.Name = "btnView";
            btnView.Size = new Size(130, 35);
            btnView.TabIndex = 2;
            btnView.Text = "View VCF";
            btnView.UseVisualStyleBackColor = false;
            btnView.Click += BtnView_Click;
            // 
            // txtOutput
            // 
            txtOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtOutput.Font = new Font("Consolas", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOutput.Location = new Point(12, 66);
            txtOutput.Multiline = true;
            txtOutput.Name = "txtOutput";
            txtOutput.ReadOnly = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Size = new Size(958, 445);
            txtOutput.TabIndex = 3;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.BackColor = Color.Red;
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.ForeColor = Color.Black;
            btnExit.Location = new Point(840, 12);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(130, 35);
            btnExit.TabIndex = 4;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += BtnExit_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(982, 523);
            Controls.Add(btnExit);
            Controls.Add(txtOutput);
            Controls.Add(btnView);
            Controls.Add(lblInfo);
            Controls.Add(btnOpen);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VCF Viewer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOpen;
        private Label lblInfo;
        private Button btnView;
        private TextBox txtOutput;
        private Button btnExit;
    }
}
