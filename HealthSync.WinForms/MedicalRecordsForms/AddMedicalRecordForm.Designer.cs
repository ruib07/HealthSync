namespace HealthSync.WinForms.MedicalRecordsForms;

partial class AddMedicalRecordForm
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
        DoctorsDropdown = new ComboBox();
        PatientsDropdown = new ComboBox();
        RecordDate = new DateTimePicker();
        AddMedicalRecordButton = new Button();
        MedicalRecordPrescription = new RichTextBox();
        CreateMedicalRecordTitle = new Label();
        MedicalRecordDiagnosis = new TextBox();
        SuspendLayout();
        // 
        // DoctorsDropdown
        // 
        DoctorsDropdown.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        DoctorsDropdown.FormattingEnabled = true;
        DoctorsDropdown.Location = new Point(675, 244);
        DoctorsDropdown.Name = "DoctorsDropdown";
        DoctorsDropdown.Size = new Size(419, 29);
        DoctorsDropdown.TabIndex = 28;
        // 
        // PatientsDropdown
        // 
        PatientsDropdown.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        PatientsDropdown.FormattingEnabled = true;
        PatientsDropdown.Location = new Point(675, 169);
        PatientsDropdown.Name = "PatientsDropdown";
        PatientsDropdown.Size = new Size(419, 29);
        PatientsDropdown.TabIndex = 27;
        // 
        // RecordDate
        // 
        RecordDate.CalendarMonthBackground = Color.WhiteSmoke;
        RecordDate.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        RecordDate.Location = new Point(675, 554);
        RecordDate.MaxDate = new DateTime(2025, 3, 15, 0, 0, 0, 0);
        RecordDate.MinDate = new DateTime(2020, 1, 1, 0, 0, 0, 0);
        RecordDate.Name = "RecordDate";
        RecordDate.Size = new Size(419, 26);
        RecordDate.TabIndex = 25;
        RecordDate.Value = new DateTime(2025, 3, 15, 0, 0, 0, 0);
        // 
        // AddMedicalRecordButton
        // 
        AddMedicalRecordButton.BackColor = Color.CornflowerBlue;
        AddMedicalRecordButton.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 255);
        AddMedicalRecordButton.FlatAppearance.BorderSize = 0;
        AddMedicalRecordButton.FlatStyle = FlatStyle.Flat;
        AddMedicalRecordButton.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        AddMedicalRecordButton.ForeColor = SystemColors.Control;
        AddMedicalRecordButton.Location = new Point(799, 670);
        AddMedicalRecordButton.Name = "AddMedicalRecordButton";
        AddMedicalRecordButton.Size = new Size(183, 37);
        AddMedicalRecordButton.TabIndex = 24;
        AddMedicalRecordButton.Text = "Add Medical Record";
        AddMedicalRecordButton.UseVisualStyleBackColor = false;
        AddMedicalRecordButton.Click += AddMedicalRecordButton_Click;
        // 
        // MedicalRecordPrescription
        // 
        MedicalRecordPrescription.BackColor = Color.WhiteSmoke;
        MedicalRecordPrescription.BorderStyle = BorderStyle.FixedSingle;
        MedicalRecordPrescription.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        MedicalRecordPrescription.Location = new Point(675, 394);
        MedicalRecordPrescription.Name = "MedicalRecordPrescription";
        MedicalRecordPrescription.Size = new Size(419, 118);
        MedicalRecordPrescription.TabIndex = 23;
        MedicalRecordPrescription.Text = "Prescription...";
        // 
        // CreateMedicalRecordTitle
        // 
        CreateMedicalRecordTitle.AutoSize = true;
        CreateMedicalRecordTitle.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        CreateMedicalRecordTitle.Location = new Point(747, 76);
        CreateMedicalRecordTitle.Name = "CreateMedicalRecordTitle";
        CreateMedicalRecordTitle.Size = new Size(308, 32);
        CreateMedicalRecordTitle.TabIndex = 22;
        CreateMedicalRecordTitle.Text = "Create Medical Record";
        CreateMedicalRecordTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // MedicalRecordDiagnosis
        // 
        MedicalRecordDiagnosis.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        MedicalRecordDiagnosis.Location = new Point(675, 324);
        MedicalRecordDiagnosis.Name = "MedicalRecordDiagnosis";
        MedicalRecordDiagnosis.Size = new Size(419, 26);
        MedicalRecordDiagnosis.TabIndex = 29;
        MedicalRecordDiagnosis.Text = "Diagnosis...";
        // 
        // AddMedicalRecordForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1904, 1041);
        Controls.Add(MedicalRecordDiagnosis);
        Controls.Add(DoctorsDropdown);
        Controls.Add(PatientsDropdown);
        Controls.Add(RecordDate);
        Controls.Add(AddMedicalRecordButton);
        Controls.Add(MedicalRecordPrescription);
        Controls.Add(CreateMedicalRecordTitle);
        Name = "AddMedicalRecordForm";
        Text = "Add Medical Record";
        Load += AddMedicalRecordForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ComboBox DoctorsDropdown;
    private ComboBox PatientsDropdown;
    private DateTimePicker RecordDate;
    private Button AddMedicalRecordButton;
    private RichTextBox MedicalRecordPrescription;
    private Label CreateMedicalRecordTitle;
    private TextBox MedicalRecordDiagnosis;
}