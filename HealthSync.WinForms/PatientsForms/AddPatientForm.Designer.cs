namespace HealthSync.WinForms.PatientsForms;

partial class AddPatientForm
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
        CreatePatientTitle = new Label();
        PatientName = new TextBox();
        PatientPhoneNumber = new TextBox();
        PatientEmail = new TextBox();
        PatientAddress = new RichTextBox();
        PatientDateOfBirth = new DateTimePicker();
        AddPatientButton = new Button();
        SuspendLayout();
        // 
        // CreatePatientTitle
        // 
        CreatePatientTitle.AutoSize = true;
        CreatePatientTitle.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        CreatePatientTitle.Location = new Point(778, 76);
        CreatePatientTitle.Name = "CreatePatientTitle";
        CreatePatientTitle.Size = new Size(210, 32);
        CreatePatientTitle.TabIndex = 3;
        CreatePatientTitle.Text = "Create Patient";
        CreatePatientTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // PatientName
        // 
        PatientName.BackColor = Color.WhiteSmoke;
        PatientName.BorderStyle = BorderStyle.FixedSingle;
        PatientName.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        PatientName.Location = new Point(675, 169);
        PatientName.Name = "PatientName";
        PatientName.Size = new Size(419, 26);
        PatientName.TabIndex = 4;
        PatientName.Text = "Name...";
        // 
        // PatientPhoneNumber
        // 
        PatientPhoneNumber.BackColor = Color.WhiteSmoke;
        PatientPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
        PatientPhoneNumber.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        PatientPhoneNumber.Location = new Point(675, 324);
        PatientPhoneNumber.Name = "PatientPhoneNumber";
        PatientPhoneNumber.Size = new Size(419, 26);
        PatientPhoneNumber.TabIndex = 5;
        PatientPhoneNumber.Text = "Phone Number...";
        // 
        // PatientEmail
        // 
        PatientEmail.BackColor = Color.WhiteSmoke;
        PatientEmail.BorderStyle = BorderStyle.FixedSingle;
        PatientEmail.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        PatientEmail.Location = new Point(675, 405);
        PatientEmail.Name = "PatientEmail";
        PatientEmail.Size = new Size(419, 26);
        PatientEmail.TabIndex = 6;
        PatientEmail.Text = "Email...";
        // 
        // PatientAddress
        // 
        PatientAddress.BackColor = Color.WhiteSmoke;
        PatientAddress.BorderStyle = BorderStyle.FixedSingle;
        PatientAddress.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        PatientAddress.Location = new Point(675, 490);
        PatientAddress.Name = "PatientAddress";
        PatientAddress.Size = new Size(419, 118);
        PatientAddress.TabIndex = 7;
        PatientAddress.Text = "Address...";
        // 
        // PatientDateOfBirth
        // 
        PatientDateOfBirth.CalendarMonthBackground = Color.WhiteSmoke;
        PatientDateOfBirth.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        PatientDateOfBirth.Location = new Point(675, 244);
        PatientDateOfBirth.MaxDate = new DateTime(2025, 3, 15, 0, 0, 0, 0);
        PatientDateOfBirth.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
        PatientDateOfBirth.Name = "PatientDateOfBirth";
        PatientDateOfBirth.Size = new Size(419, 26);
        PatientDateOfBirth.TabIndex = 8;
        PatientDateOfBirth.Value = new DateTime(2025, 3, 15, 0, 0, 0, 0);
        // 
        // AddPatientButton
        // 
        AddPatientButton.BackColor = Color.CornflowerBlue;
        AddPatientButton.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 255);
        AddPatientButton.FlatAppearance.BorderSize = 0;
        AddPatientButton.FlatStyle = FlatStyle.Flat;
        AddPatientButton.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        AddPatientButton.ForeColor = SystemColors.Control;
        AddPatientButton.Location = new Point(810, 670);
        AddPatientButton.Name = "AddPatientButton";
        AddPatientButton.Size = new Size(120, 37);
        AddPatientButton.TabIndex = 9;
        AddPatientButton.Text = "Add Patient";
        AddPatientButton.UseVisualStyleBackColor = false;
        AddPatientButton.Click += AddPatientButton_Click;
        // 
        // AddPatientForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1904, 1041);
        Controls.Add(AddPatientButton);
        Controls.Add(PatientDateOfBirth);
        Controls.Add(PatientAddress);
        Controls.Add(PatientEmail);
        Controls.Add(PatientPhoneNumber);
        Controls.Add(PatientName);
        Controls.Add(CreatePatientTitle);
        Name = "AddPatientForm";
        Text = "Add Patient";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label CreatePatientTitle;
    private TextBox PatientName;
    private TextBox PatientPhoneNumber;
    private TextBox PatientEmail;
    private RichTextBox PatientAddress;
    private DateTimePicker PatientDateOfBirth;
    private Button AddPatientButton;
}