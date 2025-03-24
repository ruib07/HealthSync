namespace HealthSync.WinForms.Helper;

public static class UIHelper
{
    public static void CenterDataGridView(Form form, DataGridView dataGridView)
    {
        int x = (form.ClientSize.Width - dataGridView.Width) / 2;
        int y = (form.ClientSize.Height - dataGridView.Height) / 2;
        dataGridView.Location = new Point(x, y);
    }

    public static void CenterTitleLabels(Form form, Label label)
    {
        int centerX = (form.ClientSize.Width - label.Width) / 2;
        label.Location = new Point(centerX, label.Location.Y);
    }

    public static void CenterCreateButton(Form form, Button button)
    {
        int centerX = (form.ClientSize.Width - button.Width) / 2;
        button.Location = new Point(centerX, button.Location.Y);
    }

    public static void AlignFormInputs(Form form, List<Label> labels, List<Control> inputs, int startY, int spacing)
    {
        int centerX = form.ClientSize.Width / 2;
        int labelOffset = -200;

        for (int i = 0; i < labels.Count; i++)
        {
            if (i < inputs.Count)
            {
                labels[i].Location = new Point(centerX + labelOffset, startY + (i * spacing));
                inputs[i].Location = new Point(centerX, startY + (i * spacing));
            }
        }
    }

    public static void ToggleEditMode(Form form, bool enable, List<Control> inputFields, Button editButton, Button saveButton)
    {
        foreach (var field in inputFields)
        {
            if (field is TextBox textBox) textBox.ReadOnly = !enable;
            if (field is ComboBox comboBox) comboBox.Enabled = enable;
            if (field is DateTimePicker dateTimePicker) dateTimePicker.Enabled = enable;
        }
        
        editButton.Visible = !enable;
        saveButton.Visible = enable;
    }
}
