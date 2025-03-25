using HealthSync.Domain.Entities;
using HealthSync.WinForms.AppointmentsForms;
using HealthSync.WinForms.Services;

namespace HealthSync.WinForms.Helpers;

public static class AppointmentsHelper
{
    public static async Task LoadAppointments(DataGridView appointmentsData, AppointmentsService appointmentsService)
    {
        try
        {
            var appointments = await appointmentsService.GetAppointments();
            appointmentsData.DataSource = new List<Appointments>(appointments);

            appointmentsData.Columns["Id"].Visible = false;
            appointmentsData.Columns["Patient"].Visible = false;
            appointmentsData.Columns["Doctor"].Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static async void HandleAppointmentClick(DataGridViewCellEventArgs e, DataGridView appointmentsData, AppointmentsService appointmentsService, PatientsService patientsService, DoctorsService doctorsService)
    {
        if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

        var appointmentId = (Guid)appointmentsData.Rows[e.RowIndex].Cells["Id"].Value;

        if (appointmentsData.Columns[e.ColumnIndex].Name == "SeeAppointmentButton")
        {
            var appointment = await appointmentsService.GetAppointmentById(appointmentId);
            var appointmentDetailsForm = new AppointmentDetailsForm(appointment, appointmentsService, patientsService, doctorsService);
            appointmentDetailsForm.ShowDialog();
        }

        if (appointmentsData.Columns[e.ColumnIndex].Name == "DeleteAppointmentButton")
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirm Deletion",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.No) return;

            try
            {
                await appointmentsService.RemoveAppointment(appointmentId);
                await LoadAppointments(appointmentsData, appointmentsService);
                MessageBox.Show("Appointment removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public static async Task LoadDoctorsForAppointments(ComboBox doctorComboBox, DoctorsService doctorsService)
    {
        try
        {
            var doctors = await doctorsService.GetDoctors();

            doctorComboBox.Items.Clear();

            foreach (var doctor in doctors)
            {
                doctorComboBox.Items.Add(new KeyValuePair<Guid, string>(doctor.Id, doctor.Name));
            }

            doctorComboBox.DisplayMember = "Value";
            doctorComboBox.ValueMember = "Key";

            if (doctorComboBox.Items.Count > 0) doctorComboBox.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static async Task LoadPatientsForAppointments(ComboBox patientComboBox, PatientsService patientsService)
    {
        try
        {
            var patients = await patientsService.GetPatients();

            patientComboBox.Items.Clear();

            foreach (var patient in patients)
            {
                patientComboBox.Items.Add(new KeyValuePair<Guid, string>(patient.Id, patient.Name));
            }

            patientComboBox.DisplayMember = "Value";
            patientComboBox.ValueMember = "Key";

            if (patientComboBox.Items.Count > 0) patientComboBox.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static void SeeDoctorAppointments(ComboBox doctorComboBox, AppointmentsService appointmentsService)
    {
        if (doctorComboBox.SelectedItem == null)
        {
            MessageBox.Show("Please select a doctor to see their appointments.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var selectedDoctor = (KeyValuePair<Guid, string>)doctorComboBox.SelectedItem;
        var doctorId = selectedDoctor.Key;

        var appointmentsByDoctorForm = new AppointmentsByDoctorForm(doctorId, appointmentsService);
        appointmentsByDoctorForm.ShowDialog();
    }

    public static void SeePatientAppointments(ComboBox patientComboBox, AppointmentsService appointmentsService)
    {
        if (patientComboBox.SelectedItem == null)
        {
            MessageBox.Show("Please select a patient to see their appointments.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var selectedPatient = (KeyValuePair<Guid, string>)patientComboBox.SelectedItem;
        var patientId = selectedPatient.Key;

        var appointmentsByPatientForm = new AppointmentsByPatientForm(patientId, appointmentsService);
        appointmentsByPatientForm.ShowDialog();
    }
}
