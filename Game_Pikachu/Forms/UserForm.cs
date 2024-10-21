using Game_Pikachu.PlayViewProcess;
using System;
using System.Windows.Forms;

namespace Game_Pikachu
{
    public partial class UserForm : Form
    {
        Sounds sound1 = new Sounds(AppDomain.CurrentDomain.BaseDirectory + "//Sounds and img Sounds//Content//102-palette town theme.mp3");
        int i_sounds1 = 1;
       /* private Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        byte[] receivedBuf = new byte[1024];
        Thread thr;*/
        public UserForm()
        {
            InitializeComponent();
        }
       
        private void buttonStart_Click(object sender, EventArgs e)
        {
            sound1.Stop();
            //PlayForm pf = new PlayForm();
            PlayForm playform = new PlayForm(NewName.Text);
            playform.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            i_sounds1++;
            UserForm_Load(sender, e);   
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            if (i_sounds1 % 2 == 0)
            {
                sound1.Pause();
            }
            else
            {
                sound1.Resume();
            }
        }
    }
}
