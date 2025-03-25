namespace HealthSync.WinForms.AppointmentsForms;

partial class AppointmentsByPatientForm
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
        AppointmentsTitle = new Label();
        AppointmentsData = new DataGridView();
        ((System.ComponentModel.ISupportInitialize)AppointmentsData).BeginInit();
        SuspendLayout();
        // 
        // AppointmentsTitle
        // 
        AppointmentsTitle.AutoSize = true;
        AppointmentsTitle.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        AppointmentsTitle.Location = new Point(779, 128);
        AppointmentsTitle.Name = "AppointmentsTitle";
        AppointmentsTitle.Size = new Size(182, 32);
        AppointmentsTitle.TabIndex = 8;
        AppointmentsTitle.Text = "Appointments";
        AppointmentsTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // AppointmentsData
        // 
        AppointmentsData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        AppointmentsData.BackgroundColor = SystemColors.Control;
        AppointmentsData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        AppointmentsData.Location = new Point(340, 206);
        AppointmentsData.Name = "AppointmentsData";
        AppointmentsData.Size = new Size(1097, 450);
        AppointmentsData.TabIndex = 7;
        // 
        // AppointmentsByPatientForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1904, 1041);
        Controls.Add(AppointmentsTitle);
        Controls.Add(AppointmentsData);
        Name = "AppointmentsByPatientForm";
        Text = "Appointments By Patient";
        Load += AppointmentsByPatientForm_Load;
        ((System.ComponentModel.ISupportInitialize)AppointmentsData).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label AppointmentsTitle;
    private DataGridView AppointmentsData;
}