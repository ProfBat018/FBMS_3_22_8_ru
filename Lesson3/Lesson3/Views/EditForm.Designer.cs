namespace Lesson3.Views
{
    partial class EditForm
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
            taskPictureBox = new PictureBox();
            leftPanel = new TableLayoutPanel();
            label1 = new Label();
            makeLabel = new Label();
            nameTextBox = new TextBox();
            productionLabel = new Label();
            duePicker = new DateTimePicker();
            editButton = new Button();
            checkBox1 = new CheckBox();
            mainPanel = new Panel();
            ((System.ComponentModel.ISupportInitialize)taskPictureBox).BeginInit();
            leftPanel.SuspendLayout();
            mainPanel.SuspendLayout();
            SuspendLayout();
            // 
            // taskPictureBox
            // 
            leftPanel.SetColumnSpan(taskPictureBox, 2);
            taskPictureBox.Cursor = Cursors.Hand;
            taskPictureBox.Dock = DockStyle.Fill;
            taskPictureBox.Location = new Point(3, 129);
            taskPictureBox.Name = "taskPictureBox";
            taskPictureBox.Size = new Size(400, 257);
            taskPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            taskPictureBox.TabIndex = 10;
            taskPictureBox.TabStop = false;
            // 
            // leftPanel
            // 
            leftPanel.ColumnCount = 2;
            leftPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 192F));
            leftPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 8F));
            leftPanel.Controls.Add(label1, 0, 4);
            leftPanel.Controls.Add(makeLabel, 0, 0);
            leftPanel.Controls.Add(nameTextBox, 1, 0);
            leftPanel.Controls.Add(productionLabel, 0, 1);
            leftPanel.Controls.Add(duePicker, 1, 1);
            leftPanel.Controls.Add(taskPictureBox, 0, 2);
            leftPanel.Controls.Add(editButton, 0, 3);
            leftPanel.Controls.Add(checkBox1, 1, 4);
            leftPanel.Dock = DockStyle.Fill;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Name = "leftPanel";
            leftPanel.RowCount = 5;
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 263F));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 51F));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 8F));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            leftPanel.Size = new Size(406, 496);
            leftPanel.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(38, 447);
            label1.Name = "label1";
            label1.Size = new Size(116, 41);
            label1.TabIndex = 11;
            label1.Text = "Is done";
            // 
            // makeLabel
            // 
            makeLabel.Anchor = AnchorStyles.None;
            makeLabel.AutoSize = true;
            makeLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            makeLabel.Location = new Point(47, 15);
            makeLabel.Name = "makeLabel";
            makeLabel.Size = new Size(97, 41);
            makeLabel.TabIndex = 0;
            makeLabel.Text = "Name";
            // 
            // nameTextBox
            // 
            nameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nameTextBox.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            nameTextBox.Location = new Point(195, 14);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(208, 43);
            nameTextBox.TabIndex = 4;
            // 
            // productionLabel
            // 
            productionLabel.Anchor = AnchorStyles.None;
            productionLabel.AutoSize = true;
            productionLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            productionLabel.Location = new Point(60, 78);
            productionLabel.Name = "productionLabel";
            productionLabel.Size = new Size(72, 41);
            productionLabel.TabIndex = 3;
            productionLabel.Text = "Due";
            // 
            // duePicker
            // 
            duePicker.CustomFormat = "dd/mm/yyyy";
            duePicker.Dock = DockStyle.Fill;
            duePicker.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            duePicker.Format = DateTimePickerFormat.Custom;
            duePicker.Location = new Point(195, 75);
            duePicker.Name = "duePicker";
            duePicker.Size = new Size(208, 43);
            duePicker.TabIndex = 9;
            // 
            // editButton
            // 
            leftPanel.SetColumnSpan(editButton, 2);
            editButton.Dock = DockStyle.Fill;
            editButton.Location = new Point(3, 392);
            editButton.Name = "editButton";
            editButton.Size = new Size(400, 45);
            editButton.TabIndex = 7;
            editButton.Text = "Edit";
            editButton.UseVisualStyleBackColor = true;
            editButton.Click += editButton_Click;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(195, 456);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(208, 24);
            checkBox1.TabIndex = 12;
            checkBox1.Text = "YES";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(leftPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(406, 496);
            mainPanel.TabIndex = 4;
            // 
            // EditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(406, 496);
            Controls.Add(mainPanel);
            Name = "EditForm";
            Text = "EditForm";
            ((System.ComponentModel.ISupportInitialize)taskPictureBox).EndInit();
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            mainPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PictureBox taskPictureBox;
        private TableLayoutPanel leftPanel;
        private Label makeLabel;
        private TextBox nameTextBox;
        private Label productionLabel;
        private DateTimePicker duePicker;
        private Button editButton;
        private Panel mainPanel;
        private Label label1;
        private CheckBox checkBox1;
    }
}