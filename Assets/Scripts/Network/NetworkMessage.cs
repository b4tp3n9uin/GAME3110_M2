using System;
using UnityEngine;

namespace NetworkMessage
{
    public enum Commands
    {
        NEW_CLIENT,
        UPDATE,
        CLIENT_DROPPED,
        CLIENT_LIST,
        OWN_ID,
        INPUT
    }

    [Serializable]
    public class NetworkHeader
    {
        public Commands cmd;
    }

    [Serializable]
    public class ClientPlayer
    {
        public string id;
        [Serializable]
        public struct receivedColor
        {
            public float R;
            public float G;
            public float B;
        }
        public receivedColor color;
        public Vector3 position;

        public ClientPlayer()
        {
            id = "-1";
        }
        public ClientPlayer(Client c)
        {
            id = c.id;
            color = c.color;
            position = c.position;
        }
        public override string ToString()
        {
            string result = "Player : \n";
            result += "id : " + id + "\n";
            result += "position : " + position.ToString() + "\n";

            return result;
        }
    }

    public class Client : ClientPlayer
    {
        public float interval;
        public override string ToString()
        {
            string result = base.ToString();
            result += "interval : " + interval + "\n";
            return result;
        }
    }

    [Serializable]
    public class NewPlayer : NetworkHeader
    {
        public ClientPlayer player;

        public NewPlayer(Client c)
        {
            cmd = Commands.NEW_CLIENT;
            player = new ClientPlayer(c);
        }
    }
    [Serializable]
    public class ConnectedPlayer : NetworkHeader
    {
        public ClientPlayer[] connect;


        public ConnectedPlayer(System.Collections.Generic.List<Client> clients)
        {
            cmd = Commands.CLIENT_LIST;
            connect = new ClientPlayer[clients.Count];
            for (int i = 0; i < clients.Count; i++)
            {
                connect[i] = new ClientPlayer(clients[i]);
            }
        }
    }
    [Serializable]
    public class DisconnectedPlayer : NetworkHeader
    {
        public ClientPlayer[] disconnect;
        public DisconnectedPlayer(System.Collections.Generic.List<Client> clients)
        {
            cmd = Commands.CLIENT_DROPPED;
            disconnect = new ClientPlayer[clients.Count];
            for (int i = 0; i < clients.Count; i++)
            {
                disconnect[i] = new ClientPlayer(clients[i]);
            }
        }
    }
    [Serializable]
    public class UpdatedPlayer : NetworkHeader
    {
        public ClientPlayer[] update;
        public UpdatedPlayer(System.Collections.Generic.List<Client> clients)
        {
            cmd = Commands.UPDATE;
            update = new ClientPlayer[clients.Count];
            for (int i = 0; i < clients.Count; i++)
            {
                update[i] = new ClientPlayer(clients[i]);
            }
        }
    }

    [Serializable]
    public class PlayerInput : NetworkHeader
    {
        public Vector3 input;
        public PlayerInput()
        {
            cmd = Commands.INPUT;
        }
    }
}
