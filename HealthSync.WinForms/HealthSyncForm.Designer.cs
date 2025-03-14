namespace HealthSync.WinForms
{
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
            PatientsTitle = new Label();
            PatientsData = new DataGridView();
            buttonColumn = new DataGridViewButtonColumn();
            DoctorsTab = new TabPage();
            DoctorsTitle = new Label();
            DoctorsData = new DataGridView();
            dataGridViewButtonColumn1 = new DataGridViewButtonColumn();
            AppointmentsTab = new TabPage();
            MedicalRecordsTab = new TabPage();
            AppointmentsTitle = new Label();
            AppointmentsData = new DataGridView();
            dataGridViewButtonColumn2 = new DataGridViewButtonColumn();
            MedicalRecordsTitle = new Label();
            MedicalRecordsData = new DataGridView();
            dataGridViewButtonColumn3 = new DataGridViewButtonColumn();
            HomeTab.SuspendLayout();
            PatientsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PatientsData).BeginInit();
            DoctorsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DoctorsData).BeginInit();
            AppointmentsTab.SuspendLayout();
            MedicalRecordsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AppointmentsData).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MedicalRecordsData).BeginInit();
            SuspendLayout();
            // 
            // HomeTab
            // 
            HomeTab.Controls.Add(PatientsTab);
            HomeTab.Controls.Add(DoctorsTab);
            HomeTab.Controls.Add(AppointmentsTab);
            HomeTab.Controls.Add(MedicalRecordsTab);
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
            PatientsData.Columns.AddRange(new DataGridViewColumn[] { buttonColumn });
            PatientsData.Location = new Point(284, 261);
            PatientsData.Name = "PatientsData";
            PatientsData.Size = new Size(1097, 575);
            PatientsData.TabIndex = 1;
            // 
            // buttonColumn
            // 
            buttonColumn.HeaderText = "Actions";
            buttonColumn.Name = "buttonColumn";
            buttonColumn.Text = "Edit";
            buttonColumn.UseColumnTextForButtonValue = true;
            // 
            // DoctorsTab
            // 
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
            DoctorsData.Columns.AddRange(new DataGridViewColumn[] { dataGridViewButtonColumn1 });
            DoctorsData.Location = new Point(284, 261);
            DoctorsData.Name = "DoctorsData";
            DoctorsData.Size = new Size(1097, 575);
            DoctorsData.TabIndex = 3;
            // 
            // dataGridViewButtonColumn1
            // 
            dataGridViewButtonColumn1.HeaderText = "Actions";
            dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            dataGridViewButtonColumn1.Text = "Edit";
            dataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            // 
            // AppointmentsTab
            // 
            AppointmentsTab.Controls.Add(AppointmentsTitle);
            AppointmentsTab.Controls.Add(AppointmentsData);
            AppointmentsTab.Location = new Point(4, 30);
            AppointmentsTab.Name = "AppointmentsTab";
            AppointmentsTab.Size = new Size(1895, 1009);
            AppointmentsTab.TabIndex = 2;
            AppointmentsTab.Text = "Appointments";
            AppointmentsTab.UseVisualStyleBackColor = true;
            // 
            // MedicalRecordsTab
            // 
            MedicalRecordsTab.Controls.Add(MedicalRecordsTitle);
            MedicalRecordsTab.Controls.Add(MedicalRecordsData);
            MedicalRecordsTab.Location = new Point(4, 30);
            MedicalRecordsTab.Name = "MedicalRecordsTab";
            MedicalRecordsTab.Size = new Size(1895, 1009);
            MedicalRecordsTab.TabIndex = 3;
            MedicalRecordsTab.Text = "Medical Records";
            MedicalRecordsTab.UseVisualStyleBackColor = true;
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
            AppointmentsData.Columns.AddRange(new DataGridViewColumn[] { dataGridViewButtonColumn2 });
            AppointmentsData.Location = new Point(284, 261);
            AppointmentsData.Name = "AppointmentsData";
            AppointmentsData.Size = new Size(1097, 575);
            AppointmentsData.TabIndex = 3;
            // 
            // dataGridViewButtonColumn2
            // 
            dataGridViewButtonColumn2.HeaderText = "Actions";
            dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            dataGridViewButtonColumn2.Text = "Edit";
            dataGridViewButtonColumn2.UseColumnTextForButtonValue = true;
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
            MedicalRecordsData.Columns.AddRange(new DataGridViewColumn[] { dataGridViewButtonColumn3 });
            MedicalRecordsData.Location = new Point(284, 261);
            MedicalRecordsData.Name = "MedicalRecordsData";
            MedicalRecordsData.Size = new Size(1097, 575);
            MedicalRecordsData.TabIndex = 3;
            // 
            // dataGridViewButtonColumn3
            // 
            dataGridViewButtonColumn3.HeaderText = "Actions";
            dataGridViewButtonColumn3.Name = "dataGridViewButtonColumn3";
            dataGridViewButtonColumn3.Text = "Edit";
            dataGridViewButtonColumn3.UseColumnTextForButtonValue = true;
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
            MedicalRecordsTab.ResumeLayout(false);
            MedicalRecordsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AppointmentsData).EndInit();
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
        private DataGridViewButtonColumn buttonColumn;
        private Label DoctorsTitle;
        private DataGridView DoctorsData;
        private DataGridViewButtonColumn dataGridViewButtonColumn1;
        private Label AppointmentsTitle;
        private DataGridView AppointmentsData;
        private DataGridViewButtonColumn dataGridViewButtonColumn2;
        private Label MedicalRecordsTitle;
        private DataGridView MedicalRecordsData;
        private DataGridViewButtonColumn dataGridViewButtonColumn3;
    }
}