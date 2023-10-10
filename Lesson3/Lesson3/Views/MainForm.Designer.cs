namespace Lesson3.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            taskslistBox = new ListBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            headingLabel = new Label();
            addButton = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // taskslistBox
            // 
            tableLayoutPanel1.SetColumnSpan(taskslistBox, 2);
            taskslistBox.Dock = DockStyle.Fill;
            taskslistBox.FormattingEnabled = true;
            taskslistBox.ItemHeight = 20;
            taskslistBox.Location = new Point(3, 172);
            taskslistBox.Name = "taskslistBox";
            taskslistBox.Size = new Size(431, 304);
            taskslistBox.TabIndex = 2;
            taskslistBox.DoubleClick += taskslistBox_DoubleClick;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(headingLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(addButton, 0, 1);
            tableLayoutPanel1.Controls.Add(taskslistBox, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 53.020134F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 46.979866F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 309F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(437, 479);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // headingLabel
            // 
            headingLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            headingLabel.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(headingLabel, 2);
            headingLabel.Font = new Font("Segoe UI", 38F, FontStyle.Regular, GraphicsUnit.Point);
            headingLabel.Location = new Point(3, 2);
            headingLabel.Name = "headingLabel";
            headingLabel.Size = new Size(431, 86);
            headingLabel.TabIndex = 0;
            headingLabel.Text = "To Do";
            headingLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // addButton
            // 
            tableLayoutPanel1.SetColumnSpan(addButton, 2);
            addButton.Dock = DockStyle.Fill;
            addButton.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            addButton.Location = new Point(3, 93);
            addButton.Name = "addButton";
            addButton.Size = new Size(431, 73);
            addButton.TabIndex = 1;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(437, 479);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            Text = "MainForm";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox taskslistBox;
        private TableLayoutPanel tableLayoutPanel1;
        private Label headingLabel;
        private Button addButton;
    }
}