using System;
using System.Windows.Forms;
using Game_Pikachu.PlayViewProcess;

namespace Game_Pikachu
{
    public partial class Playformwith_1player : Form
    {
        Sounds sound = new Sounds(AppDomain.CurrentDomain.BaseDirectory + "//Sounds and img Sounds//Content//102-palette town theme.mp3");
        int i_sounds = 1;
        public Playformwith_1player()
        {
            InitializeComponent();
            // Chạy timer, có tác dụng ở progressBar
            timer.Start();
            InitialProcessEvent InitialProcessPlay = new InitialProcessEvent();
            DrawPanelContainIcon drawPanelContainIcon = new DrawPanelContainIcon();
            InitialProcessPlay.ProcessEvent(drawPanelContainIcon, panelContainIcon);
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            
        }
        private void buttonPlayAgain_Click(object sender, EventArgs e)
        {
            this.Hide();
            Playformwith_1player newPlayForm = new Playformwith_1player();
            newPlayForm.StartPosition = FormStartPosition.CenterScreen;
            newPlayForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            i_sounds++;
            Playformwith_1player_Load(sender, e);
        }

        private void Playformwith_1player_Load(object sender, EventArgs e)
        {
            progressBarTime.PerformStep();
            if (i_sounds % 2 == 0)
            {
                sound.Pause();
            }
            else
            {
                sound.Resume();
            }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick_1(object sender, EventArgs e)
        {
            progressBarTime.PerformStep();
            if (progressBarTime.Value == progressBarTime.Maximum)
            {
                this.Close();
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            sound.Stop();
            this.Close();
        }
    }
    }

