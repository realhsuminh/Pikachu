using Game_Pikachu.PlayViewProcess;
using System;
using System.Windows.Forms;

namespace Game_Pikachu
{
    public partial class NewSelectForm : Form
    {
        Sounds sound2 = new Sounds(AppDomain.CurrentDomain.BaseDirectory + "Sounds and img Sounds//Content//101-opening (online-audio-converter.com).wav");
        int i_sounds2 = 1;
        public NewSelectForm()
        {
            InitializeComponent();
        }

        
        private void buttonStart_Click(object sender, EventArgs e)
        {
        }
       

        #region Click to Button Continue
        private void buttonContinue_Click(object sender, EventArgs e)
        {
            //buttonContinue.Visible = false;
        }
        #endregion

        #region Click to Button Guide
        private void buttonGuide_Click(object sender, EventArgs e)
        {
            //buttonGuide.Visible = false;
            Instruction inst = new Instruction();
            inst.Show();


        }
        #endregion

        #region Click to Button About
        private void buttonAbout_Click(object sender, EventArgs e)
        {
            buttonAbout.Visible = false;
        }
        #endregion

        #region Click to Button Exit
        private void buttonExit_Click(object sender, EventArgs e)
        {
            buttonExit.Visible = false;
            this.Close();
        }


        #endregion

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            i_sounds2++;
            NewSelectForm_Load(sender, e);
        }

        private void NewSelectForm_Load(object sender, EventArgs e)
        {
            if (i_sounds2 % 2 == 0)
            {
                sound2.Pause();
            }
            else
            {
                sound2.Resume();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        #region Click to Button Start

        private void buttonStart_Click_1(object sender, EventArgs e)
        {
            buttonStart.Visible = false;
            this.Hide();
            sound2.Stop();
            SelectPlayer selectPlayer = new SelectPlayer();
            selectPlayer.Show();
            #endregion
        }
    }
}
