/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Game_Pikachu.PlayViewProcess;

namespace Game_Pikachu
{
    public partial class Connect : Form
    {
        SocketManager socket;
        Sounds sound1 = new Sounds(@"C:\Users\trant\Downloads\Edge\Pikachu-master\Game_Pikachu\Sounds and img Sounds\Content\102-palette town theme.mp3");
        int i_sounds1 = 1;
        public Connect()
        {
            InitializeComponent();
            socket = new SocketManager();
        }
        private void Connect_Shown(object sender, EventArgs e)
        {
            txtIP.Text = socket.GetLocalIPV4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(txtIP.Text))
            {
                txtIP.Text = socket.GetLocalIPV4(NetworkInterfaceType.Ethernet);
                }
        }

        private void pbConnect_Click(object sender, EventArgs e)
        {
            socket.IP = txtIP.Text;
            if (!socket.ConnectServer())
            {
                socket.CreatServer();

                Thread listenThread = new Thread(() =>
                {
                    while (true)
                    {
                        
                        Thread.Sleep(250);
  ;                        try
                        {
                            Listen();
                            break;

                        }
                        catch
                        {

                        }
                    }
                });
                listenThread.IsBackground = true;
                listenThread.Start();
            }
            else
            {
                Thread listenThread = new Thread(() => 
                { 
                    Listen(); 
                });
                listenThread.IsBackground = true;
                listenThread.Start();
                socket.Send("Kết nối từ Client");
                
            }

        }
        void Listen()
        {
            string data = (string)socket.Receive();
            MessageBox.Show(data);
        }


    }*/
    

