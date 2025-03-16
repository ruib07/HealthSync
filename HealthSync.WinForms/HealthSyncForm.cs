using HealthSync.Domain.Entities;
using HealthSync.WinForms.AppointmentsForms;
using HealthSync.WinForms.DoctorsForms;
using HealthSync.WinForms.Helper;
using HealthSync.WinForms.MedicalRecordsForms;
using HealthSync.WinForms.PatientsForms;
using HealthSync.WinForms.Services;

namespace HealthSync.WinForms;

public partial class HealthSyncForm : Form
{
    private readonly PatientsService _patientsService;
    private readonly DoctorsService _doctorsService;
    private readonly AppointmentsService _appointmentsService;
    private readonly MedicalRecordsService _medicalRecordsService;

    public HealthSyncForm(PatientsService patientsService, DoctorsService doctorsService,
                            AppointmentsService appointmentsService, MedicalRecordsService medicalRecordsService)
    {
        InitializeComponent();
        this.Resize += ResizeEvent;

        PatientsData.CellContentClick += PatientsData_CellContentClick;
        DoctorsData.CellContentClick += DoctorsData_CellContentClick;
        AppointmentsData.CellContentClick += AppointmentsData_CellContentClick;
        MedicalRecordsData.CellContentClick += MedicalRecordsData_CellContentClick;

        _patientsService = patientsService;
        _doctorsService = doctorsService;
        _appointmentsService = appointmentsService;
        _medicalRecordsService = medicalRecordsService;
    }

    private void HealthSyncForm_Load(object sender, EventArgs e)
    {
        UIHelper.CenterDataGridView(this, PatientsData);
        UIHelper.CenterDataGridView(this, DoctorsData);
        UIHelper.CenterDataGridView(this, AppointmentsData);
        UIHelper.CenterDataGridView(this, MedicalRecordsData);
    }

    private void ResizeEvent(object sender, EventArgs e)
    {
        UIHelper.CenterTitleLabels(this, PatientsTitle);
        UIHelper.CenterTitleLabels(this, DoctorsTitle);
        UIHelper.CenterTitleLabels(this, AppointmentsTitle);
        UIHelper.CenterTitleLabels(this, MedicalRecordsTitle);

        UIHelper.CenterCreateButton(this, CreatePatientButton);
        UIHelper.CenterCreateButton(this, CreateDoctorButton);
        UIHelper.CenterCreateButton(this, CreateAppointmentButton);
        UIHelper.CenterCreateButton(this, CreateMedicalRecordButton);
    }

    private async void TabControl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (HomeTab.SelectedTab == PatientsTab) await LoadPatients();
        if (HomeTab.SelectedTab == DoctorsTab) await LoadDoctors();
        if (HomeTab.SelectedTab == AppointmentsTab) await LoadAppointments();
        if (HomeTab.SelectedTab == MedicalRecordsTab) await LoadMedicalRecords();
        if (HomeTab.SelectedTab == ExitTab) ExitButton_Click(sender, e);
    }

    #region Patients

    private async Task LoadPatients()
    {
        try
        {
            var patients = await _patientsService.GetPatients();
            PatientsData.DataSource = new List<Patients>(patients);

            PatientsData.Columns["Id"].Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void CreatePatientButton_Click(object sender, EventArgs e)
    {
        var addPatientForm = new AddPatientForm(_patientsService);
        addPatientForm.ShowDialog();

        await LoadPatients();
    }

    private async void PatientsData_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

        var patientId = (Guid)PatientsData.Rows[e.RowIndex].Cells["Id"].Value;

        if (PatientsData.Columns[e.ColumnIndex] == SeePatientButton)
        {
            var patient = await _patientsService.GetPatientById(patientId);
            var patientDetailsForm = new PatientDetailsForm(patient);
            patientDetailsForm.ShowDialog();
        }

        if (PatientsData.Columns[e.ColumnIndex] == DeletePatientButton)
        {

            var confirmResult = MessageBox.Show("Are you sure you want to delete this patient?", "Confirm Deletion", 
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    await _patientsService.RemovePatient(patientId);

                    await LoadPatients();

                    MessageBox.Show("Patient removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting patient: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    #endregion

    #region Doctors

    private async Task LoadDoctors()
    {
        try
        {
            var doctors = await _doctorsService.GetDoctors();
            DoctorsData.DataSource = new List<Doctors>(doctors);

            DoctorsData.Columns["Id"].Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void CreateDoctorButton_Click(object sender, EventArgs e)
    {
        var addDoctorForm = new AddDoctorForm(_doctorsService);
        addDoctorForm.ShowDialog();

        await LoadDoctors();
    }

    private async void DoctorsData_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

        var doctorId = (Guid)DoctorsData.Rows[e.RowIndex].Cells["Id"].Value;

        if (DoctorsData.Columns[e.ColumnIndex] == SeeDoctorButton)
        {
            var doctor = await _doctorsService.GetDoctorById(doctorId);
            var doctorDetailsForm = new DoctorDetailsForm(doctor);
            doctorDetailsForm.ShowDialog();
        }

        if (DoctorsData.Columns[e.ColumnIndex] == DeleteDoctorButton)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this doctor?", "Confirm Deletion",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    await _doctorsService.RemoveDoctor(doctorId);

                    await LoadDoctors();

                    MessageBox.Show("Doctor removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting doctor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    #endregion

    #region Appointments

    private async Task LoadAppointments()
    {
        try
        {
            var appointments = await _appointmentsService.GetAppointments();
            AppointmentsData.DataSource = new List<Appointments>(appointments);

            AppointmentsData.Columns["Id"].Visible = false;
            AppointmentsData.Columns["Patient"].Visible = false;
            AppointmentsData.Columns["Doctor"].Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void CreateAppointmentButton_Click(object sender, EventArgs e)
    {
        var addAppointmentForm = new AddAppointmentForm(_appointmentsService, _patientsService, _doctorsService);
        addAppointmentForm.ShowDialog();

        await LoadAppointments();
    }

    private async void AppointmentsData_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

        var appointmentId = (Guid)AppointmentsData.Rows[e.RowIndex].Cells["Id"].Value;

        if (AppointmentsData.Columns[e.ColumnIndex] == SeeAppointmentButton)
        {
            var appointment = await _appointmentsService.GetAppointmentById(appointmentId);
            var appointmentDetailsForm = new AppointmentDetailsForm(appointment);
            appointmentDetailsForm.ShowDialog();
        }

        if (AppointmentsData.Columns[e.ColumnIndex] == DeleteAppointmentButton)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirm Deletion",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    await _appointmentsService.RemoveAppointment(appointmentId);

                    await LoadAppointments();

                    MessageBox.Show("Appointment removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting appointment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    #endregion

    #region Medical Records

    private async Task LoadMedicalRecords()
    {
        try
        {
            var medicalRecords = await _medicalRecordsService.GetMedicalRecords();
            MedicalRecordsData.DataSource = new List<MedicalRecords>(medicalRecords);

            MedicalRecordsData.Columns["Id"].Visible = false;
            MedicalRecordsData.Columns["Patient"].Visible = false;
            MedicalRecordsData.Columns["Doctor"].Visible = false;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void CreateMedicalRecordButton_Click(object sender, EventArgs e)
    {
        var addMedicalRecordForm = new AddMedicalRecordForm(_medicalRecordsService, _patientsService, _doctorsService);
        addMedicalRecordForm.ShowDialog();

        await LoadMedicalRecords();
    }

    private async void MedicalRecordsData_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.ColumnIndex < 0 || e.RowIndex < 0) return;

        var medicalRecordId = (Guid)MedicalRecordsData.Rows[e.RowIndex].Cells["Id"].Value;

        if (MedicalRecordsData.Columns[e.ColumnIndex] == SeeMedicalRecordButton)
        {
            var medicalRecord = await _medicalRecordsService.GetMedicalRecordById(medicalRecordId);
            var medRecordDetailsForm = new MedicalRecordDetailsForm(medicalRecord);
            medRecordDetailsForm.ShowDialog();
        }

        if (MedicalRecordsData.Columns[e.ColumnIndex] == DeleteMedicalRecordButton)
        {
            var confirmResult = MessageBox.Show("Are you sure you want to delete this medical record?", "Confirm Deletion",
                                                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    await _medicalRecordsService.RemoveMedicalRecord(medicalRecordId);

                    await LoadMedicalRecords();

                    MessageBox.Show("Medical record removed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting medical record: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    #endregion

    #region Exit Application Event

    private void ExitButton_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("Are you sure that you want to exit from the application?",
                                        "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result == DialogResult.Yes) Application.Exit();

        else HomeTab.SelectedTab = PatientsTab;
    }

    #endregion
}
