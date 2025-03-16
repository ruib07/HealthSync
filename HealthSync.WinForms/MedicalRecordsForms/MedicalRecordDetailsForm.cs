using HealthSync.Domain.Entities;
using HealthSync.WinForms.Helper;

namespace HealthSync.WinForms.MedicalRecordsForms;

public partial class MedicalRecordDetailsForm : Form
{
    private readonly MedicalRecords _medicalRecord;

    public MedicalRecordDetailsForm(MedicalRecords medicalRecord)
    {
        InitializeComponent();
        this.Resize += ResizeEvent;

        _medicalRecord = medicalRecord;
        LoadMedicalRecordDetails();
    }

    private void MedicalRecordDetailsForm_Load(object sender, EventArgs e)
    {
        UIHelper.AlignFormInputs(this,
           new List<Label> { PatientLabel, DoctorLabel, MedRecordDiagnosisLabel, MedRecordPrescriptionLabel, MedRecordDateLabel },
           new List<Control> { MedRecordPatientValue, MedRecordDoctorValue, MedRecordDiagnosisValue, MedRecordPrescriptionValue, MedRecordDateValue },
           startY: 200,
           spacing: 60
        );
    }

    private void ResizeEvent(object sender, EventArgs e)
    {
        UIHelper.CenterTitleLabels(this, MedicalRecordDetailsTitle);
    }

    private void LoadMedicalRecordDetails()
    {
        MedRecordDoctorValue.Text = _medicalRecord.DoctorId.ToString();
        MedRecordPatientValue.Text = _medicalRecord.PatientId.ToString();
        MedRecordDiagnosisLabel.Text = _medicalRecord.Diagnosis;
        MedRecordPrescriptionValue.Text = _medicalRecord.Prescription;
        MedRecordDateValue.Value = _medicalRecord.RecordDate;
    }
}
