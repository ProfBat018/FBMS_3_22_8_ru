namespace Lesson2.Views
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
            carPictureBox = new PictureBox();
            mainPanel = new Panel();
            rightUpPanel = new Panel();
            rightDownpanel = new Panel();
            carsListBox = new ListBox();
            leftPanel = new TableLayoutPanel();
            imageLabel = new Label();
            makeLabel = new Label();
            modelLabel = new Label();
            makeTextBox = new TextBox();
            modelTextBox = new TextBox();
            addButton = new Button();
            deleteButton = new Button();
            productionLabel = new Label();
            productionPicker = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)carPictureBox).BeginInit();
            mainPanel.SuspendLayout();
            rightUpPanel.SuspendLayout();
            rightDownpanel.SuspendLayout();
            leftPanel.SuspendLayout();
            SuspendLayout();
            // 
            // carPictureBox
            // 
            carPictureBox.Dock = DockStyle.Fill;
            carPictureBox.Location = new Point(0, 0);
            carPictureBox.Name = "carPictureBox";
            carPictureBox.Size = new Size(421, 218);
            carPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            carPictureBox.TabIndex = 0;
            carPictureBox.TabStop = false;
            // 
            // mainPanel
            // 
            mainPanel.Controls.Add(rightUpPanel);
            mainPanel.Controls.Add(rightDownpanel);
            mainPanel.Controls.Add(leftPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(800, 450);
            mainPanel.TabIndex = 1;
            // 
            // rightUpPanel
            // 
            rightUpPanel.Controls.Add(carPictureBox);
            rightUpPanel.Dock = DockStyle.Top;
            rightUpPanel.Location = new Point(379, 0);
            rightUpPanel.Name = "rightUpPanel";
            rightUpPanel.Size = new Size(421, 218);
            rightUpPanel.TabIndex = 2;
            // 
            // rightDownpanel
            // 
            rightDownpanel.Controls.Add(carsListBox);
            rightDownpanel.Dock = DockStyle.Bottom;
            rightDownpanel.Location = new Point(379, 215);
            rightDownpanel.Name = "rightDownpanel";
            rightDownpanel.Size = new Size(421, 235);
            rightDownpanel.TabIndex = 1;
            // 
            // carsListBox
            // 
            carsListBox.Dock = DockStyle.Fill;
            carsListBox.FormattingEnabled = true;
            carsListBox.ItemHeight = 20;
            carsListBox.Location = new Point(0, 0);
            carsListBox.Name = "carsListBox";
            carsListBox.Size = new Size(421, 235);
            carsListBox.TabIndex = 0;
            carsListBox.SelectedIndexChanged += carsListBox_SelectedIndexChanged;
            // 
            // leftPanel
            // 
            leftPanel.ColumnCount = 2;
            leftPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 192F));
            leftPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 8F));
            leftPanel.Controls.Add(imageLabel, 0, 3);
            leftPanel.Controls.Add(makeLabel, 0, 0);
            leftPanel.Controls.Add(modelLabel, 0, 1);
            leftPanel.Controls.Add(makeTextBox, 1, 0);
            leftPanel.Controls.Add(modelTextBox, 1, 1);
            leftPanel.Controls.Add(addButton, 0, 4);
            leftPanel.Controls.Add(deleteButton, 1, 4);
            leftPanel.Controls.Add(productionLabel, 0, 2);
            leftPanel.Controls.Add(productionPicker, 1, 2);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Name = "leftPanel";
            leftPanel.RowCount = 5;
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 54F));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            leftPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 158F));
            leftPanel.Size = new Size(379, 450);
            leftPanel.TabIndex = 0;
            // 
            // imageLabel
            // 
            imageLabel.Anchor = AnchorStyles.None;
            imageLabel.AutoSize = true;
            imageLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            imageLabel.Location = new Point(45, 199);
            imageLabel.Name = "imageLabel";
            imageLabel.Size = new Size(101, 41);
            imageLabel.TabIndex = 10;
            imageLabel.Text = "Image";
            // 
            // makeLabel
            // 
            makeLabel.Anchor = AnchorStyles.None;
            makeLabel.AutoSize = true;
            makeLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            makeLabel.Location = new Point(50, 15);
            makeLabel.Name = "makeLabel";
            makeLabel.Size = new Size(91, 41);
            makeLabel.TabIndex = 0;
            makeLabel.Text = "Make";
            // 
            // modelLabel
            // 
            modelLabel.Anchor = AnchorStyles.None;
            modelLabel.AutoSize = true;
            modelLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            modelLabel.Location = new Point(44, 78);
            modelLabel.Name = "modelLabel";
            modelLabel.Size = new Size(104, 41);
            modelLabel.TabIndex = 1;
            modelLabel.Text = "Model";
            // 
            // makeTextBox
            // 
            makeTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            makeTextBox.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            makeTextBox.Location = new Point(195, 14);
            makeTextBox.Name = "makeTextBox";
            makeTextBox.Size = new Size(181, 43);
            makeTextBox.TabIndex = 4;
            // 
            // modelTextBox
            // 
            modelTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            modelTextBox.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            modelTextBox.Location = new Point(195, 77);
            modelTextBox.Name = "modelTextBox";
            modelTextBox.Size = new Size(181, 43);
            modelTextBox.TabIndex = 5;
            // 
            // addButton
            // 
            addButton.Dock = DockStyle.Top;
            addButton.Location = new Point(3, 253);
            addButton.Name = "addButton";
            addButton.Size = new Size(186, 44);
            addButton.TabIndex = 7;
            addButton.Text = "Add";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.Dock = DockStyle.Top;
            deleteButton.Location = new Point(195, 253);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(181, 44);
            deleteButton.TabIndex = 8;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // productionLabel
            // 
            productionLabel.Anchor = AnchorStyles.None;
            productionLabel.AutoSize = true;
            productionLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            productionLabel.Location = new Point(56, 137);
            productionLabel.Name = "productionLabel";
            productionLabel.Size = new Size(80, 41);
            productionLabel.TabIndex = 3;
            productionLabel.Text = "Date";
            // 
            // productionPicker
            // 
            productionPicker.Anchor = AnchorStyles.None;
            productionPicker.CustomFormat = "dd/mm/yyyy";
            productionPicker.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            productionPicker.Format = DateTimePickerFormat.Short;
            productionPicker.Location = new Point(195, 136);
            productionPicker.Name = "productionPicker";
            productionPicker.Size = new Size(181, 43);
            productionPicker.TabIndex = 9;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainPanel);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)carPictureBox).EndInit();
            mainPanel.ResumeLayout(false);
            rightUpPanel.ResumeLayout(false);
            rightDownpanel.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox carPictureBox;
        private Panel mainPanel;
        private Panel rightUpPanel;
        private Panel rightDownpanel;
        private ListBox carsListBox;
        private TableLayoutPanel leftPanel;
        private Label imageLabel;
        private Label makeLabel;
        private Label modelLabel;
        private TextBox makeTextBox;
        private TextBox modelTextBox;
        private Button addButton;
        private Button deleteButton;
        private Label productionLabel;
        private DateTimePicker productionPicker;
    }
}