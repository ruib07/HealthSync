namespace HealthSync.WinForms.AppointmentsForms;

partial class AddAppointmentForm
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
        AddAppointmentButton = new Button();
        AppointmentNotes = new RichTextBox();
        CreateAppointmentTitle = new Label();
        AppointmentDateTime = new DateTimePicker();
        AppointmentStatusDropdown = new ComboBox();
        PatientsDropdown = new ComboBox();
        DoctorsDropdown = new ComboBox();
        SuspendLayout();
        // 
        // AddAppointmentButton
        // 
        AddAppointmentButton.BackColor = Color.CornflowerBlue;
        AddAppointmentButton.FlatAppearance.BorderColor = Color.FromArgb(192, 255, 255);
        AddAppointmentButton.FlatAppearance.BorderSize = 0;
        AddAppointmentButton.FlatStyle = FlatStyle.Flat;
        AddAppointmentButton.Font = new Font("Cascadia Code", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
        AddAppointmentButton.ForeColor = SystemColors.Control;
        AddAppointmentButton.Location = new Point(799, 670);
        AddAppointmentButton.Name = "AddAppointmentButton";
        AddAppointmentButton.Size = new Size(159, 37);
        AddAppointmentButton.TabIndex = 16;
        AddAppointmentButton.Text = "Add Appointment";
        AddAppointmentButton.UseVisualStyleBackColor = false;
        AddAppointmentButton.Click += AddAppointmentButton_Click;
        // 
        // AppointmentNotes
        // 
        AppointmentNotes.BackColor = Color.WhiteSmoke;
        AppointmentNotes.BorderStyle = BorderStyle.FixedSingle;
        AppointmentNotes.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        AppointmentNotes.Location = new Point(675, 394);
        AppointmentNotes.Name = "AppointmentNotes";
        AppointmentNotes.Size = new Size(419, 118);
        AppointmentNotes.TabIndex = 14;
        AppointmentNotes.Text = "Notes...";
        // 
        // CreateAppointmentTitle
        // 
        CreateAppointmentTitle.AutoSize = true;
        CreateAppointmentTitle.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
        CreateAppointmentTitle.Location = new Point(756, 76);
        CreateAppointmentTitle.Name = "CreateAppointmentTitle";
        CreateAppointmentTitle.Size = new Size(266, 32);
        CreateAppointmentTitle.TabIndex = 10;
        CreateAppointmentTitle.Text = "Create Appointment";
        CreateAppointmentTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // AppointmentDateTime
        // 
        AppointmentDateTime.CalendarMonthBackground = Color.WhiteSmoke;
        AppointmentDateTime.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        AppointmentDateTime.Location = new Point(675, 324);
        AppointmentDateTime.MaxDate = new DateTime(2028, 12, 31, 0, 0, 0, 0);
        AppointmentDateTime.MinDate = new DateTime(2025, 3, 15, 0, 0, 0, 0);
        AppointmentDateTime.Name = "AppointmentDateTime";
        AppointmentDateTime.Size = new Size(419, 26);
        AppointmentDateTime.TabIndex = 18;
        AppointmentDateTime.Value = new DateTime(2025, 3, 15, 0, 0, 0, 0);
        // 
        // AppointmentStatusDropdown
        // 
        AppointmentStatusDropdown.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        AppointmentStatusDropdown.FormattingEnabled = true;
        AppointmentStatusDropdown.Location = new Point(675, 554);
        AppointmentStatusDropdown.Name = "AppointmentStatusDropdown";
        AppointmentStatusDropdown.Size = new Size(419, 29);
        AppointmentStatusDropdown.TabIndex = 19;
        // 
        // PatientsDropdown
        // 
        PatientsDropdown.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        PatientsDropdown.FormattingEnabled = true;
        PatientsDropdown.Location = new Point(675, 169);
        PatientsDropdown.Name = "PatientsDropdown";
        PatientsDropdown.Size = new Size(419, 29);
        PatientsDropdown.TabIndex = 20;
        // 
        // DoctorsDropdown
        // 
        DoctorsDropdown.Font = new Font("Cascadia Code", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        DoctorsDropdown.FormattingEnabled = true;
        DoctorsDropdown.Location = new Point(675, 244);
        DoctorsDropdown.Name = "DoctorsDropdown";
        DoctorsDropdown.Size = new Size(419, 29);
        DoctorsDropdown.TabIndex = 21;
        // 
        // AddAppointmentForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1904, 1041);
        Controls.Add(DoctorsDropdown);
        Controls.Add(PatientsDropdown);
        Controls.Add(AppointmentStatusDropdown);
        Controls.Add(AppointmentDateTime);
        Controls.Add(AddAppointmentButton);
        Controls.Add(AppointmentNotes);
        Controls.Add(CreateAppointmentTitle);
        Name = "AddAppointmentForm";
        Text = "Add Appointment";
        Load += AddAppointmentForm_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button AddAppointmentButton;
    private RichTextBox AppointmentNotes;
    private Label CreateAppointmentTitle;
    private DateTimePicker AppointmentDateTime;
    private ComboBox AppointmentStatusDropdown;
    private ComboBox PatientsDropdown;
    private ComboBox DoctorsDropdown;
}