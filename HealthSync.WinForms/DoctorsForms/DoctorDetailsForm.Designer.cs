namespace HealthSync.WinForms.DoctorsForms;

partial class DoctorDetailsForm
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
        DoctorPhoneNumberValue = new TextBox();
        DoctorEmailValue = new TextBox();
        DoctorNameValue = new TextBox();
        DoctorLicenseNumberLabel = new Label();
        DoctorSpecializationLabel = new Label();
        DoctorEmailLabel = new Label();
        DoctorPhoneNumberLabel = new Label();
        DoctorNameLabel = new Label();
        DoctorDetailsTitle = new Label();
        DoctorSpecializationValue = new TextBox();
        DoctorLicenseNumberValue = new TextBox();
        EditDoctorButton = new Button();
        SaveDoctorButton = new Button();
        SuspendLayout();
        // 
        // DoctorPhoneNumberValue
        // 
        DoctorPhoneNumberValue.Anchor = AnchorStyles.None;
        DoctorPhoneNumberValue.BorderStyle = BorderStyle.FixedSingle;
        DoctorPhoneNumberValue.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        DoctorPhoneNumberValue.Location = new Point(904, 431);
        DoctorPhoneNumberValue.Name = "DoctorPhoneNumberValue";
        DoctorPhoneNumberValue.ReadOnly = true;
        DoctorPhoneNumberValue.Size = new Size(357, 30);
        DoctorPhoneNumberValue.TabIndex = 30;
        // 
        // DoctorEmailValue
        // 
        DoctorEmailValue.Anchor = AnchorStyles.None;
        DoctorEmailValue.BorderStyle = BorderStyle.FixedSingle;
        DoctorEmailValue.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        DoctorEmailValue.Location = new Point(827, 277);
        DoctorEmailValue.Name = "DoctorEmailValue";
        DoctorEmailValue.ReadOnly = true;
        DoctorEmailValue.Size = new Size(357, 30);
        DoctorEmailValue.TabIndex = 28;
        // 
        // DoctorNameValue
        // 
        DoctorNameValue.Anchor = AnchorStyles.None;
        DoctorNameValue.BorderStyle = BorderStyle.FixedSingle;
        DoctorNameValue.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        DoctorNameValue.Location = new Point(816, 201);
        DoctorNameValue.Name = "DoctorNameValue";
        DoctorNameValue.ReadOnly = true;
        DoctorNameValue.Size = new Size(357, 30);
        DoctorNameValue.TabIndex = 27;
        // 
        // DoctorLicenseNumberLabel
        // 
        DoctorLicenseNumberLabel.Anchor = AnchorStyles.None;
        DoctorLicenseNumberLabel.AutoSize = true;
        DoctorLicenseNumberLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        DoctorLicenseNumberLabel.Location = new Point(743, 505);
        DoctorLicenseNumberLabel.Name = "DoctorLicenseNumberLabel";
        DoctorLicenseNumberLabel.Size = new Size(177, 25);
        DoctorLicenseNumberLabel.TabIndex = 26;
        DoctorLicenseNumberLabel.Text = "License Number:";
        // 
        // DoctorSpecializationLabel
        // 
        DoctorSpecializationLabel.Anchor = AnchorStyles.None;
        DoctorSpecializationLabel.AutoSize = true;
        DoctorSpecializationLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        DoctorSpecializationLabel.Location = new Point(743, 353);
        DoctorSpecializationLabel.Name = "DoctorSpecializationLabel";
        DoctorSpecializationLabel.Size = new Size(177, 25);
        DoctorSpecializationLabel.TabIndex = 25;
        DoctorSpecializationLabel.Text = "Specialization:";
        // 
        // DoctorEmailLabel
        // 
        DoctorEmailLabel.Anchor = AnchorStyles.None;
        DoctorEmailLabel.AutoSize = true;
        DoctorEmailLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        DoctorEmailLabel.Location = new Point(743, 277);
        DoctorEmailLabel.Name = "DoctorEmailLabel";
        DoctorEmailLabel.Size = new Size(78, 25);
        DoctorEmailLabel.TabIndex = 24;
        DoctorEmailLabel.Text = "Email:";
        // 
        // DoctorPhoneNumberLabel
        // 
        DoctorPhoneNumberLabel.Anchor = AnchorStyles.None;
        DoctorPhoneNumberLabel.AutoSize = true;
        DoctorPhoneNumberLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        DoctorPhoneNumberLabel.Location = new Point(743, 431);
        DoctorPhoneNumberLabel.Name = "DoctorPhoneNumberLabel";
        DoctorPhoneNumberLabel.Size = new Size(155, 25);
        DoctorPhoneNumberLabel.TabIndex = 23;
        DoctorPhoneNumberLabel.Text = "Phone Number:";
        // 
        // DoctorNameLabel
        // 
        DoctorNameLabel.Anchor = AnchorStyles.None;
        DoctorNameLabel.AutoSize = true;
        DoctorNameLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        DoctorNameLabel.Location = new Point(743, 203);
        DoctorNameLabel.Name = "DoctorNameLabel";
        DoctorNameLabel.Size = new Size(67, 25);
        DoctorNameLabel.TabIndex = 22;
        DoctorNameLabel.Text = "Name:";
        // 
        // DoctorDetailsTitle
        // 
        DoctorDetailsTitle.Anchor = AnchorStyles.Top;
        DoctorDetailsTitle.AutoSize = true;
        DoctorDetailsTitle.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        DoctorDetailsTitle.Location = new Point(808, 129);
        DoctorDetailsTitle.Name = "DoctorDetailsTitle";
        DoctorDetailsTitle.Size = new Size(210, 32);
        DoctorDetailsTitle.TabIndex = 21;
        DoctorDetailsTitle.Text = "Doctor Details";
        DoctorDetailsTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // DoctorSpecializationValue
        // 
        DoctorSpecializationValue.Anchor = AnchorStyles.None;
        DoctorSpecializationValue.BorderStyle = BorderStyle.FixedSingle;
        DoctorSpecializationValue.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        DoctorSpecializationValue.Location = new Point(926, 351);
        DoctorSpecializationValue.Name = "DoctorSpecializationValue";
        DoctorSpecializationValue.ReadOnly = true;
        DoctorSpecializationValue.Size = new Size(357, 30);
        DoctorSpecializationValue.TabIndex = 32;
        // 
        // DoctorLicenseNumberValue
        // 
        DoctorLicenseNumberValue.Anchor = AnchorStyles.None;
        DoctorLicenseNumberValue.BorderStyle = BorderStyle.FixedSingle;
        DoctorLicenseNumberValue.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        DoctorLicenseNumberValue.Location = new Point(926, 505);
        DoctorLicenseNumberValue.Name = "DoctorLicenseNumberValue";
        DoctorLicenseNumberValue.ReadOnly = true;
        DoctorLicenseNumberValue.Size = new Size(357, 30);
        DoctorLicenseNumberValue.TabIndex = 33;
        // 
        // EditDoctorButton
        // 
        EditDoctorButton.BackColor = Color.CornflowerBlue;
        EditDoctorButton.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 255);
        EditDoctorButton.FlatAppearance.BorderSize = 0;
        EditDoctorButton.FlatStyle = FlatStyle.Flat;
        EditDoctorButton.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        EditDoctorButton.ForeColor = SystemColors.Control;
        EditDoctorButton.Location = new Point(904, 598);
        EditDoctorButton.Name = "EditDoctorButton";
        EditDoctorButton.Size = new Size(150, 37);
        EditDoctorButton.TabIndex = 34;
        EditDoctorButton.Text = "Edit Doctor";
        EditDoctorButton.UseVisualStyleBackColor = false;
        EditDoctorButton.Click += EditDoctorButton_Click;
        // 
        // SaveDoctorButton
        // 
        SaveDoctorButton.BackColor = Color.CornflowerBlue;
        SaveDoctorButton.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 255);
        SaveDoctorButton.FlatAppearance.BorderSize = 0;
        SaveDoctorButton.FlatStyle = FlatStyle.Flat;
        SaveDoctorButton.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        SaveDoctorButton.ForeColor = SystemColors.Control;
        SaveDoctorButton.Location = new Point(904, 664);
        SaveDoctorButton.Name = "SaveDoctorButton";
        SaveDoctorButton.Size = new Size(150, 37);
        SaveDoctorButton.TabIndex = 35;
        SaveDoctorButton.Text = "Save Changes";
        SaveDoctorButton.UseVisualStyleBackColor = false;
        SaveDoctorButton.Click += SaveDoctorButton_Click;
        // 
        // DoctorDetailsForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1904, 1041);
        Controls.Add(SaveDoctorButton);
        Controls.Add(EditDoctorButton);
        Controls.Add(DoctorLicenseNumberValue);
        Controls.Add(DoctorSpecializationValue);
        Controls.Add(DoctorPhoneNumberValue);
        Controls.Add(DoctorEmailValue);
        Controls.Add(DoctorNameValue);
        Controls.Add(DoctorLicenseNumberLabel);
        Controls.Add(DoctorSpecializationLabel);
        Controls.Add(DoctorEmailLabel);
        Controls.Add(DoctorPhoneNumberLabel);
        Controls.Add(DoctorNameLabel);
        Controls.Add(DoctorDetailsTitle);
        Name = "DoctorDetailsForm";
        Text = "Doctor Details";
        Load += DoctorDetailsForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private TextBox DoctorPhoneNumberValue;
    private TextBox DoctorEmailValue;
    private TextBox DoctorNameValue;
    private Label DoctorLicenseNumberLabel;
    private Label DoctorSpecializationLabel;
    private Label DoctorEmailLabel;
    private Label DoctorPhoneNumberLabel;
    private Label DoctorNameLabel;
    private Label DoctorDetailsTitle;
    private TextBox DoctorSpecializationValue;
    private TextBox DoctorLicenseNumberValue;
    private Button EditDoctorButton;
    private Button SaveDoctorButton;
}