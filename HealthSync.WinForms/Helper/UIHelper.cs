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
}
