using HealthSync.Domain.Entities;
using HealthSync.WinForms.Helper;

namespace HealthSync.WinForms.PatientsForms;

public partial class PatientDetailsForm : Form
{
    private readonly Patients _patient;

    public PatientDetailsForm(Patients patient)
    {
        InitializeComponent();
        this.Resize += ResizeEvent;

        _patient = patient;
        LoadPatientDetails();
    }

    private void PatientDetailsForm_Load(object sender, EventArgs e)
    {
        UIHelper.AlignFormInputs(this, 
            new List<Label> { PatientNameLabel, PatientEmailLabel, PatientDateOfBirthLabel, PatientPhoneNumberLabel, PatientAddressLabel },
            new List<Control> { PatientNameValue, PatientEmailValue, PatientDateOfBirthValue, PatientPhoneNumberValue, PatientAddressValue },
            startY: 200,
            spacing: 60
        );
    }

    private void ResizeEvent(object sender, EventArgs e)
    {
        UIHelper.CenterTitleLabels(this, PatientDetailsTitle);
    }

    private void LoadPatientDetails()
    {
        PatientNameValue.Text = _patient.Name;
        PatientEmailValue.Text = _patient.Email;
        PatientDateOfBirthValue.Text = _patient.DateOfBirth.ToString();
        PatientPhoneNumberValue.Text = _patient.PhoneNumber;
        PatientAddressValue.Text = _patient.Address;
    }
}
