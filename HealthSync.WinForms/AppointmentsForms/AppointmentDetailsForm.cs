using HealthSync.Domain.Entities;
using HealthSync.WinForms.Helper;

namespace HealthSync.WinForms.AppointmentsForms;

public partial class AppointmentDetailsForm : Form
{
    private readonly Appointments _appointment;

    public AppointmentDetailsForm(Appointments appointment)
    {
        InitializeComponent();
        this.Resize += ResizeEvent;

        _appointment = appointment;
        LoadAppointmentDetails();

    }

    private void AppointmentDetailsForm_Load(object sender, EventArgs e)
    {
        UIHelper.AlignFormInputs(this,
           new List<Label> { PatientLabel, DoctorLabel, AppointmentDateTimeLabel, AppointmentNotesLabel, AppointmentStatusLabel },
           new List<Control> { AppointmentPatientValue, AppointmentDoctorValue, AppointmentDateTimeValue, AppointmentNotesValue, AppointmentStatusValue },
           startY: 200,
           spacing: 60
        );
    }

    private void ResizeEvent(object sender, EventArgs e)
    {
        UIHelper.CenterTitleLabels(this, AppointmentDetailsTitle);
    }

    private void LoadAppointmentDetails()
    {
        AppointmentDoctorValue.Text = _appointment.DoctorId.ToString();
        AppointmentPatientValue.Text = _appointment.PatientId.ToString();
        AppointmentDateTimeValue.Value = _appointment.AppointmentDateTime;
        AppointmentNotesValue.Text = _appointment.Notes;
        AppointmentStatusValue.Text = _appointment.Status.ToString();
    }
}
