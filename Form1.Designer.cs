namespace ChatbotPOE_GUI
{
    partial class chatDisplay
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
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.userInput = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.taskLabel = new System.Windows.Forms.Label();
            this.taskList = new System.Windows.Forms.ListBox();
            this.detailsLabel = new System.Windows.Forms.Label();
            this.taskDetails = new System.Windows.Forms.TextBox();
            this.reminderLabel = new System.Windows.Forms.Label();
            this.reminderPicker = new System.Windows.Forms.DateTimePicker();
            this.addTaskButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(10, 10);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(550, 400);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // userInput
            // 
            this.userInput.Location = new System.Drawing.Point(10, 420);
            this.userInput.Name = "userInput";
            this.userInput.Size = new System.Drawing.Size(450, 22);
            this.userInput.TabIndex = 1;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(470, 420);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(90, 30);
            this.sendButton.TabIndex = 2;
            this.sendButton.Text = "button3";
            this.sendButton.UseVisualStyleBackColor = true;
            // 
            // taskLabel
            // 
            this.taskLabel.Location = new System.Drawing.Point(570, 10);
            this.taskLabel.Name = "taskLabel";
            this.taskLabel.Size = new System.Drawing.Size(200, 20);
            this.taskLabel.TabIndex = 3;
            this.taskLabel.Text = "Task List";
            // 
            // taskList
            // 
            this.taskList.FormattingEnabled = true;
            this.taskList.ItemHeight = 16;
            this.taskList.Location = new System.Drawing.Point(570, 30);
            this.taskList.Name = "taskList";
            this.taskList.Size = new System.Drawing.Size(200, 196);
            this.taskList.TabIndex = 4;
            // 
            // detailsLabel
            // 
            this.detailsLabel.Location = new System.Drawing.Point(570, 240);
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(200, 20);
            this.detailsLabel.TabIndex = 5;
            this.detailsLabel.Text = "Task Details";
            // 
            // taskDetails
            // 
            this.taskDetails.Location = new System.Drawing.Point(570, 260);
            this.taskDetails.Multiline = true;
            this.taskDetails.Name = "taskDetails";
            this.taskDetails.Size = new System.Drawing.Size(200, 60);
            this.taskDetails.TabIndex = 6;
            // 
            // reminderLabel
            // 
            this.reminderLabel.Location = new System.Drawing.Point(570, 330);
            this.reminderLabel.Name = "reminderLabel";
            this.reminderLabel.Size = new System.Drawing.Size(200, 30);
            this.reminderLabel.TabIndex = 7;
            this.reminderLabel.Text = "Reminder";
            // 
            // reminderPicker
            // 
            this.reminderPicker.CustomFormat = "dd/MM/yyyy HH:mm";
            this.reminderPicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.reminderPicker.Location = new System.Drawing.Point(570, 350);
            this.reminderPicker.Name = "reminderPicker";
            this.reminderPicker.ShowUpDown = true;
            this.reminderPicker.Size = new System.Drawing.Size(200, 22);
            this.reminderPicker.TabIndex = 8;
            // 
            // addTaskButton
            // 
            this.addTaskButton.Location = new System.Drawing.Point(570, 390);
            this.addTaskButton.Name = "addTaskButton";
            this.addTaskButton.Size = new System.Drawing.Size(200, 30);
            this.addTaskButton.TabIndex = 9;
            this.addTaskButton.Text = "Add Task";
            this.addTaskButton.UseVisualStyleBackColor = true;
            // 
            // chatDisplay
            // 
            this.ClientSize = new System.Drawing.Size(892, 673);
            this.Controls.Add(this.addTaskButton);
            this.Controls.Add(this.reminderPicker);
            this.Controls.Add(this.reminderLabel);
            this.Controls.Add(this.taskDetails);
            this.Controls.Add(this.detailsLabel);
            this.Controls.Add(this.taskList);
            this.Controls.Add(this.taskLabel);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.userInput);
            this.Controls.Add(this.richTextBox2);
            this.Name = "chatDisplay";
            this.Load += new System.EventHandler(this.chatDisplay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DateTimePicker Authentication;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker Reminder;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.TextBox userInput;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label taskLabel;
        private System.Windows.Forms.ListBox taskList;
        private System.Windows.Forms.Label detailsLabel;
        private System.Windows.Forms.TextBox taskDetails;
        private System.Windows.Forms.Label reminderLabel;
        private System.Windows.Forms.DateTimePicker reminderPicker;
        private System.Windows.Forms.Button addTaskButton;
    }
}

