using HealthSync.Domain.Entities;
using HealthSync.WinForms.Helper;
using HealthSync.WinForms.Services;

namespace HealthSync.WinForms.MedicalRecordsForms;

public partial class MedicalRecordDetailsForm : Form
{
    private readonly MedicalRecords _medicalRecord;
    private readonly MedicalRecordsService _medicalRecordsService;

    public MedicalRecordDetailsForm(MedicalRecords medicalRecord, MedicalRecordsService medicalRecordsService)
    {
        InitializeComponent();
        this.Resize += ResizeEvent;

        _medicalRecord = medicalRecord;
        _medicalRecordsService = medicalRecordsService;
        LoadMedicalRecordDetails();
    }

    private void MedicalRecordDetailsForm_Load(object sender, EventArgs e)
    {
        UIHelper.AlignFormInputs(this,
           new List<Label>() { PatientLabel, DoctorLabel, MedRecordDiagnosisLabel, MedRecordPrescriptionLabel, MedRecordDateLabel },
           new List<Control>() { MedRecordPatientValue, MedRecordDoctorValue, MedRecordDiagnosisValue, MedRecordPrescriptionValue, MedRecordDateValue },
           startY: 200,
           spacing: 60
        );

        ToggleEditMode(false);
    }

    private void ResizeEvent(object sender, EventArgs e)
    {
        UIHelper.CenterTitleLabels(this, MedicalRecordDetailsTitle);
    }

    private void LoadMedicalRecordDetails()
    {
        MedRecordDoctorValue.Text = _medicalRecord.DoctorId.ToString();
        MedRecordPatientValue.Text = _medicalRecord.PatientId.ToString();
        MedRecordDiagnosisValue.Text = _medicalRecord.Diagnosis;
        MedRecordPrescriptionValue.Text = _medicalRecord.Prescription;
        MedRecordDateValue.Value = _medicalRecord.RecordDate;
    }

    private void EditMedicalRecordButton_Click(object sender, EventArgs e)
    {
        ToggleEditMode(true);
    }

    private async void SaveMedicalRecordButton_Click(object sender, EventArgs e)
    {
        try
        {
            var updatedMedicalRecord = new MedicalRecords()
            {
                Id = _medicalRecord.Id,
                DoctorId = Guid.Parse(MedRecordDoctorValue.Text),
                PatientId = Guid.Parse(MedRecordPatientValue.Text),
                Diagnosis = MedRecordDiagnosisValue.Text,
                Prescription = MedRecordPrescriptionValue.Text,
                RecordDate = MedRecordDateValue.Value
            };

            await _medicalRecordsService.EditMedicalRecord(_medicalRecord.Id, updatedMedicalRecord);

            _medicalRecord.DoctorId = updatedMedicalRecord.DoctorId;
            _medicalRecord.PatientId = updatedMedicalRecord.PatientId;
            _medicalRecord.Diagnosis = updatedMedicalRecord.Diagnosis;
            _medicalRecord.Prescription = updatedMedicalRecord.Prescription;
            _medicalRecord.RecordDate = updatedMedicalRecord.RecordDate;

            MessageBox.Show("Medical Record details updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            MedRecordDoctorValue, MedRecordPatientValue, MedRecordDiagnosisValue, MedRecordPrescriptionValue, MedRecordDateValue
        }, EditMedicalRecordButton, SaveMedicalRecordButton);
    }
}
