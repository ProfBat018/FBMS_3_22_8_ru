namespace Part2
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
            mainPanel = new Panel();
            rightUpPanel = new Panel();
            personPictureBox = new PictureBox();
            rightDownpanel = new Panel();
            peopleListBox = new ListBox();
            leftPanel = new TableLayoutPanel();
            browseButton = new Button();
            imageLabel = new Label();
            nameLabel = new Label();
            surnameLabel = new Label();
            nameTextBox = new TextBox();
            surnameTextBox = new TextBox();
            addButton = new Button();
            deleteButton = new Button();
            birthLabel = new Label();
            birthDatePicker = new DateTimePicker();
            mainPanel.SuspendLayout();
            rightUpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)personPictureBox).BeginInit();
            rightDownpanel.SuspendLayout();
            leftPanel.SuspendLayout();
            SuspendLayout();
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
            mainPanel.TabIndex = 0;
            // 
            // rightUpPanel
            // 
            rightUpPanel.Controls.Add(personPictureBox);
            rightUpPanel.Dock = DockStyle.Top;
            rightUpPanel.Location = new Point(379, 0);
            rightUpPanel.Name = "rightUpPanel";
            rightUpPanel.Size = new Size(421, 218);
            rightUpPanel.TabIndex = 2;
            // 
            // personPictureBox
            // 
            personPictureBox.Dock = DockStyle.Fill;
            personPictureBox.Location = new Point(0, 0);
            personPictureBox.Name = "personPictureBox";
            personPictureBox.Size = new Size(421, 218);
            personPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            personPictureBox.TabIndex = 0;
            personPictureBox.TabStop = false;
            // 
            // rightDownpanel
            // 
            rightDownpanel.Controls.Add(peopleListBox);
            rightDownpanel.Dock = DockStyle.Bottom;
            rightDownpanel.Location = new Point(379, 215);
            rightDownpanel.Name = "rightDownpanel";
            rightDownpanel.Size = new Size(421, 235);
            rightDownpanel.TabIndex = 1;
            // 
            // peopleListBox
            // 
            peopleListBox.Dock = DockStyle.Fill;
            peopleListBox.FormattingEnabled = true;
            peopleListBox.ItemHeight = 20;
            peopleListBox.Location = new Point(0, 0);
            peopleListBox.Name = "peopleListBox";
            peopleListBox.Size = new Size(421, 235);
            peopleListBox.TabIndex = 0;
            peopleListBox.SelectedIndexChanged += peopleListBox_SelectedIndexChanged;
            // 
            // leftPanel
            // 
            leftPanel.ColumnCount = 2;
            leftPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 192F));
            leftPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 8F));
            leftPanel.Controls.Add(browseButton, 1, 3);
            leftPanel.Controls.Add(imageLabel, 0, 3);
            leftPanel.Controls.Add(nameLabel, 0, 0);
            leftPanel.Controls.Add(surnameLabel, 0, 1);
            leftPanel.Controls.Add(nameTextBox, 1, 0);
            leftPanel.Controls.Add(surnameTextBox, 1, 1);
            leftPanel.Controls.Add(addButton, 0, 4);
            leftPanel.Controls.Add(deleteButton, 1, 4);
            leftPanel.Controls.Add(birthLabel, 0, 2);
            leftPanel.Controls.Add(birthDatePicker, 1, 2);
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
            // browseButton
            // 
            browseButton.Dock = DockStyle.Top;
            browseButton.Location = new Point(195, 193);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(181, 44);
            browseButton.TabIndex = 11;
            browseButton.Text = "Browse";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
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
            // nameLabel
            // 
            nameLabel.Anchor = AnchorStyles.None;
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            nameLabel.Location = new Point(47, 15);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(97, 41);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "Name";
            // 
            // surnameLabel
            // 
            surnameLabel.Anchor = AnchorStyles.None;
            surnameLabel.AutoSize = true;
            surnameLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            surnameLabel.Location = new Point(28, 78);
            surnameLabel.Name = "surnameLabel";
            surnameLabel.Size = new Size(135, 41);
            surnameLabel.TabIndex = 1;
            surnameLabel.Text = "Surname";
            // 
            // nameTextBox
            // 
            nameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            nameTextBox.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            nameTextBox.Location = new Point(195, 14);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(181, 43);
            nameTextBox.TabIndex = 4;
            // 
            // surnameTextBox
            // 
            surnameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            surnameTextBox.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            surnameTextBox.Location = new Point(195, 77);
            surnameTextBox.Name = "surnameTextBox";
            surnameTextBox.Size = new Size(181, 43);
            surnameTextBox.TabIndex = 5;
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
            // birthLabel
            // 
            birthLabel.Anchor = AnchorStyles.None;
            birthLabel.AutoSize = true;
            birthLabel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            birthLabel.Location = new Point(25, 137);
            birthLabel.Name = "birthLabel";
            birthLabel.Size = new Size(141, 41);
            birthLabel.TabIndex = 3;
            birthLabel.Text = "BirthDate";
            // 
            // birthDatePicker
            // 
            birthDatePicker.Anchor = AnchorStyles.None;
            birthDatePicker.CustomFormat = "dd/mm/yyyy";
            birthDatePicker.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            birthDatePicker.Format = DateTimePickerFormat.Short;
            birthDatePicker.Location = new Point(195, 136);
            birthDatePicker.Name = "birthDatePicker";
            birthDatePicker.Size = new Size(181, 43);
            birthDatePicker.TabIndex = 9;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mainPanel);
            Name = "MainForm";
            Text = "MainForm";
            mainPanel.ResumeLayout(false);
            rightUpPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)personPictureBox).EndInit();
            rightDownpanel.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel mainPanel;
        private Panel rightUpPanel;
        private Panel rightDownpanel;
        private Label nameLabel;
        private Label surnameLabel;
        private Label birthLabel;
        private TextBox nameTextBox;
        private TextBox surnameTextBox;
        private TableLayoutPanel leftPanel;
        private Button addButton;
        private Button deleteButton;
        private DateTimePicker birthDatePicker;
        private Label imageLabel;
        private PictureBox personPictureBox;
        private Button browseButton;
        private ListBox peopleListBox;
    }
}