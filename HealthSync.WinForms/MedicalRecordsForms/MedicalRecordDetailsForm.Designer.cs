namespace HealthSync.WinForms.MedicalRecordsForms;

partial class MedicalRecordDetailsForm
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
        MedRecordDateValue = new DateTimePicker();
        MedRecordDiagnosisValue = new TextBox();
        MedRecordPrescriptionLabel = new Label();
        MedRecordDateLabel = new Label();
        DoctorLabel = new Label();
        MedRecordDiagnosisLabel = new Label();
        PatientLabel = new Label();
        MedicalRecordDetailsTitle = new Label();
        MedRecordPrescriptionValue = new TextBox();
        SaveMedicalRecordButton = new Button();
        EditMedicalRecordButton = new Button();
        MedRecordPatientValue = new ComboBox();
        MedRecordDoctorValue = new ComboBox();
        SuspendLayout();
        // 
        // MedRecordDateValue
        // 
        MedRecordDateValue.Enabled = false;
        MedRecordDateValue.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        MedRecordDateValue.Location = new Point(963, 503);
        MedRecordDateValue.Name = "MedRecordDateValue";
        MedRecordDateValue.Size = new Size(352, 26);
        MedRecordDateValue.TabIndex = 56;
        // 
        // MedRecordDiagnosisValue
        // 
        MedRecordDiagnosisValue.Anchor = AnchorStyles.None;
        MedRecordDiagnosisValue.BorderStyle = BorderStyle.FixedSingle;
        MedRecordDiagnosisValue.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        MedRecordDiagnosisValue.Location = new Point(941, 351);
        MedRecordDiagnosisValue.Name = "MedRecordDiagnosisValue";
        MedRecordDiagnosisValue.ReadOnly = true;
        MedRecordDiagnosisValue.Size = new Size(357, 30);
        MedRecordDiagnosisValue.TabIndex = 54;
        // 
        // MedRecordPrescriptionLabel
        // 
        MedRecordPrescriptionLabel.Anchor = AnchorStyles.None;
        MedRecordPrescriptionLabel.AutoSize = true;
        MedRecordPrescriptionLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        MedRecordPrescriptionLabel.Location = new Point(813, 424);
        MedRecordPrescriptionLabel.Name = "MedRecordPrescriptionLabel";
        MedRecordPrescriptionLabel.Size = new Size(155, 25);
        MedRecordPrescriptionLabel.TabIndex = 51;
        MedRecordPrescriptionLabel.Text = "Prescription:";
        // 
        // MedRecordDateLabel
        // 
        MedRecordDateLabel.Anchor = AnchorStyles.None;
        MedRecordDateLabel.AutoSize = true;
        MedRecordDateLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        MedRecordDateLabel.Location = new Point(813, 504);
        MedRecordDateLabel.Name = "MedRecordDateLabel";
        MedRecordDateLabel.Size = new Size(144, 25);
        MedRecordDateLabel.TabIndex = 50;
        MedRecordDateLabel.Text = "Record Date:";
        // 
        // DoctorLabel
        // 
        DoctorLabel.Anchor = AnchorStyles.None;
        DoctorLabel.AutoSize = true;
        DoctorLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        DoctorLabel.Location = new Point(813, 290);
        DoctorLabel.Name = "DoctorLabel";
        DoctorLabel.Size = new Size(89, 25);
        DoctorLabel.TabIndex = 49;
        DoctorLabel.Text = "Doctor:";
        // 
        // MedRecordDiagnosisLabel
        // 
        MedRecordDiagnosisLabel.Anchor = AnchorStyles.None;
        MedRecordDiagnosisLabel.AutoSize = true;
        MedRecordDiagnosisLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        MedRecordDiagnosisLabel.Location = new Point(813, 356);
        MedRecordDiagnosisLabel.Name = "MedRecordDiagnosisLabel";
        MedRecordDiagnosisLabel.Size = new Size(122, 25);
        MedRecordDiagnosisLabel.TabIndex = 48;
        MedRecordDiagnosisLabel.Text = "Diagnosis:";
        // 
        // PatientLabel
        // 
        PatientLabel.Anchor = AnchorStyles.None;
        PatientLabel.AutoSize = true;
        PatientLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        PatientLabel.Location = new Point(813, 232);
        PatientLabel.Name = "PatientLabel";
        PatientLabel.Size = new Size(100, 25);
        PatientLabel.TabIndex = 47;
        PatientLabel.Text = "Patient:";
        // 
        // MedicalRecordDetailsTitle
        // 
        MedicalRecordDetailsTitle.Anchor = AnchorStyles.Top;
        MedicalRecordDetailsTitle.AutoSize = true;
        MedicalRecordDetailsTitle.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        MedicalRecordDetailsTitle.Location = new Point(813, 146);
        MedicalRecordDetailsTitle.Name = "MedicalRecordDetailsTitle";
        MedicalRecordDetailsTitle.Size = new Size(322, 32);
        MedicalRecordDetailsTitle.TabIndex = 46;
        MedicalRecordDetailsTitle.Text = "Medical Record Details";
        MedicalRecordDetailsTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // MedRecordPrescriptionValue
        // 
        MedRecordPrescriptionValue.Anchor = AnchorStyles.None;
        MedRecordPrescriptionValue.BorderStyle = BorderStyle.FixedSingle;
        MedRecordPrescriptionValue.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        MedRecordPrescriptionValue.Location = new Point(974, 419);
        MedRecordPrescriptionValue.Name = "MedRecordPrescriptionValue";
        MedRecordPrescriptionValue.ReadOnly = true;
        MedRecordPrescriptionValue.Size = new Size(357, 30);
        MedRecordPrescriptionValue.TabIndex = 57;
        // 
        // SaveMedicalRecordButton
        // 
        SaveMedicalRecordButton.BackColor = Color.CornflowerBlue;
        SaveMedicalRecordButton.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 255);
        SaveMedicalRecordButton.FlatAppearance.BorderSize = 0;
        SaveMedicalRecordButton.FlatStyle = FlatStyle.Flat;
        SaveMedicalRecordButton.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        SaveMedicalRecordButton.ForeColor = SystemColors.Control;
        SaveMedicalRecordButton.Location = new Point(919, 637);
        SaveMedicalRecordButton.Name = "SaveMedicalRecordButton";
        SaveMedicalRecordButton.Size = new Size(150, 37);
        SaveMedicalRecordButton.TabIndex = 59;
        SaveMedicalRecordButton.Text = "Save Changes";
        SaveMedicalRecordButton.UseVisualStyleBackColor = false;
        SaveMedicalRecordButton.Click += SaveMedicalRecordButton_Click;
        // 
        // EditMedicalRecordButton
        // 
        EditMedicalRecordButton.BackColor = Color.CornflowerBlue;
        EditMedicalRecordButton.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 255);
        EditMedicalRecordButton.FlatAppearance.BorderSize = 0;
        EditMedicalRecordButton.FlatStyle = FlatStyle.Flat;
        EditMedicalRecordButton.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        EditMedicalRecordButton.ForeColor = SystemColors.Control;
        EditMedicalRecordButton.Location = new Point(907, 571);
        EditMedicalRecordButton.Name = "EditMedicalRecordButton";
        EditMedicalRecordButton.Size = new Size(191, 37);
        EditMedicalRecordButton.TabIndex = 58;
        EditMedicalRecordButton.Text = "Edit Medical Record";
        EditMedicalRecordButton.UseVisualStyleBackColor = false;
        EditMedicalRecordButton.Click += EditMedicalRecordButton_Click;
        // 
        // MedRecordPatientValue
        // 
        MedRecordPatientValue.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        MedRecordPatientValue.FormattingEnabled = true;
        MedRecordPatientValue.Location = new Point(919, 232);
        MedRecordPatientValue.Name = "MedRecordPatientValue";
        MedRecordPatientValue.Size = new Size(419, 29);
        MedRecordPatientValue.TabIndex = 60;
        // 
        // MedRecordDoctorValue
        // 
        MedRecordDoctorValue.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        MedRecordDoctorValue.FormattingEnabled = true;
        MedRecordDoctorValue.Location = new Point(908, 291);
        MedRecordDoctorValue.Name = "MedRecordDoctorValue";
        MedRecordDoctorValue.Size = new Size(419, 29);
        MedRecordDoctorValue.TabIndex = 61;
        // 
        // MedicalRecordDetailsForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1904, 1041);
        Controls.Add(MedRecordDoctorValue);
        Controls.Add(MedRecordPatientValue);
        Controls.Add(SaveMedicalRecordButton);
        Controls.Add(EditMedicalRecordButton);
        Controls.Add(MedRecordPrescriptionValue);
        Controls.Add(MedRecordDateValue);
        Controls.Add(MedRecordDiagnosisValue);
        Controls.Add(MedRecordPrescriptionLabel);
        Controls.Add(MedRecordDateLabel);
        Controls.Add(DoctorLabel);
        Controls.Add(MedRecordDiagnosisLabel);
        Controls.Add(PatientLabel);
        Controls.Add(MedicalRecordDetailsTitle);
        Name = "MedicalRecordDetailsForm";
        Text = "Medical Record Details";
        Load += MedicalRecordDetailsForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DateTimePicker MedRecordDateValue;
    private TextBox MedRecordDiagnosisValue;
    private Label MedRecordPrescriptionLabel;
    private Label MedRecordDateLabel;
    private Label DoctorLabel;
    private Label MedRecordDiagnosisLabel;
    private Label PatientLabel;
    private Label MedicalRecordDetailsTitle;
    private TextBox MedRecordPrescriptionValue;
    private Button SaveMedicalRecordButton;
    private Button EditMedicalRecordButton;
    private ComboBox MedRecordPatientValue;
    private ComboBox MedRecordDoctorValue;
}