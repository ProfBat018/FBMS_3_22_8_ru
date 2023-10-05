namespace Lesson1
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            clickmeButton = new Button();
            counterLabel = new Label();
            SuspendLayout();
            // 
            // clickmeButton
            // 
            clickmeButton.Location = new Point(323, 236);
            clickmeButton.Name = "clickmeButton";
            clickmeButton.Size = new Size(169, 54);
            clickmeButton.TabIndex = 0;
            clickmeButton.Text = "Click Me Please";
            clickmeButton.UseVisualStyleBackColor = true;
            clickmeButton.Click += clickmeButton_Click;
            // 
            // counterLabel
            // 
            counterLabel.AutoSize = true;
            counterLabel.Location = new Point(336, 94);
            counterLabel.Name = "counterLabel";
            counterLabel.Size = new Size(17, 20);
            counterLabel.TabIndex = 1;
            counterLabel.Text = "0";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(counterLabel);
            Controls.Add(clickmeButton);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button clickmeButton;
        private Label counterLabel;
    }
}