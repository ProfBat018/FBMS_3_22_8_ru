namespace ButtonExample;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        button1 = new Button();
        SuspendLayout();
        // 
        // button1
        // 
        button1.BackColor = Color.LawnGreen;
        button1.Location = new Point(416, 252);
        button1.Name = "button1";
        button1.Size = new Size(94, 29);
        button1.TabIndex = 0;
        button1.Text = "Click me";
        button1.UseVisualStyleBackColor = false;
        button1.Click += button1_Click;
        button1.Enter += button1_Enter;
        button1.Leave += button1_Leave;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1022, 566);
        Controls.Add(button1);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
    }

    #endregion

    private Button button1;
}