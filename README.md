Cybersecurity Chatbot Application

Overview

The Cybersecurity Chatbot Application, developed as part of PROG6221 POE Part 1 by Group 3 (ST10454944), is a C# application designed to provide an interactive cybersecurity-themed experience. It offers both a console-based and a Windows Forms GUI-based interface, engaging users with audio greetings, ASCII art, a typing effect, task management, a quiz mode, and a question-and-answer system focused on password security and cybersecurity concepts.

Features





Console-Based Features:





Audio Greetings: Plays sound.wav and greeting.wav files for a personalized welcome using System.Media.SoundPlayer (Windows-specific).



ASCII Art: Displays a "Padlock" graphic to emphasize the security theme.



Typing Effect: Simulates real-time typing with a 30ms delay between characters for a conversational feel.



Password Security Questions: Asks three yes/no questions to assess users' password security practices.



Cybersecurity Query Handling: Allows users to ask predefined cybersecurity questions (e.g., "What is phishing?") with case-insensitive matching.



GUI-Based Features:





Chatbot Interaction: Users can input cybersecurity questions or commands via a text box, with responses displayed in a rich text box.



Task Management: Add, view, and delete tasks with optional details and reminders, displayed in a list box.



Quiz Mode: A cybersecurity quiz with multiple-choice questions, providing immediate feedback and a final score.



Activity Log: Tracks user actions (e.g., task additions, quiz completions) with options to view recent or full logs.



Shared Features:





Error Handling: Robust exception handling for audio playback, file access, and user input validation.



Responsive Design: Console version uses colorful formatting and borders; GUI version supports DPI scaling for better UI compatibility.

Prerequisites





.NET Framework: Version 4.0 or higher required to run the application.



Audio Files:





For console version: Place sound.wav and greeting.wav in the bin/Debug/voicegreeting1 directory (or equivalent).



For GUI version: Place Sound1.wav and greeting.wav in the bin/Debug/greeting1 directory (or equivalent).



Operating System: Windows (due to System.Media.SoundPlayer usage in both versions).



Development Environment: Visual Studio or another C# IDE for building and running the project.

Installation





Clone or Download the Repository (if applicable):

git clone <repository-url>



Open the Project:





Open ChatbotPOE_GUI.sln (for GUI version) or the console project solution in Visual Studio.



Add Audio Files:





For console version: Place sound.wav and greeting.wav in bin/Debug/voicegreeting1.



For GUI version: Place Sound1.wav and greeting.wav in bin/Debug/greeting1.



Build the Solution:





Build the project in Visual Studio to resolve dependencies.



Run the Application:





Run from Visual Studio or execute the compiled .exe file.

Project Structure





Console Version:





Program.cs: Main entry point, orchestrates chatbot flow, includes the typing effect, and handles user interactions.



Voice.cs: Manages audio playback for welcome and greeting sounds with error handling.



Chatbot.cs: Handles user greetings, password security questions, and processes cybersecurity queries using a dictionary.



Padlock.cs: Displays the ASCII padlock graphic and welcome message.



GUI Version:





Form1.cs / Form1.Designer.cs: Contains the chatDisplay form logic and UI designer code for chatbot interaction, task management, quiz, and activity logging.



Voice.cs: Manages audio playback for welcome greetings.



Padlock.cs: Provides the ASCII padlock graphic displayed on startup.



Program.cs: Entry point for the Windows Forms application.



Form1.resx: Resource file for the form’s UI elements.

Usage

Console Version





Launch the Application:





Run the console application to hear audio greetings and see the padlock graphic.



Follow Prompts:





Enter your name when prompted.



Answer three yes/no password security questions (e.g., "Do you use strong passwords?").



Ask cybersecurity questions (e.g., "What is phishing?") or type exit to quit.



Enjoy the Experience:





Observe the typing effect and colorful console output.

GUI Version





Launch the Application:





On launch, hear audio greetings (if files are available) and see the padlock graphic with a welcome message.



The interface includes a chat window, input box, task list, task details input, and a reminder date-time picker.



Chatbot Commands:





Type questions (e.g., "How to set up two-factor authentication?") in the input box and click "Send".



Use commands:





start quiz: Begins the cybersecurity quiz.



show activity log: Displays the last 5 actions.



show more: Shows the full activity log.



exit: Closes the application.



Task Management:





Enter a task name, optional details, and set a reminder; click "Add Task".



Right-click a task in the list to delete it.



Quiz Mode:





Start with start quiz, answer with letters (e.g., A, B, C, D) or True/False.



Receive feedback and a final score after 10 questions.



Reminders:





Reminders are checked every minute, triggering pop-ups for due tasks.

Key Functionalities





Audio Playback: Synchronous playback to avoid overlapping sounds; falls back to text if files are missing.



Typing Effect: 30ms delay per character in console version for a conversational feel.



Query Handling: Console version uses a dictionary for predefined otr predefined cybersecurity questions; GUI version extends this with additional features.



Task Management: GUI version supports task creation, deletion, and reminders.



Quiz System: GUI version includes a multiple-choice quiz with scoring and feedback.



Error Handling: Both versions handle audio, file, and input errors gracefully with MessageBox or console alerts.

References





Playing WAV Files: Uses System.Media.SoundPlayer for audio playback.



Delayed Response: Console version implements a 30ms typing effect delay; GUI version uses query-specific delays.



ASCII Artwork: Padlock.cs provides a consistent security-themed graphic.



Exception Handling: Robust try-catch blocks for audio, file access, and user input.

Limitations





Audio Playback: Windows-specific due to System.Media.SoundPlayer.



Query Handling: Limited to predefined cybersecurity questions in the console version.



Audio Files: Missing audio files result in text fallback and error messages.



Quiz Questions: GUI quiz currently has limited questions; console version focuses on three password questions.

Troubleshooting





Audio Errors: Ensure audio files are in the correct directories (voicegreeting1 for console, greeting1 for GUI). Check file permissions.



UI Issues (GUI): Verify .NET Framework version and DPI scaling settings.



Console Formatting: Ensure a Windows terminal for proper color and border rendering.



Exceptions: Errors are displayed via MessageBox (GUI) or console messages.

Future Improvements





Expand the query dictionary for broader cybersecurity topics.



Implement cross-platform audio playback (e.g., using NAudio).



Add a password strength checker or more interactive features.



Include persistent storage for tasks and activity logs (GUI).



Enhance the console version with dynamic query handling using NLP.



Add customizable themes or audio options for both versions.

Contributors





ST10454944



Group 3

License

This project is for educational purposes as part of PROG6221 POE Part 1. All rights reserved by the contributors.
