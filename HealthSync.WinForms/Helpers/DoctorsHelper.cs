using HealthSync.Domain.Entities;
using HealthSync.WinForms.DoctorsForms;
using HealthSync.WinForms.Services;

namespace HealthSync.WinForms.Helpers;

public static class DoctorsHelper
{
    public static async Task LoadDoctors(DataGridView doctorsData, DoctorsService doctorsService)
    {
        try
        {
            var doctors = await doctorsService.GetDoctors();
            doctorsData.DataSource = new List<Doctors>(doctors);
            doctorsData.Columns["Id"].Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static async void HandleDoctorClick(DataGridViewCellEventArgs e, DataGridView doctorsData, DoctorsService doctorsService)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

        var doctorId = (Guid)doctorsData.Rows[e.RowIndex].Cells["Id"].Value;

        if (doctorsData.Columns[e.ColumnIndex].Name == "SeeDoctorButton")
        {
            var doctor = await doctorsService.GetDoctorById(doctorId);
            var doctorDetailsForm = new DoctorDetailsForm(doctor, doctorsService);
            doctorDetailsForm.ShowDialog();
        }

        if (doctorsData.Columns[e.ColumnIndex].Name == "DeleteDoctorButton")
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this doctor?", "Confirm Deletion",
                                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.No) return;

            try
            {
                await doctorsService.RemoveDoctor(doctorId);
                await LoadDoctors(doctorsData, doctorsService);
                MessageBox.Show("Doctor removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting doctor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
