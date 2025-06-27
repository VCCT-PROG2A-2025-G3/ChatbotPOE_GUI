Cybersecurity Chatbot Application

Overview

The Cybersecurity Chatbot Application, developed as part of PROG6221 POE Part 1 by Group 3 (ST10454944), is a WPF (Windows Presentation Foundation) application designed to provide an interactive cybersecurity-themed experience. Originally a console-based application, it has been upgraded to a modern graphical interface using WPF, retaining core features like audio greetings, ASCII art, a typing effect, password security questions, and cybersecurity query handling.

Features





Audio Greetings: Plays sound.wav and greeting.wav files for a personalized welcome using System.Media.SoundPlayer (Windows-specific).



ASCII Art: Displays a "Padlock" graphic in a monospaced TextBlock to emphasize the security theme.



Typing Effect: Simulates real-time typing with a 30ms delay per character in the chat display for a conversational feel.



Password Security Questions: Asks three yes/no questions to assess users' password security practices.



Cybersecurity Query Handling: Supports predefined cybersecurity questions (e.g., "What is phishing?") with case-insensitive matching.



WPF Interface: Features a graphical UI with a chat display (TextBlock), input box (TextBox), and submit button, with scrollable output and Enter key support.

Prerequisites





.NET Framework: Version 4.0 or higher required to run the application.



Audio Files: Place sound.wav and greeting.wav in the bin/Debug/voicegreeting1 directory (or equivalent, depending on build configuration).



Operating System: Windows (due to System.Media.SoundPlayer usage).



Development Environment: Visual Studio or another C# IDE for building and running the project.

Installation





Clone or Download the Repository (if applicable):

git clone <repository-url>



Open the Project:





Open CybersecurityChatbotWPF.sln in Visual Studio.



Add Audio Files:





Place sound.wav and greeting.wav in the bin/Debug/voicegreeting1 directory.



Build the Solution:





Build the project in Visual Studio to resolve dependencies.



Run the Application:





Run from Visual Studio or execute the compiled .exe file.

Project Structure





MainWindow.xaml / MainWindow.xaml.cs: Defines the WPF UI and code-behind, handling chat display, user input, typing effect, and chatbot interactions.



Voice.cs: Manages audio playback for welcome and greeting sounds with error handling.



Chatbot.cs: Handles user greetings, password security questions, and processes cybersecurity queries using a dictionary.



Padlock.cs: Displays the ASCII padlock graphic and welcome message.



Program.cs: Entry point for the WPF application.

Usage





Launch the Application:





On launch, the application plays audio greetings (if files are available) and displays the padlock graphic with a welcome message in the chat window.



Follow Prompts:





The chatbot greets the user (default name "User") and asks three yes/no password security questions (e.g., "Do you use strong passwords?").



Answer by typing yes or no in the input box and clicking "Submit" or pressing Enter.



Ask Cybersecurity Questions:





After the questions, type cybersecurity queries (e.g., "What is phishing?") or exit to quit.



Enjoy the Experience:





Observe the typing effect in the chat display and error messages (if any) via MessageBox.

Key Functionalities





Audio Playback: Synchronous playback to avoid overlapping sounds; falls back to text if files are missing.



Typing Effect: 30ms delay per character in the WPF TextBlock for a conversational feel.



Query Handling: Uses a dictionary for predefined cybersecurity questions with case-insensitive matching.



Error Handling: Handles audio, file, and input errors with MessageBox alerts.



WPF UI: Provides a scrollable chat display, input box, and submit button with Enter key support.

References





Playing WAV Files: Uses System.Media.SoundPlayer for audio playback.



Delayed Response: Implements a 30ms typing effect delay and query-specific delays.



ASCII Artwork: Padlock.cs provides a security-themed graphic in a monospaced font.



Exception Handling: Robust try-catch blocks for audio, file access, and user input.

Limitations





Audio Playback: Windows-specific due to System.Media.SoundPlayer.



Query Handling: Limited to predefined cybersecurity questions.



Audio Files: Missing audio files result in text fallback and error messages.



User Name: Currently uses a default name ("User"); could be enhanced with UI-based input.

Troubleshooting





Audio Errors: Ensure sound.wav and greeting.wav are in bin/Debug/voicegreeting1. Check file permissions.



UI Issues: Verify .NET Framework version and screen scaling settings.



Exceptions: Errors are displayed via MessageBox for audio, file, or input issues.

Future Improvements





Expand the query dictionary for broader cybersecurity topics.



Implement cross-platform audio playback (e.g., using NAudio).



Add a password strength checker or additional interactive features.



Enhance user name input via a WPF dialog.



Add customizable themes or fonts for the WPF interface.

Contributors





ST10454944



Group 3

License

This project is for educational purposes as part of PROG6221 POE Part 1. All rights reserved by the contributors.
