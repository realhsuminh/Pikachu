using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Server
{

    public partial class Form1 : Form
    {
        /*public class SocketT2h
        {
            public Socket _Socket { get; set; }
            public string _Name { get; set; }
            public SocketT2h(Socket socket)
            {
                this._Socket = socket;
            }
        }
        private byte[] _buffer = new byte[1024];
        public List<SocketT2h> __ClientSockets { get; set; }
        List<string> _names = new List<string>();
        private Socket _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);*/
        public Form1()
        {
            InitializeComponent();
           
            //CheckForIllegalCrossThreadCalls = false;
            //__ClientSockets = new List<SocketT2h>();
        }



        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SetupServer();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }
        private void btnSend_Click_1(object sender, EventArgs e)
        {
            foreach (Socket item in clientList)
            {
                Send(item);
            }
            AddMessage(txtChat.Text);
            txtChat.Clear();
        }
        #region Server
        IPEndPoint IP;
        Socket Server;
        List<Socket> clientList;



        void Connect()
        {
            clientList = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, 9999);
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            Server.Bind(IP);
            Thread Listen = new Thread(() => {
                try
                {
                    while (true)
                    {
                        Server.Listen(100);
                        Socket client = Server.Accept();

                        clientList.Add(client);

                        Thread receive = new Thread(Receive);
                        receive.IsBackground = true;
                        receive.Start(client);
                    }
                }catch
                {
                    IP = new IPEndPoint(IPAddress.Any, 9999);
                    Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

                }

              

            });
            Listen.IsBackground = true;
            Listen.Start();


        }
        void close()
        {
            Server.Close();
        }
        void Send(Socket client)
        {
            if (txtChat.Text != string.Empty)
                client.Send(Serialize(txtChat.Text));
        }
        void Receive(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    string message = (string)Deserialize(data);

                    AddMessage(message);
                }
            }
            catch
            {
                clientList.Remove(client);
                client.Close();
            }

        }
        void AddMessage(string s)
        {
            lsvChatServer.Items.Add(new ListViewItem() { Text = s });
        }
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
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            close();
        }
    }
    #endregion
    /*private void SetupServer()
    {
        lb_stt.Text = "Setting up server . . .";
        _serverSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
        _serverSocket.Listen(1);
        _serverSocket.BeginAccept(new AsyncCallback(AppceptCallback), null);
    }
    private void AppceptCallback(IAsyncResult ar)
    {
        Socket socket = _serverSocket.EndAccept(ar);
        __ClientSockets.Add(new SocketT2h(socket));
        list_Client.Items.Add(socket.RemoteEndPoint.ToString());

        lb_soluong.Text = "Số client đang kết nối: " + __ClientSockets.Count.ToString();
        lb_stt.Text = "Client connected. . .";
        socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
        _serverSocket.BeginAccept(new AsyncCallback(AppceptCallback), null);
    }


    private void ReceiveCallback(IAsyncResult ar)
    {

        Socket socket = (Socket)ar.AsyncState;
        if (socket.Connected)
        {
            int received;
            try
            {
                received = socket.EndReceive(ar);
            }
            catch (Exception)
            {
                // client đóng kết nối
                for (int i = 0; i < __ClientSockets.Count; i++)
                {
                    if (__ClientSockets[i]._Socket.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
                    {
                        __ClientSockets.RemoveAt(i);
                        lb_soluong.Text = "Số client đang kết nối: " + __ClientSockets.Count.ToString();
                    }
                }
                // xóa trong list
                return;
            }
            if (received != 0)
            {
                byte[] dataBuf = new byte[received];
                Array.Copy(_buffer, dataBuf, received);
                string text = Encoding.ASCII.GetString(dataBuf);
                lb_stt.Text = "Text received: " + text;

                string reponse = string.Empty;


                for (int i = 0; i < __ClientSockets.Count; i++)
                {
                    if (socket.RemoteEndPoint.ToString().Equals(__ClientSockets[i]._Socket.RemoteEndPoint.ToString()))
                    {
                        rich_Text.AppendText("\n" + __ClientSockets[i]._Name + ": " + text);
                    }
                }



                if (text == "bye")
                {
                    return;
                }
                reponse = "server da nhan" + text;
                Sendata(socket, reponse);
            }
            else
            {
                for (int i = 0; i < __ClientSockets.Count; i++)
                {
                    if (__ClientSockets[i]._Socket.RemoteEndPoint.ToString().Equals(socket.RemoteEndPoint.ToString()))
                    {
                        __ClientSockets.RemoveAt(i);
                        lb_soluong.Text = "Số client đang kết nối: " + __ClientSockets.Count.ToString();
                    }
                }
            }
        }
        socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
    }
    void Sendata(Socket socket, string noidung)
    {
        byte[] data = Encoding.ASCII.GetBytes(noidung);
        socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
        _serverSocket.BeginAccept(new AsyncCallback(AppceptCallback), null);
    }
    private void SendCallback(IAsyncResult AR)
    {
        Socket socket = (Socket)AR.AsyncState;
        socket.EndSend(AR);
    }
    */


}
