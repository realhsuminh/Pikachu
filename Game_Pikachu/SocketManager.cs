using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Game_Pikachu
{
    public class SocketManager
    {

        #region Client
        Socket client;
        public bool ConnectServer()
        {
            IPEndPoint IEP = new IPEndPoint(IPAddress.Parse(IP), PORT);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                client.Connect(IEP);
                return true;
            }
            catch
            {
                return false;

            } 
            

            
        }

        #endregion

        #region Server
        Socket server;
        public void CreatServer()
        {
            IPEndPoint IEP = new IPEndPoint(IPAddress.Parse(IP), PORT);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            server.Bind(IEP);
            server.Listen(10);
            // Tạo luồng riêng
            Thread accepClient = new Thread(() =>
             {

                 client = server.Accept();
             });
            // Tự tắt khi chương trình tắt
            accepClient.IsBackground = true;
            accepClient.Start();             
        }
        #endregion

        #region Both
        public string IP = "127.0.0.1";
        public int PORT = 53;
        public const int Buffer = 1024;
        public bool isServer = true;

        public bool Send(object data)
        {
            byte[] sendData = SerializeData(data);
           
           return SendData(client, sendData);

           
        }
        public object Receive()
        {
            byte[] receiveData = new byte[Buffer];
            bool isOk = ReceiveData(client, receiveData);
            return DeserializeData(receiveData);
        }
        private bool SendData(Socket target,byte[] data)
        {
            return target.Send(data) == 1 ? true : false;

        }
        private bool ReceiveData(Socket target, byte[] data)
        {
            return target.Receive(data) == 1 ? true : false;
        }
        //Nén đối tượng thành byte
        public byte[] SerializeData(Object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf1 = new BinaryFormatter();
            bf1.Serialize(ms, o);
            return ms.ToArray();
        }
        // Giải nén một mảng byte thành 1 object (đối tượng)
        public object DeserializeData(byte[] theByteArray)
        {
            MemoryStream ms = new MemoryStream(theByteArray);
            BinaryFormatter bf1 = new BinaryFormatter();
            ms.Position = 0;
            return bf1.Deserialize(ms);
        }
      
        //Lấy ra IP của card mạng đang dùng
        public string GetLocalIPV4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces() )
            {
                if (item.NetworkInterfaceType==_type && item.OperationalStatus==OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily==System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }    
                    }    
                }    
            }
            return output;
        }

    
        #endregion

    }
}
