namespace HealthSync.WinForms.DoctorsForms;

partial class AddDoctorForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        AddDoctorButton = new Button();
        DoctorEmail = new TextBox();
        DoctorPhoneNumber = new TextBox();
        DoctorName = new TextBox();
        CreateDoctorTitle = new Label();
        DoctorSpecialization = new TextBox();
        DoctorLicenseNumber = new TextBox();
        SuspendLayout();
        // 
        // AddDoctorButton
        // 
        AddDoctorButton.BackColor = Color.CornflowerBlue;
        AddDoctorButton.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 255);
        AddDoctorButton.FlatAppearance.BorderSize = 0;
        AddDoctorButton.FlatStyle = FlatStyle.Flat;
        AddDoctorButton.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        AddDoctorButton.ForeColor = SystemColors.Control;
        AddDoctorButton.Location = new Point(810, 586);
        AddDoctorButton.Name = "AddDoctorButton";
        AddDoctorButton.Size = new Size(120, 37);
        AddDoctorButton.TabIndex = 16;
        AddDoctorButton.Text = "Add Doctor";
        AddDoctorButton.UseVisualStyleBackColor = false;
        AddDoctorButton.Click += AddDoctorButton_Click;
        // 
        // DoctorEmail
        // 
        DoctorEmail.BackColor = Color.WhiteSmoke;
        DoctorEmail.BorderStyle = BorderStyle.FixedSingle;
        DoctorEmail.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        DoctorEmail.Location = new Point(675, 405);
        DoctorEmail.Name = "DoctorEmail";
        DoctorEmail.Size = new Size(419, 26);
        DoctorEmail.TabIndex = 13;
        DoctorEmail.Text = "Email...";
        // 
        // DoctorPhoneNumber
        // 
        DoctorPhoneNumber.BackColor = Color.WhiteSmoke;
        DoctorPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
        DoctorPhoneNumber.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        DoctorPhoneNumber.Location = new Point(675, 324);
        DoctorPhoneNumber.Name = "DoctorPhoneNumber";
        DoctorPhoneNumber.Size = new Size(419, 26);
        DoctorPhoneNumber.TabIndex = 12;
        DoctorPhoneNumber.Text = "Phone Number...";
        // 
        // DoctorName
        // 
        DoctorName.BackColor = Color.WhiteSmoke;
        DoctorName.BorderStyle = BorderStyle.FixedSingle;
        DoctorName.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        DoctorName.Location = new Point(675, 169);
        DoctorName.Name = "DoctorName";
        DoctorName.Size = new Size(419, 26);
        DoctorName.TabIndex = 11;
        DoctorName.Text = "Name...";
        // 
        // CreateDoctorTitle
        // 
        CreateDoctorTitle.AutoSize = true;
        CreateDoctorTitle.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        CreateDoctorTitle.Location = new Point(769, 77);
        CreateDoctorTitle.Name = "CreateDoctorTitle";
        CreateDoctorTitle.Size = new Size(196, 32);
        CreateDoctorTitle.TabIndex = 10;
        CreateDoctorTitle.Text = "Create Doctor";
        CreateDoctorTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // DoctorSpecialization
        // 
        DoctorSpecialization.BackColor = Color.WhiteSmoke;
        DoctorSpecialization.BorderStyle = BorderStyle.FixedSingle;
        DoctorSpecialization.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        DoctorSpecialization.Location = new Point(675, 244);
        DoctorSpecialization.Name = "DoctorSpecialization";
        DoctorSpecialization.Size = new Size(419, 26);
        DoctorSpecialization.TabIndex = 17;
        DoctorSpecialization.Text = "Specialization...";
        // 
        // DoctorLicenseNumber
        // 
        DoctorLicenseNumber.BackColor = Color.WhiteSmoke;
        DoctorLicenseNumber.BorderStyle = BorderStyle.FixedSingle;
        DoctorLicenseNumber.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        DoctorLicenseNumber.Location = new Point(675, 490);
        DoctorLicenseNumber.Name = "DoctorLicenseNumber";
        DoctorLicenseNumber.Size = new Size(419, 26);
        DoctorLicenseNumber.TabIndex = 18;
        DoctorLicenseNumber.Text = "License Number...";
        // 
        // AddDoctorForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1904, 1041);
        Controls.Add(DoctorLicenseNumber);
        Controls.Add(DoctorSpecialization);
        Controls.Add(AddDoctorButton);
        Controls.Add(DoctorEmail);
        Controls.Add(DoctorPhoneNumber);
        Controls.Add(DoctorName);
        Controls.Add(CreateDoctorTitle);
        Name = "AddDoctorForm";
        Text = "Add Doctor";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button AddDoctorButton;
    private TextBox DoctorEmail;
    private TextBox DoctorPhoneNumber;
    private TextBox DoctorName;
    private Label CreateDoctorTitle;
    private TextBox DoctorSpecialization;
    private TextBox DoctorLicenseNumber;
}