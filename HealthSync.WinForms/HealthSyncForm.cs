using HealthSync.Domain.Entities;
using HealthSync.WinForms.Services;

namespace HealthSync.WinForms
{
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

            HomeTab.TabPages.Add(new TabPage("Exit"));

            _patientsService = patientsService;
            _doctorsService = doctorsService;
            _appointmentsService = appointmentsService;
            _medicalRecordsService = medicalRecordsService;
        }

        private void HealthSyncForm_Load(object sender, EventArgs e)
        {
            CenterDataGridView(PatientsData);
            CenterDataGridView(DoctorsData);
            CenterDataGridView(AppointmentsData);
            CenterDataGridView(MedicalRecordsData);
        }

        private async void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (HomeTab.SelectedTab == PatientsTab) await LoadPatients();
            if (HomeTab.SelectedTab == DoctorsTab) await LoadDoctors();
            if (HomeTab.SelectedTab == AppointmentsTab) await LoadAppointments();
            if (HomeTab.SelectedTab == MedicalRecordsTab) await LoadMedicalRecords();
            if (HomeTab.SelectedTab.Text == "Exit")
            {
                DialogResult result = MessageBox.Show("Are you sure that you want to exit from the application?",
                                                        "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                else
                {
                    HomeTab.SelectedTab = PatientsTab;
                }
            }
        }

        #region Patients

        private async Task LoadPatients()
        {
            try
            {
                var patients = await _patientsService.GetPatients();
                PatientsData.DataSource = new List<Patients>(patients);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void CenterDataGridView(DataGridView dataGridView)
        {
            int x = (this.ClientSize.Width - dataGridView.Width) / 2;
            int y = (this.ClientSize.Height - dataGridView.Height) / 2;
            dataGridView.Location = new Point(x, y);
        }
    }
}
