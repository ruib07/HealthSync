namespace HealthSync.WinForms;

partial class HealthSyncForm
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
        HomeTab = new TabControl();
        PatientsTab = new TabPage();
        CreatePatientButton = new Button();
        PatientsTitle = new Label();
        PatientsData = new DataGridView();
        DeletePatientButton = new DataGridViewButtonColumn();
        DoctorsTab = new TabPage();
        CreateDoctorButton = new Button();
        DoctorsTitle = new Label();
        DoctorsData = new DataGridView();
        DeleteDoctorButton = new DataGridViewButtonColumn();
        AppointmentsTab = new TabPage();
        CreateAppointmentButton = new Button();
        AppointmentsTitle = new Label();
        AppointmentsData = new DataGridView();
        MedicalRecordsTab = new TabPage();
        CreateMedicalRecordButton = new Button();
        MedicalRecordsTitle = new Label();
        MedicalRecordsData = new DataGridView();
        DeleteMedicalRecordButton = new DataGridViewButtonColumn();
        ExitTab = new TabPage();
        DeleteAppointmentButton = new DataGridViewButtonColumn();
        HomeTab.SuspendLayout();
        PatientsTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)PatientsData).BeginInit();
        DoctorsTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)DoctorsData).BeginInit();
        AppointmentsTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)AppointmentsData).BeginInit();
        MedicalRecordsTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)MedicalRecordsData).BeginInit();
        SuspendLayout();
        // 
        // HomeTab
        // 
        HomeTab.Controls.Add(PatientsTab);
        HomeTab.Controls.Add(DoctorsTab);
        HomeTab.Controls.Add(AppointmentsTab);
        HomeTab.Controls.Add(MedicalRecordsTab);
        HomeTab.Controls.Add(ExitTab);
        HomeTab.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        HomeTab.Location = new Point(0, 0);
        HomeTab.Name = "HomeTab";
        HomeTab.SelectedIndex = 0;
        HomeTab.Size = new Size(1903, 1043);
        HomeTab.TabIndex = 0;
        HomeTab.SelectedIndexChanged += TabControl_SelectedIndexChanged;
        // 
        // PatientsTab
        // 
        PatientsTab.AllowDrop = true;
        PatientsTab.Controls.Add(CreatePatientButton);
        PatientsTab.Controls.Add(PatientsTitle);
        PatientsTab.Controls.Add(PatientsData);
        PatientsTab.Location = new Point(4, 30);
        PatientsTab.Name = "PatientsTab";
        PatientsTab.Padding = new Padding(3);
        PatientsTab.Size = new Size(1895, 1009);
        PatientsTab.TabIndex = 0;
        PatientsTab.Text = "Patients";
        PatientsTab.UseVisualStyleBackColor = true;
        // 
        // CreatePatientButton
        // 
        CreatePatientButton.BackColor = Color.CornflowerBlue;
        CreatePatientButton.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 255);
        CreatePatientButton.FlatAppearance.BorderSize = 0;
        CreatePatientButton.FlatStyle = FlatStyle.Flat;
        CreatePatientButton.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        CreatePatientButton.ForeColor = SystemColors.Control;
        CreatePatientButton.Location = new Point(769, 748);
        CreatePatientButton.Name = "CreatePatientButton";
        CreatePatientButton.Size = new Size(150, 37);
        CreatePatientButton.TabIndex = 10;
        CreatePatientButton.Text = "Create Patient";
        CreatePatientButton.UseVisualStyleBackColor = false;
        CreatePatientButton.Click += CreatePatientButton_Click;
        // 
        // PatientsTitle
        // 
        PatientsTitle.AutoSize = true;
        PatientsTitle.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        PatientsTitle.Location = new Point(769, 178);
        PatientsTitle.Name = "PatientsTitle";
        PatientsTitle.Size = new Size(126, 32);
        PatientsTitle.TabIndex = 2;
        PatientsTitle.Text = "Patients";
        PatientsTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // PatientsData
        // 
        PatientsData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        PatientsData.BackgroundColor = SystemColors.Control;
        PatientsData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        PatientsData.Columns.AddRange(new DataGridViewColumn[] { DeletePatientButton });
        PatientsData.Location = new Point(284, 261);
        PatientsData.Name = "PatientsData";
        PatientsData.Size = new Size(1097, 450);
        PatientsData.TabIndex = 1;
        // 
        // DeletePatientButton
        // 
        DeletePatientButton.HeaderText = "Actions";
        DeletePatientButton.Name = "DeletePatientButton";
        DeletePatientButton.Text = "Delete";
        DeletePatientButton.UseColumnTextForButtonValue = true;
        // 
        // DoctorsTab
        // 
        DoctorsTab.Controls.Add(CreateDoctorButton);
        DoctorsTab.Controls.Add(DoctorsTitle);
        DoctorsTab.Controls.Add(DoctorsData);
        DoctorsTab.Location = new Point(4, 30);
        DoctorsTab.Name = "DoctorsTab";
        DoctorsTab.Padding = new Padding(3);
        DoctorsTab.Size = new Size(1895, 1009);
        DoctorsTab.TabIndex = 1;
        DoctorsTab.Text = "Doctors";
        DoctorsTab.UseVisualStyleBackColor = true;
        // 
        // CreateDoctorButton
        // 
        CreateDoctorButton.BackColor = Color.CornflowerBlue;
        CreateDoctorButton.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 255);
        CreateDoctorButton.FlatAppearance.BorderSize = 0;
        CreateDoctorButton.FlatStyle = FlatStyle.Flat;
        CreateDoctorButton.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        CreateDoctorButton.ForeColor = SystemColors.Control;
        CreateDoctorButton.Location = new Point(754, 748);
        CreateDoctorButton.Name = "CreateDoctorButton";
        CreateDoctorButton.Size = new Size(150, 37);
        CreateDoctorButton.TabIndex = 11;
        CreateDoctorButton.Text = "Create Doctor";
        CreateDoctorButton.UseVisualStyleBackColor = false;
        CreateDoctorButton.Click += CreateDoctorButton_Click;
        // 
        // DoctorsTitle
        // 
        DoctorsTitle.AutoSize = true;
        DoctorsTitle.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        DoctorsTitle.Location = new Point(769, 178);
        DoctorsTitle.Name = "DoctorsTitle";
        DoctorsTitle.Size = new Size(112, 32);
        DoctorsTitle.TabIndex = 4;
        DoctorsTitle.Text = "Doctors";
        DoctorsTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // DoctorsData
        // 
        DoctorsData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        DoctorsData.BackgroundColor = SystemColors.Control;
        DoctorsData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        DoctorsData.Columns.AddRange(new DataGridViewColumn[] { DeleteDoctorButton });
        DoctorsData.Location = new Point(284, 261);
        DoctorsData.Name = "DoctorsData";
        DoctorsData.Size = new Size(1097, 450);
        DoctorsData.TabIndex = 3;
        // 
        // DeleteDoctorButton
        // 
        DeleteDoctorButton.HeaderText = "Actions";
        DeleteDoctorButton.Name = "DeleteDoctorButton";
        DeleteDoctorButton.Text = "Delete";
        DeleteDoctorButton.UseColumnTextForButtonValue = true;
        // 
        // AppointmentsTab
        // 
        AppointmentsTab.Controls.Add(CreateAppointmentButton);
        AppointmentsTab.Controls.Add(AppointmentsTitle);
        AppointmentsTab.Controls.Add(AppointmentsData);
        AppointmentsTab.Location = new Point(4, 30);
        AppointmentsTab.Name = "AppointmentsTab";
        AppointmentsTab.Size = new Size(1895, 1009);
        AppointmentsTab.TabIndex = 2;
        AppointmentsTab.Text = "Appointments";
        AppointmentsTab.UseVisualStyleBackColor = true;
        // 
        // CreateAppointmentButton
        // 
        CreateAppointmentButton.BackColor = Color.CornflowerBlue;
        CreateAppointmentButton.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 255);
        CreateAppointmentButton.FlatAppearance.BorderSize = 0;
        CreateAppointmentButton.FlatStyle = FlatStyle.Flat;
        CreateAppointmentButton.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        CreateAppointmentButton.ForeColor = SystemColors.Control;
        CreateAppointmentButton.Location = new Point(730, 748);
        CreateAppointmentButton.Name = "CreateAppointmentButton";
        CreateAppointmentButton.Size = new Size(186, 37);
        CreateAppointmentButton.TabIndex = 12;
        CreateAppointmentButton.Text = "Create Appointment";
        CreateAppointmentButton.UseVisualStyleBackColor = false;
        CreateAppointmentButton.Click += CreateAppointmentButton_Click;
        // 
        // AppointmentsTitle
        // 
        AppointmentsTitle.AutoSize = true;
        AppointmentsTitle.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        AppointmentsTitle.Location = new Point(769, 178);
        AppointmentsTitle.Name = "AppointmentsTitle";
        AppointmentsTitle.Size = new Size(182, 32);
        AppointmentsTitle.TabIndex = 4;
        AppointmentsTitle.Text = "Appointments";
        AppointmentsTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // AppointmentsData
        // 
        AppointmentsData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        AppointmentsData.BackgroundColor = SystemColors.Control;
        AppointmentsData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        AppointmentsData.Columns.AddRange(new DataGridViewColumn[] { DeleteAppointmentButton });
        AppointmentsData.Location = new Point(284, 261);
        AppointmentsData.Name = "AppointmentsData";
        AppointmentsData.Size = new Size(1097, 450);
        AppointmentsData.TabIndex = 3;
        // 
        // MedicalRecordsTab
        // 
        MedicalRecordsTab.Controls.Add(CreateMedicalRecordButton);
        MedicalRecordsTab.Controls.Add(MedicalRecordsTitle);
        MedicalRecordsTab.Controls.Add(MedicalRecordsData);
        MedicalRecordsTab.Location = new Point(4, 30);
        MedicalRecordsTab.Name = "MedicalRecordsTab";
        MedicalRecordsTab.Size = new Size(1895, 1009);
        MedicalRecordsTab.TabIndex = 3;
        MedicalRecordsTab.Text = "Medical Records";
        MedicalRecordsTab.UseVisualStyleBackColor = true;
        // 
        // CreateMedicalRecordButton
        // 
        CreateMedicalRecordButton.BackColor = Color.CornflowerBlue;
        CreateMedicalRecordButton.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 255);
        CreateMedicalRecordButton.FlatAppearance.BorderSize = 0;
        CreateMedicalRecordButton.FlatStyle = FlatStyle.Flat;
        CreateMedicalRecordButton.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        CreateMedicalRecordButton.ForeColor = SystemColors.Control;
        CreateMedicalRecordButton.Location = new Point(730, 748);
        CreateMedicalRecordButton.Name = "CreateMedicalRecordButton";
        CreateMedicalRecordButton.Size = new Size(209, 37);
        CreateMedicalRecordButton.TabIndex = 13;
        CreateMedicalRecordButton.Text = "Create Medical Record";
        CreateMedicalRecordButton.UseVisualStyleBackColor = false;
        CreateMedicalRecordButton.Click += CreateMedicalRecordButton_Click;
        // 
        // MedicalRecordsTitle
        // 
        MedicalRecordsTitle.AutoSize = true;
        MedicalRecordsTitle.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        MedicalRecordsTitle.Location = new Point(769, 178);
        MedicalRecordsTitle.Name = "MedicalRecordsTitle";
        MedicalRecordsTitle.Size = new Size(224, 32);
        MedicalRecordsTitle.TabIndex = 4;
        MedicalRecordsTitle.Text = "Medical Records";
        MedicalRecordsTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // MedicalRecordsData
        // 
        MedicalRecordsData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        MedicalRecordsData.BackgroundColor = SystemColors.Control;
        MedicalRecordsData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        MedicalRecordsData.Columns.AddRange(new DataGridViewColumn[] { DeleteMedicalRecordButton });
        MedicalRecordsData.Location = new Point(284, 261);
        MedicalRecordsData.Name = "MedicalRecordsData";
        MedicalRecordsData.Size = new Size(1097, 450);
        MedicalRecordsData.TabIndex = 3;
        // 
        // DeleteMedicalRecordButton
        // 
        DeleteMedicalRecordButton.HeaderText = "Actions";
        DeleteMedicalRecordButton.Name = "DeleteMedicalRecordButton";
        DeleteMedicalRecordButton.Text = "Delete";
        DeleteMedicalRecordButton.UseColumnTextForButtonValue = true;
        // 
        // ExitTab
        // 
        ExitTab.BackColor = Color.Transparent;
        ExitTab.Location = new Point(4, 30);
        ExitTab.Name = "ExitTab";
        ExitTab.Padding = new Padding(3);
        ExitTab.Size = new Size(1895, 1009);
        ExitTab.TabIndex = 4;
        ExitTab.Text = "Exit";
        // 
        // DeleteAppointmentButton
        // 
        DeleteAppointmentButton.HeaderText = "Actions";
        DeleteAppointmentButton.Name = "DeleteAppointmentButton";
        DeleteAppointmentButton.Text = "Delete";
        DeleteAppointmentButton.UseColumnTextForButtonValue = true;
        // 
        // HealthSyncForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1904, 1041);
        Controls.Add(HomeTab);
        Name = "HealthSyncForm";
        Text = "HealthSync";
        Load += HealthSyncForm_Load;
        HomeTab.ResumeLayout(false);
        PatientsTab.ResumeLayout(false);
        PatientsTab.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)PatientsData).EndInit();
        DoctorsTab.ResumeLayout(false);
        DoctorsTab.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)DoctorsData).EndInit();
        AppointmentsTab.ResumeLayout(false);
        AppointmentsTab.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)AppointmentsData).EndInit();
        MedicalRecordsTab.ResumeLayout(false);
        MedicalRecordsTab.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)MedicalRecordsData).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private TabControl HomeTab;
    private TabPage PatientsTab;
    private TabPage DoctorsTab;
    private TabPage AppointmentsTab;
    private TabPage MedicalRecordsTab;
    private DataGridView PatientsData;
    private Label PatientsTitle;
    private Label DoctorsTitle;
    private DataGridView DoctorsData;
    private Label AppointmentsTitle;
    private DataGridView AppointmentsData;
    private Label MedicalRecordsTitle;
    private DataGridView MedicalRecordsData;
    private Button CreatePatientButton;
    private Button CreateDoctorButton;
    private TabPage ExitTab;
    private Button CreateAppointmentButton;
    private Button CreateMedicalRecordButton;
    private DataGridViewButtonColumn DeletePatientButton;
    private DataGridViewButtonColumn DeleteDoctorButton;
    private DataGridViewButtonColumn DeleteMedicalRecordButton;
    private DataGridViewButtonColumn DeleteAppointmentButton;
}