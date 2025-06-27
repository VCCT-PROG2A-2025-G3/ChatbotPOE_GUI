using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using ChatbotPOE.ChatbotPOE;

namespace ChatbotPOE_GUI
{
    public partial class chatDisplay : Form
    {
        // Instance variables for chatbot functionality
        private Chatbot chatbot;
        private List<TaskItem> tasks;
        private Timer reminderTimer;
        private List<string> activityLog = new List<string>();
        private List<(string question, string[] options, int correctIndex, string explanation)> quizQuestions = new List<(string, string[], int, string)>();
        private int currentQuestionIndex = 0;
        private int score = 0;
        private bool quizActive = false;

        public chatDisplay()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.Dpi; // Support scaling
            chatbot = new Chatbot();
            tasks = new List<TaskItem>();
            InitializeReminderTimer();
            InitializeQuizQuestions();
            StartChat();
            // Add event handlers
            sendButton.Click += (s, e) => HandleUserInput(userInput);
            addTaskButton.Click += (s, e) => AddTask(userInput, taskDetails, reminderPicker, taskList);
            // Add context menu for task deletion
            taskList.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    int index = taskList.IndexFromPoint(e.Location);
                    if (index != -1)
                    {
                        taskList.SelectedIndex = index;
                        ContextMenu menu = new ContextMenu();
                        menu.MenuItems.Add("Delete", (s2, e2) =>
                        {
                            tasks.RemoveAt(index);
                            taskList.Items.RemoveAt(index);
                            richTextBox2.AppendText($"Chatbot: Task deleted.\n");
                            LogAction($"Task deleted at {DateTime.Now:dd/MM/yyyy HH:mm} SAST");
                        });
                        menu.Show(taskList, e.Location);
                    }
                }
            };
        }

        private void chatDisplay_Load(object sender, EventArgs e)
        {
            try
            {
                // Set sizes for task-related UI elements
                taskLabel.Size = new System.Drawing.Size(200, 20);
                taskList.Size = new System.Drawing.Size(200, 196);
                reminderLabel.AutoSize = false;
                reminderLabel.Size = new System.Drawing.Size(200, 30);
                reminderPicker.Size = new System.Drawing.Size(200, 22);
                addTaskButton.Location = new System.Drawing.Point(570, reminderPicker.Location.Y + reminderPicker.Height + 10);
            }
            catch (Exception ex)
            {
                // Show error message if UI setup fails
                MessageBox.Show($"Error during form load: {ex.Message}", "Initialization Error");
            }
        }

        private void InitializeQuizQuestions()
        {
            // Initialize quiz questions
            // Unchanged, quiz questions are well-defined
            quizQuestions.Add(("What should you do if you receive an email asking for your password?", new[] { "Reply", "Delete", "Report as phishing", "Ignore" }, 2, "Reporting phishing emails helps prevent scams."));
            // ... (other questions unchanged)
        }

        // Start the chatbot session
        private void StartChat()
        {
            Voice voice = new Voice();
            try
            {
                voice.PlayAudio1(); // Play initial audio
                System.Threading.Thread.Sleep(1000); // Brief pause
                voice.VoiceGreeting(); // Play voice greeting
                richTextBox2.AppendText(new Padlock().GetDisplayText() + "\n");
                string userName = chatbot.GreetUser();
                DateTime startTime = DateTime.Now; // Record session start time
                richTextBox2.AppendText($"Welcome to the App, {userName}! (Started at {startTime:dd/MM/yyyy HH:mm} SAST)\n");
                richTextBox2.AppendText("Type your cybersecurity questions, tasks, 'start quiz', or 'show activity log' below (e.g., 'Set up two-factor authentication').\n");
                LogAction($"Chat session started at {startTime:dd/MM/yyyy HH:mm} SAST");  // Log session start
            }
            catch (Exception ex)
            {
                // Fallback to text if audio fails
                richTextBox2.AppendText("Audio unavailable, proceeding with text greeting.\n");
                MessageBox.Show($"Error starting chat: {ex.Message}", "Startup Error");
            }
        }

        // Handle user input from the text box
        private void HandleUserInput(TextBox userInput)
        {
            try
            {
                string input = userInput.Text.Trim().ToLower();// Get and normalize user input
                if (string.IsNullOrEmpty(input))
                {
                    richTextBox2.AppendText("Chatbot: Please enter a command or question.\n");
                    return;
                }
                richTextBox2.AppendText($"You: {input}\n");// Check for empty input
                if (input == "exit")
                {
                    richTextBox2.AppendText("Chatbot: Goodbye! Stay safe! 👋\n");
                    LogAction($"Chat session ended at {DateTime.Now:dd/MM/yyyy HH:mm} SAST");
                    Application.Exit();
                    return;
                }
                else if (input == "show activity log") // Handle activity log request
                {
                    ShowActivityLog();
                    userInput.Clear();
                    return;
                }
                else if (input == "show more")
                {
                    HandleShowMore();
                    userInput.Clear();
                    return;
                }
                else if (input == "start quiz")// Start quiz
                {
                    StartQuiz();
                    userInput.Clear();
                    return;
                }
                else if (quizActive)
                {
                    ProcessAnswer(input);// Process quiz answers
                    userInput.Clear();
                    return;
                }
                var (response, delay) = chatbot.HandleQuery(input);
                System.Threading.Thread.Sleep(delay);
                richTextBox2.AppendText($"Chatbot: {response}\n");
                LogAction($"Responded to: {input} at {DateTime.Now:dd/MM/yyyy HH:mm} SAST");
                userInput.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error handling input: {ex.Message}", "Input Error");
            }
        }

        // Add a new task to the task list
        private void AddTask(TextBox userInput, TextBox taskDetails, DateTimePicker reminderPicker, ListBox taskList)
        {
            try
            {
                string taskName = userInput.Text.Trim();// Get task name
                string details = taskDetails.Text.Trim();// Get task details
                DateTime reminder = reminderPicker.Value;// Get reminder time
                if (string.IsNullOrEmpty(taskName))// Validate task name
                {
                    MessageBox.Show("Please enter a task in the input box.");
                    return;
                }
                TaskItem task = new TaskItem(taskName, details, reminder);
                tasks.Add(task);
                taskList.Items.Add(task.ToString());
                richTextBox2.AppendText($"Chatbot: Task '{taskName}' added with reminder at {reminder:dd/MM/yyyy HH:mm} SAST.\n");
                LogAction($"Task added: {taskName} at {DateTime.Now:dd/MM/yyyy HH:mm} SAST");
                userInput.Clear();
                taskDetails.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding task: {ex.Message}", "Task Error");
            }
        }

        // Initialize the reminder timer to check tasks periodically
        private void InitializeReminderTimer()
        {
            try
            {
                reminderTimer = new Timer
                {
                    Interval = 60000
                };
                reminderTimer.Tick += (s, e) => CheckReminders();
                reminderTimer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing reminder timer: {ex.Message}", "Timer Error");
            }
        }

        // Check for tasks with due reminders
        private void CheckReminders()
        {
            try
            {
                DateTime now = DateTime.Now;
                foreach (TaskItem task in tasks)
                {
                    if (!task.ReminderTriggered && now >= task.Reminder)
                    {
                        task.ReminderTriggered = true;
                        MessageBox.Show($"Reminder: {task.TaskName}\nDetails: {task.Details}", "Task Reminder");
                        LogAction($"Reminder triggered: {task.TaskName} at {now:dd/MM/yyyy HH:mm} SAST");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking reminders: {ex.Message}", "Reminder Error");
            }
        }

        // Log an action to the activity log
        private void LogAction(string action)
        {
            try
            {
                activityLog.Add(action);
                if (activityLog.Count > 10)
                    activityLog.RemoveAt(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error logging action: {ex.Message}", "Log Error");
            }
        }

        // Display recent activity log entries
        private void ShowActivityLog()
        {
            try
            {
                richTextBox2.AppendText("Chatbot: Here's a summary of recent actions:\n");
                int startIndex = Math.Max(0, activityLog.Count - 5);
                for (int i = startIndex; i < activityLog.Count; i++)
                {
                    richTextBox2.AppendText($"{i - startIndex + 1}. {activityLog[i]}\n");
                }
                richTextBox2.AppendText("Chatbot: Type 'show more' for full history or continue with other commands.\n");
            }
            catch (Exception ex)
            {
                // Display error if log display fails
                MessageBox.Show($"Error displaying activity log: {ex.Message}", "Log Display Error");
            }
        }
        // Display the full activity log
        private void HandleShowMore()
        {
            try
            {
                richTextBox2.AppendText("Chatbot: Full activity log:\n");
                for (int i = 0; i < activityLog.Count; i++)
                {
                    richTextBox2.AppendText($"{i + 1}. {activityLog[i]}\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying full activity log: {ex.Message}", "Log Display Error");
            }
        }

        // Start a new quiz session
        private void StartQuiz()
        {
            currentQuestionIndex = 0;
            score = 0;
            quizActive = true;
            LogAction($"Quiz started at {DateTime.Now:dd/MM/yyyy HH:mm} SAST");
            DisplayNextQuestion();
        }

        // Display the next quiz question
        private void DisplayNextQuestion()
        {
            if (currentQuestionIndex < quizQuestions.Count)
            {
                var (question, options, _, _) = quizQuestions[currentQuestionIndex];
                richTextBox2.AppendText($"\nQuestion {currentQuestionIndex + 1} of 10: {question}\n");
                for (int i = 0; i < options.Length; i++)
                {
                    richTextBox2.AppendText($"{(char)(65 + i)}) {options[i]}\n");
                }
                richTextBox2.AppendText("Enter your answer (e.g., A, B, C, D, or True/False): ");
            }
            else
            {
                EndQuiz();// End quiz if no more questions
            }
        }

        // Process user's quiz answer
        private void ProcessAnswer(string input)
        {
            var (question, options, correctIndex, explanation) = quizQuestions[currentQuestionIndex];
            int userAnswer = -1;
            input = input.Trim().ToUpper();
            if (char.IsLetter(input[0]) && input.Length == 1)
            {
                userAnswer = input[0] - 'A';
            }
            else if (input == "TRUE" || input == "FALSE")
            {
                userAnswer = input == "TRUE" ? 0 : 1;
            }
            if (userAnswer >= 0 && userAnswer < options.Length)
            {
                if (userAnswer == correctIndex)
                {
                    richTextBox2.AppendText($"Chatbot: Correct! {explanation}\n");
                    score++;
                }
                else
                {
                    richTextBox2.AppendText($"Chatbot: Wrong! The correct answer is {options[correctIndex]}. {explanation}\n");
                }
                currentQuestionIndex++;
                DisplayNextQuestion();
            }
            else
            {
                richTextBox2.AppendText("Chatbot: Invalid answer. Please enter A, B, C, D, True, or False.\n");
            }
        }
        // End the quiz and display results
        private void EndQuiz()
        {
            quizActive = false;
            richTextBox2.AppendText($"\nQuiz complete! Your score: {score}/10\n");
            string feedback = score >= 7 ? "Great job! You're a cybersecurity pro!" : "Keep learning to stay safe online!";
            richTextBox2.AppendText($"Chatbot: {feedback}\n");
            LogAction($"Quiz completed with score {score}/10 at {DateTime.Now:dd/MM/yyyy HH:mm} SAST");
        }
    }
    // Class to represent a task item
    public class TaskItem
    {
        public string TaskName { get; set; }
        public string Details { get; set; }
        public DateTime Reminder { get; set; }
        public bool ReminderTriggered { get; set; }

        // Constructor for TaskItem
        public TaskItem(string taskName, string details, DateTime reminder)
        {
            TaskName = taskName;
            Details = details;
            Reminder = reminder;
            ReminderTriggered = false;
        }

        public override string ToString()
        {
            // Override ToString for display in task list
            return $"{TaskName} (Due: {Reminder:dd/MM/yyyy HH:mm} SAST)";
        }
    }
}