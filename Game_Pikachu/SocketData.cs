using System;

namespace Game_Pikachu
{
    [Serializable]
    public class SocketData
    {
        private int command;
        public int Command
        {
            get { return command; }
            set { command =value;}
        }
        private string mess;
        private int v;

        public string Mess
        {
            get { return mess; }
            set { mess = value; }
        }
        public SocketData(int command, string message)
        {
            this.Command = command;
            this.Mess = message;
        }

        public SocketData(int v)
        {
            this.v = v;
        }
    }
    public enum SocketCommand
    {
        SEND_MESSAGE,
        NOTIFY,
        NEW_GAME,
        QUIT,
    }
}
