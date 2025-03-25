using HealthSync.WinForms.AppointmentsForms;
using HealthSync.WinForms.DoctorsForms;
using HealthSync.WinForms.Helpers;
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
        if (HomeTab.SelectedTab == PatientsTab) await PatientsHelper.LoadPatients(PatientsData, _patientsService);
        if (HomeTab.SelectedTab == DoctorsTab) await DoctorsHelper.LoadDoctors(DoctorsData, _doctorsService);
        if (HomeTab.SelectedTab == AppointmentsTab) await AppointmentsHelper.LoadAppointments(AppointmentsData, _appointmentsService);;
        if (HomeTab.SelectedTab == AppointmentsDoctorTab) await AppointmentsHelper.LoadDoctorsForAppointments(DoctorSelectedValue, _doctorsService);
        if (HomeTab.SelectedTab == AppointmentsPatientTab) await AppointmentsHelper.LoadPatientsForAppointments(PatientSelectedValue, _patientsService);
        if (HomeTab.SelectedTab == MedicalRecordsTab) await MedicalRecordsHelper.LoadMedicalRecords(MedicalRecordsData, _medicalRecordsService);
        if (HomeTab.SelectedTab == MedRecordsPatientTab) await MedicalRecordsHelper.LoadPatientsForMedicalRecords(MedRecPatientSelectedValue, _patientsService);
        if (HomeTab.SelectedTab == ExitTab) ExitButton_Click(sender, e);
    }

    #region Patients

    private async void CreatePatientButton_Click(object sender, EventArgs e)
    {
        var addPatientForm = new AddPatientForm(_patientsService);
        addPatientForm.ShowDialog();

        await PatientsHelper.LoadPatients(PatientsData, _patientsService);
    }

    private void PatientsData_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        PatientsHelper.HandlePatientClick(e, PatientsData, _patientsService);
    }

    #endregion

    #region Doctors

    private async void CreateDoctorButton_Click(object sender, EventArgs e)
    {
        var addDoctorForm = new AddDoctorForm(_doctorsService);
        addDoctorForm.ShowDialog();

        await DoctorsHelper.LoadDoctors(DoctorsData, _doctorsService);
    }

    private void DoctorsData_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        DoctorsHelper.HandleDoctorClick(e, DoctorsData, _doctorsService);
    }

    #endregion

    #region Appointments

    private async void CreateAppointmentButton_Click(object sender, EventArgs e)
    {
        var addAppointmentForm = new AddAppointmentForm(_appointmentsService, _patientsService, _doctorsService);
        addAppointmentForm.ShowDialog();

        await AppointmentsHelper.LoadAppointments(AppointmentsData, _appointmentsService);
    }

    private void AppointmentsData_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        AppointmentsHelper.HandleAppointmentClick(e, AppointmentsData, _appointmentsService, _patientsService, _doctorsService);
    }

    private void SeeDoctorAppointmentsButton_Click(object sender, EventArgs e)
    {
        AppointmentsHelper.SeeDoctorAppointments(DoctorSelectedValue, _appointmentsService);
    }

    private void SeePatientAppointmentsButton_Click(object sender, EventArgs e)
    {
        AppointmentsHelper.SeePatientAppointments(PatientSelectedValue, _appointmentsService);
    }

    #endregion

    #region Medical Records

    private async void CreateMedicalRecordButton_Click(object sender, EventArgs e)
    {
        var addMedicalRecordForm = new AddMedicalRecordForm(_medicalRecordsService, _patientsService, _doctorsService);
        addMedicalRecordForm.ShowDialog();

        await MedicalRecordsHelper.LoadMedicalRecords(MedicalRecordsData, _medicalRecordsService);
    }

    private void MedicalRecordsData_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        MedicalRecordsHelper.HandleMedicalRecordClick(e, MedicalRecordsData, _medicalRecordsService, _patientsService, _doctorsService);
    }

    private void SeePatientMedRecordsButton_Click(object sender, EventArgs e)
    {
        MedicalRecordsHelper.SeePatientMedicalRecords(MedRecPatientSelectedValue, _medicalRecordsService);
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
