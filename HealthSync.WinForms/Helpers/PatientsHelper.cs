using HealthSync.Domain.Entities;
using HealthSync.WinForms.PatientsForms;
using HealthSync.WinForms.Services;

namespace HealthSync.WinForms.Helpers;

public static class PatientsHelper
{
    public static async Task LoadPatients(DataGridView patientsData, PatientsService patientsService)
    {
        try
        {
            var patients = await patientsService.GetPatients();
            patientsData.DataSource = new List<Patients>(patients);
            patientsData.Columns["Id"].Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static async void HandlePatientClick(DataGridViewCellEventArgs e, DataGridView patientsData, PatientsService patientsService)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

        var patientId = (Guid)patientsData.Rows[e.RowIndex].Cells["Id"].Value;

        if (patientsData.Columns[e.ColumnIndex].Name == "SeePatientButton")
        {
            var patient = await patientsService.GetPatientById(patientId);
            var patientDetailsForm = new PatientDetailsForm(patient, patientsService);
            patientDetailsForm.ShowDialog();
        }

        if (patientsData.Columns[e.ColumnIndex].Name == "DeletePatientButton")
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this patient?", "Confirm Deletion",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.No) return;

            try
            {
                await patientsService.RemovePatient(patientId);
                await LoadPatients(patientsData, patientsService);
                MessageBox.Show("Patient removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting patient: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
