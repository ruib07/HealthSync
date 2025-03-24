using HealthSync.Domain.Entities;
using HealthSync.Domain.Enums;
using HealthSync.WinForms.Helper;
using HealthSync.WinForms.Services;

namespace HealthSync.WinForms.AppointmentsForms;

public partial class AppointmentDetailsForm : Form
{
    private readonly Appointments _appointment;
    private readonly AppointmentsService _appointmentsService;

    public AppointmentDetailsForm(Appointments appointment, AppointmentsService appointmentsService)
    {
        InitializeComponent();
        this.Resize += ResizeEvent;

        _appointment = appointment;
        _appointmentsService = appointmentsService;
        LoadAppointmentDetails();

    }

    private void AppointmentDetailsForm_Load(object sender, EventArgs e)
    {
        UIHelper.AlignFormInputs(this,
           new List<Label>() { PatientLabel, DoctorLabel, AppointmentDateTimeLabel, AppointmentNotesLabel, AppointmentStatusLabel },
           new List<Control>() { AppointmentPatientValue, AppointmentDoctorValue, AppointmentDateTimeValue, AppointmentNotesValue, AppointmentStatusValue },
           startY: 200,
           spacing: 60
        );

        ToggleEditMode(false);
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

    private void EditAppointmentButton_Click(object sender, EventArgs e)
    {
        ToggleEditMode(true);
    }

    private async void SaveAppointmentButton_Click(object sender, EventArgs e)
    {
        try
        {
            var updatedAppointment = new Appointments()
            {
                Id = _appointment.Id,
                DoctorId = Guid.Parse(AppointmentDoctorValue.Text),
                PatientId = Guid.Parse(AppointmentPatientValue.Text),
                AppointmentDateTime = AppointmentDateTimeValue.Value,
                Notes = AppointmentNotesValue.Text,
                Status = Enum.Parse<AppointmentStatus>(AppointmentStatusValue.Text),
            };

            await _appointmentsService.EditAppointment(_appointment.Id, updatedAppointment);

            _appointment.DoctorId = updatedAppointment.DoctorId;
            _appointment.PatientId = updatedAppointment.PatientId;
            _appointment.AppointmentDateTime = updatedAppointment.AppointmentDateTime;
            _appointment.Notes = updatedAppointment.Notes;
            _appointment.Status = updatedAppointment.Status;

            MessageBox.Show("Appointment details updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ToggleEditMode(false);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ToggleEditMode(bool enable)
    {
        UIHelper.ToggleEditMode(this, enable, new List<Control>()
        {
            AppointmentDoctorValue, AppointmentPatientValue, AppointmentDateTimeValue, AppointmentNotesValue, AppointmentStatusValue
        }, EditAppointmentButton, SaveAppointmentButton);
    }
}
