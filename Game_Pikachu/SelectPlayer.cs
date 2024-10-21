using System;
using System.Windows.Forms;
using Game_Pikachu.PlayViewProcess;

namespace Game_Pikachu
{
    public partial class SelectPlayer : Form
    {
        Sounds sound = new Sounds(AppDomain.CurrentDomain.BaseDirectory + "//Sounds and img Sounds//Content//102-palette town theme.mp3");
        
        
        public SelectPlayer()
        {
            InitializeComponent();
        }

       private void SelectPlayer_Load(object sender, EventArgs e)
        {
             sound.Resume();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form UserForm1 = new UserForm();
            UserForm1.Show();                     
            sound.Stop();   
        }        

        private void button1player_Click(object sender, EventArgs e)
        {
            Playformwith_1player one_Player = new Playformwith_1player();
            one_Player.Show();
            sound.Stop();
        }
    }
}
