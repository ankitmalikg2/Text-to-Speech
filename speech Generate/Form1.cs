using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech;
using System.Speech.Synthesis;
using System.IO;

namespace speech_Generate
{
    public partial class Form1 : Form
    {
        SpeechSynthesizer ss;
        public Form1()
        {
            InitializeComponent();
            ss = new SpeechSynthesizer();
            

        }

        private void btnSpeak_Click(object sender, EventArgs e)
        {
           
           
            if (textBox1.Text != null)
            {
                ss.SpeakAsync(textBox1.Text);
                

            }
            else
                MessageBox.Show("please Enter Something in the TextBox");
            
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            ss.Pause();

        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            ss.Resume();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "wav file|*.wav";
                    sfd.Title = "Save the audio";
                    if(sfd.ShowDialog()==DialogResult.OK)
                    {
                        FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write);
                        ss.SetOutputToWaveStream(fs);
                        ss.Speak(textBox1.Text);
                       
                    }

                }
            }
            catch(Exception ex)
            { }

           // ss.SetOutputToNull();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ss.SpeakAsyncCancelAll();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                ss.SelectVoiceByHints(VoiceGender.Male);
                    break;
                case 1:
                    ss.SelectVoiceByHints(VoiceGender.Female);
                    break;
                case 2:
                    ss.SelectVoiceByHints(VoiceGender.Neutral);
                    break;
               default :
                    ss.SelectVoiceByHints(VoiceGender.Female);
                    break;
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           switch(comboBox2.SelectedIndex)
            {
                case 0:
                    ss.Rate = -3;
                   

                    break;
                case 1:
                    ss.Rate = 0;
                    break;
                case 2:
                    ss.Rate = 3;
                    break;
                default:
                    ss.Rate = 0;
                    break;
            }
        }
    }
}
