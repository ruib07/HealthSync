namespace HealthSync.WinForms.MedicalRecordsForms;

partial class MedicalRecordsByPatientForm
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
        MedicalRecordsTitle = new Label();
        MedicalRecordsData = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)MedicalRecordsData).BeginInit();
        SuspendLayout();
        // 
        // MedicalRecordsTitle
        // 
        MedicalRecordsTitle.AutoSize = true;
        MedicalRecordsTitle.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        MedicalRecordsTitle.Location = new Point(779, 128);
        MedicalRecordsTitle.Name = "MedicalRecordsTitle";
        MedicalRecordsTitle.Size = new Size(224, 32);
        MedicalRecordsTitle.TabIndex = 10;
        MedicalRecordsTitle.Text = "Medical Records";
        MedicalRecordsTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // MedicalRecordsData
        // 
        MedicalRecordsData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        MedicalRecordsData.BackgroundColor = SystemColors.Control;
        MedicalRecordsData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        MedicalRecordsData.Location = new Point(340, 206);
        MedicalRecordsData.Name = "MedicalRecordsData";
        MedicalRecordsData.Size = new Size(1097, 450);
        MedicalRecordsData.TabIndex = 9;
        // 
        // MedicalRecordsByPatientForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1904, 1041);
        Controls.Add(MedicalRecordsTitle);
        Controls.Add(MedicalRecordsData);
        Name = "MedicalRecordsByPatientForm";
        Text = "Medical Records By Patient";
        Load += MedicalRecordsByPatientForm_Load;
        ((System.ComponentModel.ISupportInitialize)MedicalRecordsData).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label MedicalRecordsTitle;
    private DataGridView MedicalRecordsData;
}