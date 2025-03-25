using HealthSync.Domain.Entities;
using HealthSync.WinForms.Services;

namespace HealthSync.WinForms.MedicalRecordsForms;

public partial class MedicalRecordsByPatientForm : Form
{
    private readonly Guid _patientId;
    private readonly MedicalRecordsService _medicalRecordsService;

    public MedicalRecordsByPatientForm(Guid patientId, MedicalRecordsService medicalRecordsService)
    {
        InitializeComponent();
        _patientId = patientId;
        _medicalRecordsService = medicalRecordsService;
    }

    private async void MedicalRecordsByPatientForm_Load(object sender, EventArgs e)
    {
        await LoadPatientMedicalRecords();
    }

    private async Task LoadPatientMedicalRecords()
    {
        try
        {
            var patientMedicalRecords = await _medicalRecordsService.GetMedicalRecordsByPatientId(_patientId);

            MedicalRecordsData.DataSource = new List<MedicalRecords>(patientMedicalRecords);

            MedicalRecordsData.Columns["Id"].Visible = false;
            MedicalRecordsData.Columns["Patient"].Visible = false;
            MedicalRecordsData.Columns["Doctor"].Visible = false;
            MedicalRecordsData.Columns["PatientId"].Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
