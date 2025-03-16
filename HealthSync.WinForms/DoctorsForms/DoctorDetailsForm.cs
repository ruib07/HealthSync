using HealthSync.Domain.Entities;
using HealthSync.WinForms.Helper;

namespace HealthSync.WinForms.DoctorsForms;

public partial class DoctorDetailsForm : Form
{
    private readonly Doctors _doctor;

    public DoctorDetailsForm(Doctors doctor)
    {
        InitializeComponent();
        this.Resize += ResizeEvent;

        _doctor = doctor;
        LoadDoctorDetails();
    }

    private void DoctorDetailsForm_Load(object sender, EventArgs e)
    {
        UIHelper.AlignFormInputs(this,
           new List<Label> { DoctorNameLabel, DoctorEmailLabel, DoctorSpecializationLabel, DoctorPhoneNumberLabel, DoctorLicenseNumberLabel },
           new List<Control> { DoctorNameValue, DoctorEmailValue, DoctorSpecializationValue, DoctorPhoneNumberValue, DoctorLicenseNumberValue },
           startY: 200,
           spacing: 60
        );
    }

    private void ResizeEvent(object sender, EventArgs e)
    {
        UIHelper.CenterTitleLabels(this, DoctorDetailsTitle);
    }

    private void LoadDoctorDetails()
    {
        DoctorNameValue.Text = _doctor.Name;
        DoctorEmailValue.Text = _doctor.Email;
        DoctorSpecializationValue.Text = _doctor.Specialization;
        DoctorPhoneNumberValue.Text = _doctor.PhoneNumber;
        DoctorLicenseNumberValue.Text = _doctor.LicenseNumber;
    }
}
