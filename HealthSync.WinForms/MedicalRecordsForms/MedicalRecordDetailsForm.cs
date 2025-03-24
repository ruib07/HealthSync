using HealthSync.Domain.Entities;
using HealthSync.WinForms.Helper;
using HealthSync.WinForms.Services;

namespace HealthSync.WinForms.MedicalRecordsForms;

public partial class MedicalRecordDetailsForm : Form
{
    private readonly MedicalRecords _medicalRecord;
    private readonly MedicalRecordsService _medicalRecordsService;
    private readonly PatientsService _patientsService;
    private readonly DoctorsService _doctorsService;

    public MedicalRecordDetailsForm(MedicalRecords medicalRecord, MedicalRecordsService medicalRecordsService, PatientsService patientsService, DoctorsService doctorsService)
    {
        InitializeComponent();
        this.Resize += ResizeEvent;

        _medicalRecord = medicalRecord;
        _medicalRecordsService = medicalRecordsService;
        _patientsService = patientsService;
        _doctorsService = doctorsService;
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

    private async void LoadMedicalRecordDetails()
    {
        var doctors = await _doctorsService.GetDoctors();
        var patients = await _patientsService.GetPatients();

        MedRecordDoctorValue.DataSource = doctors.ToList();
        MedRecordDoctorValue.DisplayMember = "Name";
        MedRecordDoctorValue.ValueMember = "Id";

        MedRecordPatientValue.DataSource = patients.ToList();
        MedRecordPatientValue.DisplayMember = "Name";
        MedRecordPatientValue.ValueMember = "Id";

        MedRecordDoctorValue.SelectedValue = _medicalRecord.DoctorId;
        MedRecordPatientValue.SelectedValue = _medicalRecord.PatientId;
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
                DoctorId = (Guid)MedRecordDoctorValue.SelectedValue,
                PatientId = (Guid)MedRecordPatientValue.SelectedValue,
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
