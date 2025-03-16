namespace HealthSync.WinForms.PatientsForms;

partial class PatientDetailsForm
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
        PatientDetailsTitle = new Label();
        PatientNameLabel = new Label();
        PatientPhoneNumberLabel = new Label();
        PatientEmailLabel = new Label();
        PatientDateOfBirthLabel = new Label();
        PatientAddressLabel = new Label();
        PatientNameValue = new TextBox();
        PatientEmailValue = new TextBox();
        PatientDateOfBirthValue = new DateTimePicker();
        PatientPhoneNumberValue = new TextBox();
        PatientAddressValue = new RichTextBox();
        SuspendLayout();
        // 
        // PatientDetailsTitle
        // 
        PatientDetailsTitle.Anchor = AnchorStyles.Top;
        PatientDetailsTitle.AutoSize = true;
        PatientDetailsTitle.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        PatientDetailsTitle.Location = new Point(780, 135);
        PatientDetailsTitle.Name = "PatientDetailsTitle";
        PatientDetailsTitle.Size = new Size(224, 32);
        PatientDetailsTitle.TabIndex = 5;
        PatientDetailsTitle.Text = "Patient Details";
        PatientDetailsTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // PatientNameLabel
        // 
        PatientNameLabel.Anchor = AnchorStyles.None;
        PatientNameLabel.AutoSize = true;
        PatientNameLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        PatientNameLabel.Location = new Point(674, 215);
        PatientNameLabel.Name = "PatientNameLabel";
        PatientNameLabel.Size = new Size(67, 25);
        PatientNameLabel.TabIndex = 7;
        PatientNameLabel.Text = "Name:";
        // 
        // PatientPhoneNumberLabel
        // 
        PatientPhoneNumberLabel.Anchor = AnchorStyles.None;
        PatientPhoneNumberLabel.AutoSize = true;
        PatientPhoneNumberLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        PatientPhoneNumberLabel.Location = new Point(674, 424);
        PatientPhoneNumberLabel.Name = "PatientPhoneNumberLabel";
        PatientPhoneNumberLabel.Size = new Size(155, 25);
        PatientPhoneNumberLabel.TabIndex = 9;
        PatientPhoneNumberLabel.Text = "Phone Number:";
        // 
        // PatientEmailLabel
        // 
        PatientEmailLabel.Anchor = AnchorStyles.None;
        PatientEmailLabel.AutoSize = true;
        PatientEmailLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        PatientEmailLabel.Location = new Point(674, 284);
        PatientEmailLabel.Name = "PatientEmailLabel";
        PatientEmailLabel.Size = new Size(78, 25);
        PatientEmailLabel.TabIndex = 11;
        PatientEmailLabel.Text = "Email:";
        // 
        // PatientDateOfBirthLabel
        // 
        PatientDateOfBirthLabel.Anchor = AnchorStyles.None;
        PatientDateOfBirthLabel.AutoSize = true;
        PatientDateOfBirthLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        PatientDateOfBirthLabel.Location = new Point(674, 357);
        PatientDateOfBirthLabel.Name = "PatientDateOfBirthLabel";
        PatientDateOfBirthLabel.Size = new Size(166, 25);
        PatientDateOfBirthLabel.TabIndex = 13;
        PatientDateOfBirthLabel.Text = "Date of birth:";
        // 
        // PatientAddressLabel
        // 
        PatientAddressLabel.Anchor = AnchorStyles.None;
        PatientAddressLabel.AutoSize = true;
        PatientAddressLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        PatientAddressLabel.Location = new Point(674, 493);
        PatientAddressLabel.Name = "PatientAddressLabel";
        PatientAddressLabel.Size = new Size(100, 25);
        PatientAddressLabel.TabIndex = 15;
        PatientAddressLabel.Text = "Address:";
        // 
        // PatientNameValue
        // 
        PatientNameValue.Anchor = AnchorStyles.None;
        PatientNameValue.BorderStyle = BorderStyle.FixedSingle;
        PatientNameValue.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        PatientNameValue.Location = new Point(747, 212);
        PatientNameValue.Name = "PatientNameValue";
        PatientNameValue.ReadOnly = true;
        PatientNameValue.Size = new Size(357, 30);
        PatientNameValue.TabIndex = 16;
        // 
        // PatientEmailValue
        // 
        PatientEmailValue.Anchor = AnchorStyles.None;
        PatientEmailValue.BorderStyle = BorderStyle.FixedSingle;
        PatientEmailValue.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        PatientEmailValue.Location = new Point(758, 279);
        PatientEmailValue.Name = "PatientEmailValue";
        PatientEmailValue.ReadOnly = true;
        PatientEmailValue.Size = new Size(346, 30);
        PatientEmailValue.TabIndex = 17;
        // 
        // PatientDateOfBirthValue
        // 
        PatientDateOfBirthValue.Anchor = AnchorStyles.None;
        PatientDateOfBirthValue.Enabled = false;
        PatientDateOfBirthValue.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        PatientDateOfBirthValue.Location = new Point(846, 357);
        PatientDateOfBirthValue.Name = "PatientDateOfBirthValue";
        PatientDateOfBirthValue.Size = new Size(269, 26);
        PatientDateOfBirthValue.TabIndex = 18;
        // 
        // PatientPhoneNumberValue
        // 
        PatientPhoneNumberValue.Anchor = AnchorStyles.None;
        PatientPhoneNumberValue.BorderStyle = BorderStyle.FixedSingle;
        PatientPhoneNumberValue.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        PatientPhoneNumberValue.Location = new Point(835, 424);
        PatientPhoneNumberValue.Name = "PatientPhoneNumberValue";
        PatientPhoneNumberValue.ReadOnly = true;
        PatientPhoneNumberValue.Size = new Size(280, 30);
        PatientPhoneNumberValue.TabIndex = 19;
        // 
        // PatientAddressValue
        // 
        PatientAddressValue.Anchor = AnchorStyles.None;
        PatientAddressValue.BorderStyle = BorderStyle.FixedSingle;
        PatientAddressValue.Location = new Point(780, 495);
        PatientAddressValue.Name = "PatientAddressValue";
        PatientAddressValue.ReadOnly = true;
        PatientAddressValue.Size = new Size(441, 80);
        PatientAddressValue.TabIndex = 20;
        PatientAddressValue.Text = "";
        // 
        // PatientDetailsForm
        // 
        AutoScaleDimensions = new SizeF(9F, 21F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1904, 1041);
        Controls.Add(PatientAddressValue);
        Controls.Add(PatientPhoneNumberValue);
        Controls.Add(PatientDateOfBirthValue);
        Controls.Add(PatientEmailValue);
        Controls.Add(PatientNameValue);
        Controls.Add(PatientAddressLabel);
        Controls.Add(PatientDateOfBirthLabel);
        Controls.Add(PatientEmailLabel);
        Controls.Add(PatientPhoneNumberLabel);
        Controls.Add(PatientNameLabel);
        Controls.Add(PatientDetailsTitle);
        Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        Margin = new Padding(4);
        Name = "PatientDetailsForm";
        Text = "Patient Details";
        Load += PatientDetailsForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label PatientDetailsTitle;
    private Label PatientNameLabel;
    private Label PatientPhoneNumberLabel;
    private Label PatientEmailLabel;
    private Label PatientDateOfBirthLabel;
    private Label PatientAddressLabel;
    private TextBox PatientNameValue;
    private TextBox PatientEmailValue;
    private DateTimePicker PatientDateOfBirthValue;
    private TextBox PatientPhoneNumberValue;
    private RichTextBox PatientAddressValue;
}