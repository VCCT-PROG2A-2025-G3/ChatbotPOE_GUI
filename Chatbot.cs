using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatbotPOE.ChatbotPOE
{
    // Class representing the chatbot functionality, handling user interactions and responses
    class Chatbot
    {
        #region Constants
        // Default delay in milliseconds for simple responses
        private const int DEFAULT_DELAY_MS = 500;
        // Delay in milliseconds for complex responses requiring more processing
        private const int COMPLEX_DELAY_MS = 1000;
        // Interval at which cybersecurity alerts are triggered based on query count
        private const int ALERT_INTERVAL = 3;
        #endregion

        #region Data Structures
        // Dictionary storing predefined query-response pairs, case-insensitive
        private readonly Dictionary<string, string> queryResponses = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "phishing", "Phishing is a cyberattack where attackers send fraudulent emails, texts, or other messages pretending to be from a legitimate source to trick users into sharing sensitive information." },
            { "malware", "Malware is malicious software designed to harm, disrupt, or gain unauthorized access to a computer system. Examples include viruses, worms, ransomware, and spyware." },
            { "firewall", "A firewall is a security system that monitors and controls incoming and outgoing network traffic based on predefined rules, acting as a barrier between a trusted network and untrusted external networks." },
            { "two factor authentication", "Two-factor authentication (2FA) is a security process that requires two different forms of identification to access an account, such as a password and a code sent to your phone, adding an extra layer of protection." },
            { "encryption", "Encryption is the process of converting data into a coded form to prevent unauthorized access, ensuring that only those with the correct key can decrypt and read it." },
            { "ransomware", "Ransomware is a type of malware that encrypts a victim's files, making them inaccessible until a ransom is paid, often in cryptocurrency, to unlock them." },
            { "vpn", "A Virtual Private Network (VPN) creates a secure, encrypted connection over the internet, protecting your data and hiding your online activity from prying eyes." },
            { "data breach", "A data breach is an incident where unauthorized individuals gain access to sensitive or confidential information, such as personal data or corporate secrets." },
            { "social engineering", "Social engineering is a tactic used by cybercriminals to manipulate or trick people into revealing confidential information or performing actions that compromise security." },
            { "ddos attack", "A Distributed Denial-of-Service (DDoS) attack floods a server or network with traffic to overwhelm it, making it unavailable to users." },
            { "password manager", "A password manager is a tool that securely stores and generates complex passwords, helping you manage unique credentials for different accounts." },
            { "spyware", "Spyware is malicious software that secretly monitors and collects user information, such as browsing habits or keystrokes, without their consent." },
            { "security patch", "A security patch is an update released by software developers to fix vulnerabilities or bugs that could be exploited by attackers." },
            { "brute force attack", "A brute force attack is a hacking method that uses trial and error to guess passwords or encryption keys by systematically trying all possible combinations." },
            { "antivirus software", "Antivirus software is a program designed to detect, prevent, and remove malware, such as viruses, worms, and ransomware, from a computer or device." },
            { "man-in-the-middle attack", "A man-in-the-middle attack occurs when a cybercriminal intercepts communication between two parties to steal data or manipulate the conversation." },
            { "multi-factor authentication", "Multi-factor authentication (MFA) requires two or more verification methods (e.g., password, phone code, biometric) to enhance account security." },
            { "zero-day exploit", "A zero-day exploit is a cyberattack that targets a software vulnerability before the developer has released a patch or fix for it." },
            { "password", "Make sure to use strong, unique passwords for each account. Avoid using personal details in your passwords." },
            { "scam", "Scams are fraudulent schemes designed to deceive you into giving away money or personal information. Always verify the source before sharing sensitive details." },
            { "privacy", "Protect your privacy by limiting what you share online, using strong passwords, and enabling two-factor authentication on your accounts." },
            { "phishing tips", "" }
        };

        // List of phishing prevention tips to provide as responses
        private readonly List<string> phishingTips = new List<string>
        {
            "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organizations.",
            "Avoid clicking links in unsolicited emails. Hover over them to check the real URL first.",
            "Never share your password via email or phone. Legitimate organizations won’t ask for it this way."
        };

        // List of cybersecurity alerts to display at regular intervals
        private readonly List<string> cybersecurityAlerts = new List<string>
        {
            "⚠️ Reminder: Always update your software to protect against the latest threats!",
            "⚠️ Alert: Be cautious of unsolicited emails—they might be phishing attempts!",
            "⚠️ Tip: Use multi-factor authentication to add an extra layer of security to your accounts!"
        };

        private string userName = null;         // Stores the user's name, defaulting to null
        private string favoriteTopic = null;    // Stores the user's favorite cybersecurity topic
        private string lastTopic = null;        // Stores the last topic discussed
        private int queryCount = 0;             // Tracks the number of queries made by the user
        private readonly Random random = new Random(); // Random number generator for selecting tips/alerts
        #endregion

        #region Public Methods
        // Method to greet the user and collect their name and favorite topic via a form
        public string GreetUser()
        {
            using (var form = new Form())
            {
                form.Text = "Welcome!";
                form.Size = new System.Drawing.Size(300, 200);

                Label nameLabel = new Label
                {
                    Location = new System.Drawing.Point(10, 10),
                    Size = new System.Drawing.Size(260, 20),
                    Text = "May I please have your name?"
                };
                form.Controls.Add(nameLabel);

                TextBox nameInput = new TextBox
                {
                    Location = new System.Drawing.Point(10, 30),
                    Size = new System.Drawing.Size(260, 30),
                    Name = "nameInput"
                };
                form.Controls.Add(nameInput);

                Label topicLabel = new Label
                {
                    Location = new System.Drawing.Point(10, 70),
                    Size = new System.Drawing.Size(260, 20),
                    Text = "Favorite cybersecurity topic? (e.g., phishing)"
                };
                form.Controls.Add(topicLabel);

                TextBox topicInput = new TextBox
                {
                    Location = new System.Drawing.Point(10, 90),
                    Size = new System.Drawing.Size(260, 30),
                    Name = "topicInput"
                };
                form.Controls.Add(topicInput);

                Button submitButton = new Button
                {
                    Location = new System.Drawing.Point(10, 130),
                    Size = new System.Drawing.Size(260, 30),
                    Text = "Submit"
                };
                submitButton.Click += (s, e) => form.Close();
                form.Controls.Add(submitButton);

                form.ShowDialog();

                string inputName = nameInput.Text;
                if (!string.IsNullOrWhiteSpace(inputName))
                {
                    userName = inputName.Trim();
                }
                else
                {
                    userName = "Guest";
                }

                string inputTopic = topicInput.Text.Trim().ToLower();
                if (!string.IsNullOrWhiteSpace(inputTopic) && queryResponses.ContainsKey(inputTopic))
                {
                    favoriteTopic = inputTopic;
                }
                else
                {
                    favoriteTopic = "privacy";
                }
            }
            return userName;
        }

        // Method to handle user queries and return a response with an associated delay
        public (string Response, int Delay) HandleQuery(string input)
        {
            queryCount++; // Increment query counter
            if (string.IsNullOrWhiteSpace(input))
            {
                return (GetDefaultResponse(), GetDelay(input));
            }

            string trimmedInput = input.Trim().ToLower();
            int delay = GetDelay(trimmedInput);
            string sentimentResponse = DetectSentiment(trimmedInput);

            if (trimmedInput.Contains("interested in"))
            {
                string[] words = trimmedInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    if (queryResponses.ContainsKey(word))
                    {
                        favoriteTopic = word;
                        return (sentimentResponse + (string.IsNullOrEmpty(sentimentResponse) ? "" : " ") + $"Great! I'll remember that you're interested in {favoriteTopic}. It's a crucial part of staying safe online, {userName}.", delay);
                    }
                }
                return (sentimentResponse + (string.IsNullOrEmpty(sentimentResponse) ? "" : " ") + "I didn’t recognize that topic. Please specify a topic like 'phishing' or 'password', " + userName + ".", delay);
            }

            if (trimmedInput.Contains("don't understand") || trimmedInput.Contains("more details"))
            {
                if (lastTopic != null)
                {
                    return HandleFollowUp(lastTopic, delay);
                }
                return (sentimentResponse + (string.IsNullOrEmpty(sentimentResponse) ? "" : " ") + "I'm not sure what to elaborate on. Please ask about a topic like 'phishing' or 'password' first, " + userName + ".", delay);
            }

            foreach (var query in queryResponses)
            {
                if (trimmedInput.IndexOf(query.Key, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    lastTopic = query.Key;
                    if (query.Key == "phishing tips")
                    {
                        string tip;
                        try
                        {
                            tip = phishingTips[random.Next(phishingTips.Count)];
                        }
                        catch (Exception)
                        {
                            tip = phishingTips[0]; // Fallback to first tip if random fails
                        }
                        string personalization = favoriteTopic == "phishing" ? $" Since you like {favoriteTopic}, here’s a tip tailored for you, {userName}!" : "";
                        return (sentimentResponse + (string.IsNullOrEmpty(sentimentResponse) ? "" : " ") + tip + personalization, delay);
                    }
                    string baseResponse = query.Value + (query.Key.ToLower() == favoriteTopic ? $" This is great for your interest in {favoriteTopic}, {userName}!" : "");
                    return (sentimentResponse + (string.IsNullOrEmpty(sentimentResponse) ? "" : " ") + baseResponse, delay);
                }
            }

            string response = sentimentResponse + (string.IsNullOrEmpty(sentimentResponse) ? "" : " ") + GetDefaultResponse();
            if (queryCount % ALERT_INTERVAL == 0)
            {
                string alert;
                try
                {
                    alert = cybersecurityAlerts[random.Next(cybersecurityAlerts.Count)];
                }
                catch (Exception)
                {
                    alert = cybersecurityAlerts[0]; // Fallback to first alert if random fails
                }
                response += "\n" + alert;
            }
            return (response, delay);
        }
        #endregion

        #region Private Helper Methods
        // Method to detect and respond to the sentiment in the user's input
        private string DetectSentiment(string input)
        {
            if (input.Contains("worried") || input.Contains("scared") || input.Contains("nervous"))
            {
                return "It's completely understandable to feel that way, " + userName + ". Let me share some tips to help you stay safe.";
            }
            else if (input.Contains("curious") || input.Contains("wondering"))
            {
                return "I love your curiosity, " + userName + "! Let’s dive deeper into that topic.";
            }
            else if (input.Contains("frustrated") || input.Contains("annoyed"))
            {
                return "I’m sorry you’re feeling frustrated, " + userName + ". Let’s break this down to make it easier.";
            }
            return "";
        }

        // Method to determine the delay based on the complexity of the input
        private int GetDelay(string input)
        {
            return input.Contains("phishing tips") || input.Contains("more details") ? COMPLEX_DELAY_MS : DEFAULT_DELAY_MS;
        }

        // Method to handle follow-up queries based on the last topic discussed
        private (string Response, int Delay) HandleFollowUp(string lastTopic, int delay)
        {
            switch (lastTopic.ToLower())
            {
                case "phishing":
                case "phishing tips":
                    string tip;
                    try
                    {
                        tip = phishingTips[random.Next(phishingTips.Count)];
                    }
                    catch (Exception)
                    {
                        tip = phishingTips[0]; // Fallback to first tip if random fails
                    }
                    return (tip + $" Would you like another tip, {userName}?", COMPLEX_DELAY_MS);
                case "password":
                    return ("You can also use a password manager to keep track of your unique passwords. Need more advice, " + userName + "?", delay);
                case "scam":
                    return ("One way to spot scams is to check for poor grammar or urgent language. Want more tips, " + userName + "?", delay);
                case "privacy":
                    return ("Additionally, consider using a VPN for secure browsing. Any other questions, " + userName + "?", delay);
                default:
                    string response = queryResponses.ContainsKey(lastTopic) ? queryResponses[lastTopic] : "I’m not sure how to expand on that.";
                    return ("Let me clarify: " + response + $" Would you like to know more about {favoriteTopic}, {userName}?", delay);
            }
        }

        // Method to provide a default response when the input is not recognized
        private string GetDefaultResponse()
        {
            return "I don't quite understand that, could you rephrase or ask about cybersecurity topics like 'phishing tips', 'password', 'scam', or 'privacy', " + userName + "?";
        }
        #endregion
    }
}

//Refrencing
//I asked chat to help me come up with the queeationss and answers for the mini quiz game which they are in line 122 to line 130 https://www.knowbe4.com/resource-center/phishing
//
