namespace HealthSync.WinForms.AppointmentsForms;

partial class AppointmentDetailsForm
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
        AppointmentStatusValue = new TextBox();
        AppointmentNotesValue = new TextBox();
        AppointmentStatusLabel = new Label();
        AppointmentDateTimeLabel = new Label();
        DoctorLabel = new Label();
        AppointmentNotesLabel = new Label();
        PatientLabel = new Label();
        AppointmentDetailsTitle = new Label();
        AppointmentDateTimeValue = new DateTimePicker();
        SaveAppointmentButton = new Button();
        EditAppointmentButton = new Button();
        AppointmentPatientValue = new ComboBox();
        AppointmentDoctorValue = new ComboBox();
        SuspendLayout();
        // 
        // AppointmentStatusValue
        // 
        AppointmentStatusValue.Anchor = AnchorStyles.None;
        AppointmentStatusValue.BorderStyle = BorderStyle.FixedSingle;
        AppointmentStatusValue.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        AppointmentStatusValue.Location = new Point(830, 481);
        AppointmentStatusValue.Name = "AppointmentStatusValue";
        AppointmentStatusValue.ReadOnly = true;
        AppointmentStatusValue.Size = new Size(357, 30);
        AppointmentStatusValue.TabIndex = 44;
        // 
        // AppointmentNotesValue
        // 
        AppointmentNotesValue.Anchor = AnchorStyles.None;
        AppointmentNotesValue.BorderStyle = BorderStyle.FixedSingle;
        AppointmentNotesValue.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        AppointmentNotesValue.Location = new Point(819, 412);
        AppointmentNotesValue.Name = "AppointmentNotesValue";
        AppointmentNotesValue.ReadOnly = true;
        AppointmentNotesValue.Size = new Size(357, 30);
        AppointmentNotesValue.TabIndex = 42;
        // 
        // AppointmentStatusLabel
        // 
        AppointmentStatusLabel.Anchor = AnchorStyles.None;
        AppointmentStatusLabel.AutoSize = true;
        AppointmentStatusLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        AppointmentStatusLabel.Location = new Point(735, 486);
        AppointmentStatusLabel.Name = "AppointmentStatusLabel";
        AppointmentStatusLabel.Size = new Size(89, 25);
        AppointmentStatusLabel.TabIndex = 39;
        AppointmentStatusLabel.Text = "Status:";
        // 
        // AppointmentDateTimeLabel
        // 
        AppointmentDateTimeLabel.Anchor = AnchorStyles.None;
        AppointmentDateTimeLabel.AutoSize = true;
        AppointmentDateTimeLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        AppointmentDateTimeLabel.Location = new Point(735, 351);
        AppointmentDateTimeLabel.Name = "AppointmentDateTimeLabel";
        AppointmentDateTimeLabel.Size = new Size(199, 25);
        AppointmentDateTimeLabel.TabIndex = 38;
        AppointmentDateTimeLabel.Text = "Appointment Date:";
        // 
        // DoctorLabel
        // 
        DoctorLabel.Anchor = AnchorStyles.None;
        DoctorLabel.AutoSize = true;
        DoctorLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        DoctorLabel.Location = new Point(735, 285);
        DoctorLabel.Name = "DoctorLabel";
        DoctorLabel.Size = new Size(89, 25);
        DoctorLabel.TabIndex = 37;
        DoctorLabel.Text = "Doctor:";
        // 
        // AppointmentNotesLabel
        // 
        AppointmentNotesLabel.Anchor = AnchorStyles.None;
        AppointmentNotesLabel.AutoSize = true;
        AppointmentNotesLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        AppointmentNotesLabel.Location = new Point(735, 417);
        AppointmentNotesLabel.Name = "AppointmentNotesLabel";
        AppointmentNotesLabel.Size = new Size(78, 25);
        AppointmentNotesLabel.TabIndex = 36;
        AppointmentNotesLabel.Text = "Notes:";
        // 
        // PatientLabel
        // 
        PatientLabel.Anchor = AnchorStyles.None;
        PatientLabel.AutoSize = true;
        PatientLabel.Font = new Font("Cascadia Code SemiBold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        PatientLabel.Location = new Point(735, 216);
        PatientLabel.Name = "PatientLabel";
        PatientLabel.Size = new Size(100, 25);
        PatientLabel.TabIndex = 35;
        PatientLabel.Text = "Patient:";
        // 
        // AppointmentDetailsTitle
        // 
        AppointmentDetailsTitle.Anchor = AnchorStyles.Top;
        AppointmentDetailsTitle.AutoSize = true;
        AppointmentDetailsTitle.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        AppointmentDetailsTitle.Location = new Point(800, 142);
        AppointmentDetailsTitle.Name = "AppointmentDetailsTitle";
        AppointmentDetailsTitle.Size = new Size(280, 32);
        AppointmentDetailsTitle.TabIndex = 34;
        AppointmentDetailsTitle.Text = "Appointment Details";
        AppointmentDetailsTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // AppointmentDateTimeValue
        // 
        AppointmentDateTimeValue.Enabled = false;
        AppointmentDateTimeValue.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        AppointmentDateTimeValue.Location = new Point(940, 351);
        AppointmentDateTimeValue.Name = "AppointmentDateTimeValue";
        AppointmentDateTimeValue.Size = new Size(352, 26);
        AppointmentDateTimeValue.TabIndex = 45;
        // 
        // SaveAppointmentButton
        // 
        SaveAppointmentButton.BackColor = Color.CornflowerBlue;
        SaveAppointmentButton.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 255);
        SaveAppointmentButton.FlatAppearance.BorderSize = 0;
        SaveAppointmentButton.FlatStyle = FlatStyle.Flat;
        SaveAppointmentButton.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        SaveAppointmentButton.ForeColor = SystemColors.Control;
        SaveAppointmentButton.Location = new Point(877, 619);
        SaveAppointmentButton.Name = "SaveAppointmentButton";
        SaveAppointmentButton.Size = new Size(150, 37);
        SaveAppointmentButton.TabIndex = 47;
        SaveAppointmentButton.Text = "Save Changes";
        SaveAppointmentButton.UseVisualStyleBackColor = false;
        SaveAppointmentButton.Click += SaveAppointmentButton_Click;
        // 
        // EditAppointmentButton
        // 
        EditAppointmentButton.BackColor = Color.CornflowerBlue;
        EditAppointmentButton.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 255);
        EditAppointmentButton.FlatAppearance.BorderSize = 0;
        EditAppointmentButton.FlatStyle = FlatStyle.Flat;
        EditAppointmentButton.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        EditAppointmentButton.ForeColor = SystemColors.Control;
        EditAppointmentButton.Location = new Point(867, 553);
        EditAppointmentButton.Name = "EditAppointmentButton";
        EditAppointmentButton.Size = new Size(174, 37);
        EditAppointmentButton.TabIndex = 46;
        EditAppointmentButton.Text = "Edit Appointment";
        EditAppointmentButton.UseVisualStyleBackColor = false;
        EditAppointmentButton.Click += EditAppointmentButton_Click;
        // 
        // AppointmentPatientValue
        // 
        AppointmentPatientValue.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        AppointmentPatientValue.FormattingEnabled = true;
        AppointmentPatientValue.Location = new Point(841, 217);
        AppointmentPatientValue.Name = "AppointmentPatientValue";
        AppointmentPatientValue.Size = new Size(419, 29);
        AppointmentPatientValue.TabIndex = 48;
        // 
        // AppointmentDoctorValue
        // 
        AppointmentDoctorValue.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        AppointmentDoctorValue.FormattingEnabled = true;
        AppointmentDoctorValue.Location = new Point(830, 286);
        AppointmentDoctorValue.Name = "AppointmentDoctorValue";
        AppointmentDoctorValue.Size = new Size(419, 29);
        AppointmentDoctorValue.TabIndex = 49;
        // 
        // AppointmentDetailsForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1904, 1041);
        Controls.Add(AppointmentDoctorValue);
        Controls.Add(AppointmentPatientValue);
        Controls.Add(SaveAppointmentButton);
        Controls.Add(EditAppointmentButton);
        Controls.Add(AppointmentDateTimeValue);
        Controls.Add(AppointmentStatusValue);
        Controls.Add(AppointmentNotesValue);
        Controls.Add(AppointmentStatusLabel);
        Controls.Add(AppointmentDateTimeLabel);
        Controls.Add(DoctorLabel);
        Controls.Add(AppointmentNotesLabel);
        Controls.Add(PatientLabel);
        Controls.Add(AppointmentDetailsTitle);
        Name = "AppointmentDetailsForm";
        Text = "Appointment Details";
        Load += AppointmentDetailsForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox AppointmentStatusValue;
    private TextBox AppointmentNotesValue;
    private Label AppointmentStatusLabel;
    private Label AppointmentDateTimeLabel;
    private Label DoctorLabel;
    private Label AppointmentNotesLabel;
    private Label PatientLabel;
    private Label AppointmentDetailsTitle;
    private DateTimePicker AppointmentDateTimeValue;
    private Button SaveAppointmentButton;
    private Button EditAppointmentButton;
    private ComboBox AppointmentPatientValue;
    private ComboBox AppointmentDoctorValue;
}