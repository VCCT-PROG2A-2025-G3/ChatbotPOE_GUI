using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace ChatbotPOE_GUI
{
    public class Voice
    {
        #region Constants
        // Relative paths to audio files in the greeting1 folder
        private readonly string SOUND1_WAV_PATH = Path.Combine(Application.StartupPath, "greeting1", "Sound1.wav");
        private readonly string GREETING_WAV_PATH = Path.Combine(Application.StartupPath, "greeting1", "greeting.wav");
        #endregion

        #region Voice Greeting Methods
        // Method to play the initial voice greeting audio (greeting.wav)
        public void VoiceGreeting()
        {
            try
            {
                if (File.Exists(GREETING_WAV_PATH))
                {
                    SoundPlayer player = new SoundPlayer(GREETING_WAV_PATH);
                    player.PlaySync(); // Play synchronously to ensure completion
                }
                else
                {
                    throw new FileNotFoundException($"Greeting file not found at: {GREETING_WAV_PATH}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing greeting.wav: {ex.Message}", "Audio Error");
            }
        }
        #endregion

        #region Static Audio Playback Methods
        // Static method to play a voice greeting from a specified audio path
        public static void PlayVoiceGreeting(string audioPath)
        {
            try
            {
                if (File.Exists(audioPath))
                {
                    SoundPlayer player = new SoundPlayer(audioPath);
                    player.PlaySync();
                }
                else
                {
                    throw new FileNotFoundException($"File not found: {audioPath}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing sound: {ex.Message}", "Audio Error");
            }
        }

        // Overloaded method (not implemented, placeholder for future use)
        internal static void PlayVoiceGreeting(object wav)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Additional Audio Playback
        // Method to play the initial audio file (Sound1.wav)
        public void PlayAudio1()
        {
            try
            {
                if (File.Exists(SOUND1_WAV_PATH))
                {
                    SoundPlayer player = new SoundPlayer(SOUND1_WAV_PATH);
                    player.Play();
                }
                else
                {
                    throw new FileNotFoundException($"Sound1 file not found at: {SOUND1_WAV_PATH}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error playing Sound1.wav: {ex.Message}", "Audio Error");
            }
        }
        #endregion
    }
}