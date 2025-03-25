using HealthSync.Domain.Entities;
using HealthSync.WinForms.Services;

namespace HealthSync.WinForms.AppointmentsForms;

public partial class AppointmentsByDoctorForm : Form
{
    private readonly Guid _doctorId;
    private readonly AppointmentsService _appointmentsService;

    public AppointmentsByDoctorForm(Guid doctorId, AppointmentsService appointmentsService)
    {
        InitializeComponent();
        _doctorId = doctorId;
        _appointmentsService = appointmentsService;
    }

    private async void AppointmentsByDoctorForm_Load(object sender, EventArgs e)
    {
        await LoadDoctorAppointments();
    }

    private async Task LoadDoctorAppointments()
    {
        try
        {
            var doctorAppointments = await _appointmentsService.GetAppointmentsByDoctorId(_doctorId);

            AppointmentsData.DataSource = new List<Appointments>(doctorAppointments);

            AppointmentsData.Columns["Id"].Visible = false;
            AppointmentsData.Columns["Patient"].Visible = false;
            AppointmentsData.Columns["Doctor"].Visible = false;
            AppointmentsData.Columns["DoctorId"].Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
