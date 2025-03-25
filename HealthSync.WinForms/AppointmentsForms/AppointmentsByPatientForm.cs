using HealthSync.Domain.Entities;
using HealthSync.WinForms.Services;

namespace HealthSync.WinForms.AppointmentsForms;

public partial class AppointmentsByPatientForm : Form
{
    private readonly Guid _patientId;
    private readonly AppointmentsService _appointmentsService;

    public AppointmentsByPatientForm(Guid patientId, AppointmentsService appointmentsService)
    {
        InitializeComponent();
        _patientId = patientId;
        _appointmentsService = appointmentsService;
    }

    private async void AppointmentsByPatientForm_Load(object sender, EventArgs e)
    {
        await LoadPatientAppointments();
    }

    private async Task LoadPatientAppointments()
    {
        try
        {
            var patientAppointments = await _appointmentsService.GetAppointmentsByPatientId(_patientId);

            AppointmentsData.DataSource = new List<Appointments>(patientAppointments);

            AppointmentsData.Columns["Id"].Visible = false;
            AppointmentsData.Columns["Patient"].Visible = false;
            AppointmentsData.Columns["Doctor"].Visible = false;
            AppointmentsData.Columns["PatientId"].Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
