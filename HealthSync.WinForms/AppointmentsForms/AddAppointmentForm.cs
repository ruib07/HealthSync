using HealthSync.Domain.Entities;
using HealthSync.Domain.Enums;
using HealthSync.WinForms.Helpers;
using HealthSync.WinForms.Services;

namespace HealthSync.WinForms.AppointmentsForms;

public partial class AddAppointmentForm : Form
{
    private readonly AppointmentsService _appointmentsService;
    private readonly PatientsService _patientsService;
    private readonly DoctorsService _doctorsService;

    public AddAppointmentForm(AppointmentsService appointmentsService, PatientsService patientsService, DoctorsService doctorsService)
    {
        InitializeComponent();
        this.Resize += ResizeEvent;

        _appointmentsService = appointmentsService;
        _patientsService = patientsService;
        _doctorsService = doctorsService;
    }

    private async void AddAppointmentForm_Load(object sender, EventArgs e)
    {
        var patients = await _patientsService.GetPatients();
        PatientsDropdown.DataSource = patients.ToList();
        PatientsDropdown.DisplayMember = "Name";
        PatientsDropdown.ValueMember = "Id";

        var doctors = await _doctorsService.GetDoctors();
        DoctorsDropdown.DataSource = doctors.ToList();
        DoctorsDropdown.DisplayMember = "Name";
        DoctorsDropdown.ValueMember = "Id";

        AppointmentStatusDropdown.DataSource = Enum.GetValues<AppointmentStatus>();
    }

    private void ResizeEvent(object sender, EventArgs e)
    {
        UIHelper.CenterTitleLabels(this, CreateAppointmentTitle);
        UIHelper.CenterCreateButton(this, AddAppointmentButton);
    }

    private async void AddAppointmentButton_Click(object sender, EventArgs e)
    {
        try
        {
            var selectedPatient = (Patients)PatientsDropdown.SelectedItem;
            var selectedDoctor = (Doctors)DoctorsDropdown.SelectedItem;

            var newAppointment = new Appointments()
            {
                PatientId = selectedPatient.Id,
                DoctorId = selectedDoctor.Id,
                AppointmentDateTime = AppointmentDateTime.Value,
                Notes = AppointmentNotes.Text,
                Status = (AppointmentStatus)AppointmentStatusDropdown.SelectedItem
            };

            var createdAppointment = await _appointmentsService.CreateAppointment(newAppointment);

            MessageBox.Show($"Appointment {createdAppointment.Id} created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error creating appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
