using HealthSync.Domain.Entities;
using HealthSync.WinForms.Helpers;
using HealthSync.WinForms.Services;

namespace HealthSync.WinForms.MedicalRecordsForms;

public partial class AddMedicalRecordForm : Form
{
    private readonly MedicalRecordsService _medicalRecordsService;
    private readonly PatientsService _patientsService;
    private readonly DoctorsService _doctorsService;

    public AddMedicalRecordForm(MedicalRecordsService medicalRecordsService, PatientsService patientsService, DoctorsService doctorsService)
    {
        InitializeComponent();
        this.Resize += ResizeEvent;

        _medicalRecordsService = medicalRecordsService;
        _patientsService = patientsService;
        _doctorsService = doctorsService;
    }

    private async void AddMedicalRecordForm_Load(object sender, EventArgs e)
    {
        var patients = await _patientsService.GetPatients();
        PatientsDropdown.DataSource = patients.ToList();
        PatientsDropdown.DisplayMember = "Name";
        PatientsDropdown.ValueMember = "Id";

        var doctors = await _doctorsService.GetDoctors();
        DoctorsDropdown.DataSource = doctors.ToList();
        DoctorsDropdown.DisplayMember = "Name";
        DoctorsDropdown.ValueMember = "Id";
    }

    private void ResizeEvent(object sender, EventArgs e)
    {
        UIHelper.CenterTitleLabels(this, CreateMedicalRecordTitle);
        UIHelper.CenterCreateButton(this, AddMedicalRecordButton);
    }

    private async void AddMedicalRecordButton_Click(object sender, EventArgs e)
    {
        try
        {
            var selectedPatient = (Patients)PatientsDropdown.SelectedItem;
            var selectedDoctor = (Doctors)DoctorsDropdown.SelectedItem;

            var newMedicalRecord = new MedicalRecords()
            {
                PatientId = selectedPatient.Id,
                DoctorId = selectedDoctor.Id,
                Diagnosis = MedicalRecordDiagnosis.Text,
                Prescription = MedicalRecordPrescription.Text,
                RecordDate = RecordDate.Value
            };

            var createdAppointment = await _medicalRecordsService.CreateMedicalRecord(newMedicalRecord);

            MessageBox.Show($"Medical Record {createdAppointment.Id} created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error creating medical record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
