using Game_Pikachu.PlayViewProcess;
using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;

namespace Game_Pikachu
{
    public partial class PlayForm : Form
    {
        Sounds sound = new Sounds(AppDomain.CurrentDomain.BaseDirectory + "//Sounds and img Sounds//Content//102-palette town theme.mp3");
        int i_sounds = 1;
        /*private Socket _clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        byte[] receivedBuf = new byte[1024];
        Thread thr;*/
        SocketManager socket;
       
        public PlayForm()
        {
            InitializeComponent();           
        }
        private string Ten_user;
        public PlayForm(string TenUser)
        {
            InitializeComponent();
            this.Ten_user = TenUser;
            socket = new SocketManager();
          //  InitialProcessEvent InitialProcessPlay = new InitialProcessEvent();
  //          DrawPanelContainIcon drawPanelContainIcon = new DrawPanelContainIcon();
//            InitialProcessPlay.ProcessEvent(drawPanelContainIcon, panelContainIcon);

        }
        private void timer_Tick(object sender, EventArgs e)
        {

            progressBarTime.PerformStep();
            if (progressBarTime.Value == progressBarTime.Maximum)
            {
                this.Close();
                //MessageBox.Show("Finish");
            }

        }
        private void PlayForm_Load(object sender, EventArgs e)
        {
            lbTenUser.Text = this.Ten_user;
            // ProgressBar chạy thời gian.
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

        // Exit Game

        private void ptb_Thoat_Click(object sender, EventArgs e)
        {
            sound.Stop();
            socket.Send(new SocketData((int)SocketCommand.QUIT, ""));
            this.Close();
        }

        // Play again
        private void buttonPlayAgain_Click(object sender, EventArgs e)
        {
            sound.Pause();
            this.Hide();
            Form newPlayForm = new PlayForm();
            newPlayForm.StartPosition = FormStartPosition.CenterScreen;
            newPlayForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            i_sounds++;
            PlayForm_Load(sender, e);
        }
        #region



        private void panelContainIcon_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion



        private void lbTenUser_Click(object sender, EventArgs e)
        {

        }
        #region CLient
        IPEndPoint IP;
        Socket client;
        private void ptSend_Click(object sender, EventArgs e)
        {
           if (txtChat.Text != string.Empty)
            {
                
               
                rbMessage.AppendText(lbTenUser.Text + ":" + txtChat.Text);

                string data;
                data = lbTenUser.Text + ":" + txtChat.Text;
                socket.Send(new SocketData((int)SocketCommand.SEND_MESSAGE, data));




            }    

        }
        void Checkpanel()
        {
            if (panelContainIcon == null)
            {
                timer.Stop();
                MessageBox.Show(lbTenUser.Text + "Win");
                this.Close();
            }
            else
            {
                if (i_sounds % 2 == 0)
                {
                    sound.Pause();
                }
                else
                {
                    sound.Resume();
                }
                MessageBox.Show("Hai người chơi hòa nhau");
            }    
          
                   
            
                 
             
            Listen();
                
                
        }
       
       /*void Connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {
                
                client.Connect(IP);

                if (!client.Connected)
                    MessageBox.Show("Không thể kết nối", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                else
                {
                    timer.Start();
                    InitialProcessEvent InitialProcessPlay = new InitialProcessEvent();
                    DrawPanelContainIcon drawPanelContainIcon = new DrawPanelContainIcon();
                    InitialProcessPlay.ProcessEvent(drawPanelContainIcon, panelContainIcon);
                }
            }
            catch
            {
                MessageBox.Show("Không thể kết nối", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();

        }
        void close()
        {
            client.Close();
        }
        void Send()
        {
            if (txtChat.Text!=string.Empty)
                  client.Send(Serialize(txtChat.Text));
        }
        void Receive()
        {try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string message = (string)Deserialize(data);

                    rbMessage.AppendText("Server: ");
                    AddMessage(message+"\n");
                }
            }catch
            {
                close();
            }

        }*/
        void AddMessage(string s)
        {

            rbMessage.AppendText(s);
            txtChat.Clear();
        }/*
        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
            
        }
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
             return formatter.Deserialize(stream);
        }*/
        
       void Listen()
        {
            //try
            {
                Thread listThread = new Thread(() =>
                {
                    try
                    {
                        SocketData data = (SocketData)socket.Receive();
                        ProcessData(data);
                    }
                    catch { }

                });
                listThread.IsBackground = true;
                listThread.Start();
            }
          //  catch { }
          //  MessageBox.Show(data);
        }


        private void PlayForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           if (MessageBox.Show("Bạn có chắc muốn thoát","Thông báo", MessageBoxButtons.OKCancel)!=DialogResult.OK)
            {
                e.Cancel = true;
            }    
           else
            {
                socket.Send(new SocketData((int)SocketCommand.QUIT, ""));
            }    
        }
      
        private void PlayForm_Shown(object sender, EventArgs e)
        {
            
            txtIP.Text = socket.GetLocalIPV4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(txtIP.Text))
            {
                txtIP.Text = socket.GetLocalIPV4(NetworkInterfaceType.Ethernet);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            socket.IP = txtIP.Text;
            if (!socket.ConnectServer())
            {
                socket.CreatServer();
                Thread listThread = new Thread(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(500);
                        try
                        {
                            Listen();
                            break;
                        }
                        catch
                        {

                        }
                    }
                });
                listThread.IsBackground = true;
                listThread.Start();
            }
            else
            {
                Listen();
               
               socket.Send(new SocketData((int)SocketCommand.NOTIFY, ""));

            }
            if (!socket.ConnectServer())
            {
                socket.Send("Disconnect");
            }
            else
            {
                timer.Start();
                InitialProcessEvent InitialProcessPlay = new InitialProcessEvent();
                DrawPanelContainIcon drawPanelContainIcon = new DrawPanelContainIcon();
                InitialProcessPlay.ProcessEvent(drawPanelContainIcon, panelContainIcon);

            }
          /*  while (socket.ConnectServer() )
                Checkpanel();*/
        }
        #endregion
        private void ProcessData(SocketData data )
        {
            switch(data.Command)
            {
                case (int)SocketCommand.SEND_MESSAGE:
                    {
                        AddMessage(data.Mess);
                        break;
                    }
                case (int)SocketCommand.NOTIFY:
                    {
                        MessageBox.Show("Đã kết nối thành công");
                        this.Invoke((MethodInvoker)(() =>
                        {
                           
                            timer.Start();
                        }));

                        break;
                    }
                    
                case (int)SocketCommand.NEW_GAME:
                    {
                      //  rbMessage.AppendText(data.Mess);
                        break;
                    }
                case (int)SocketCommand.QUIT:
                    {
                        MessageBox.Show("Người chơi đã thoát");
                        break;
                    }
                default:
                    break;
            }
            Listen();
        }
    }
}

