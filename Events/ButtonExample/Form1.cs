namespace ButtonExample;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var args = (e as MouseEventArgs);
        MessageBox.Show($"You clicked at {args.X}, {args.Y}");
        MessageBox.Show($"You clicked: {args.Button}");

    }

    private void button1_Enter(object sender, EventArgs e)
    {
        MessageBox.Show("Enter");
    }

    private void button1_Leave(object sender, EventArgs e)
    {
        MessageBox.Show("Leave");
    }
}