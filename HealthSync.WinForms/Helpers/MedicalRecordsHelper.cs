using HealthSync.Domain.Entities;
using HealthSync.WinForms.MedicalRecordsForms;
using HealthSync.WinForms.Services;

namespace HealthSync.WinForms.Helpers;

public static class MedicalRecordsHelper
{
    public static async Task LoadMedicalRecords(DataGridView medicalRecordsData, MedicalRecordsService medicalRecordsService)
    {
        try
        {
            var medicalRecords = await medicalRecordsService.GetMedicalRecords();
            medicalRecordsData.DataSource = new List<MedicalRecords>(medicalRecords);

            medicalRecordsData.Columns["Id"].Visible = false;
            medicalRecordsData.Columns["Patient"].Visible = false;
            medicalRecordsData.Columns["Doctor"].Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    public static async void HandleMedicalRecordClick(DataGridViewCellEventArgs e, DataGridView medicalRecordsData, MedicalRecordsService medicalRecordsService, PatientsService patientsService, DoctorsService doctorsService)
    {
        if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

        var medicalRecordId = (Guid)medicalRecordsData.Rows[e.RowIndex].Cells["Id"].Value;

        if (medicalRecordsData.Columns[e.ColumnIndex].Name == "SeeMedicalRecordButton")
        {
            var medicalRecord = await medicalRecordsService.GetMedicalRecordById(medicalRecordId);
            var medRecordDetailsForm = new MedicalRecordDetailsForm(medicalRecord, medicalRecordsService, patientsService, doctorsService);
            medRecordDetailsForm.ShowDialog();
        }

        if (medicalRecordsData.Columns[e.ColumnIndex].Name == "DeleteMedicalRecordButton")
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this medical record?", "Confirm Deletion",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.No) return;

            try
            {
                await medicalRecordsService.RemoveMedicalRecord(medicalRecordId);
                await LoadMedicalRecords(medicalRecordsData, medicalRecordsService);
                MessageBox.Show("Medical record removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting medical record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public static async Task LoadPatientsForMedicalRecords(ComboBox patientComboBox, PatientsService patientsService)
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

    public static void SeePatientMedicalRecords(ComboBox patientComboBox, MedicalRecordsService medicalRecordsService)
    {
        if (patientComboBox.SelectedItem == null)
        {
            MessageBox.Show("Please select a patient to see their medical records.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        var selectedPatient = (KeyValuePair<Guid, string>)patientComboBox.SelectedItem;
        var patientId = selectedPatient.Key;

        var medRecordsByPatientForm = new MedicalRecordsByPatientForm(patientId, medicalRecordsService);
        medRecordsByPatientForm.ShowDialog();
    }
}
