using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class ServerClient
{
    public int connectionId;
    public string playerName;
    public int id;
}

public class Server : MonoBehaviour {
    private const int MAX_CONNECTION = 100;
    private int port = 5701;

    private int hostId;
    private int webHostId;

    private int reliableChannel;
    private int unReliableChannel;

    private bool isStarted = false;
    private byte error;

    private float time = 60;

    private int[] ballsArrayP1 = new int[40];
    private int[] ballsArrayP2 = new int[40];

    private List<ServerClient> clients = new List<ServerClient>();
    // Use this for initialization
    void Start()
    {
        NetworkTransport.Init();
        ConnectionConfig cc = new ConnectionConfig();

        reliableChannel = cc.AddChannel(QosType.Reliable);
        unReliableChannel = cc.AddChannel(QosType.Unreliable);

        HostTopology topo = new HostTopology(cc, MAX_CONNECTION);
        hostId = NetworkTransport.AddHost(topo, port, null);
        webHostId = NetworkTransport.AddWebsocketHost(topo, port, null);

        isStarted = true;

        for (int i = 0; i < ballsArrayP1.Length - 1; i++) {
            ballsArrayP1[i] = Random.Range(0, 8);
        }
        for (int i = 0; i < ballsArrayP2.Length - 1; i++) {
            ballsArrayP2[i] = Random.Range(0, 8);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isStarted) { return; }

        int recHostId;
        int connectionId;
        int channelId;
        byte[] recBuffer = new byte[1024];
        int bufferSize = 1024;
        int dataSize;
        byte error;
        NetworkEventType recData = NetworkTransport.Receive(out recHostId, out connectionId, out channelId, recBuffer, bufferSize, out dataSize, out error);
        switch (recData)
        {

            case NetworkEventType.Nothing:
                break;

            case NetworkEventType.ConnectEvent:
                onConnection(connectionId);
                break;

            case NetworkEventType.DataEvent:
                string msg = Encoding.Unicode.GetString(recBuffer, 0, dataSize);
                //Debug.Log("QUE RECIBO DE CADA CONEXION" + connectionId + ": " + msg);
                string[] splitData = msg.Split('|');
                switch (splitData[0])
                {

                    case "nameis":
                        OnNameIs(connectionId, splitData[1]);
                        if (connectionId % 2 != 0) {
                            
                        } else {
                            string nmb = "";
                            for (int i = 0; i < ballsArrayP1.Length - 1; i++) {
                                nmb = nmb + ballsArrayP1[i] + ".";
                            }
                            Send("generateBallsP1|" + nmb + "|" + clients.Find(x => x.playerName != splitData[1]).playerName, reliableChannel, clients);
                            string nmb2 = "";
                            for (int i = 0; i < ballsArrayP2.Length - 1; i++) {
                                nmb2 = nmb2 + ballsArrayP2[i] + ".";
                            }
                            Send("generateBallsP2|" + nmb2 + "|" + clients.Find(x => x.playerName == splitData[1]).playerName, reliableChannel, clients);                           
                        }
                        break;

                    case "cnn":
                        break;
                    case "left":
                        Send("moveArrow|" + splitData[1] + "|50", reliableChannel, clients);
                        break;
                    case "right":
                        Send("moveArrow|" + splitData[1] + "|-50", reliableChannel, clients);
                        break;
                    case "stop":
                        Send("moveArrow|" + splitData[1] + "|0", reliableChannel, clients);
                        break;
                    case "fire":
                        Send("shoot|" + splitData[1] + "|1", reliableChannel, clients);
                        break;
                    /*case "score":
                        Send("scorepoints|" + splitData[1] + "|" + splitData[2], reliableChannel, clients);
                        break;*/
                }
                break;

            case NetworkEventType.DisconnectEvent:
                for (int i = 0; i < clients.Count; i++) {
                    if (clients[i].connectionId == connectionId) {
                        clients.RemoveAt(i);
                    }
                }
                break;
        }
        if (clients.Count >= 2) {
            int lastTime = (int)time;
            time -= Time.deltaTime;
            if ((int)time != lastTime) {
                Send("time|" + (int)time, reliableChannel, clients);
            }
            if ((int)time == 0) {
                Send("gameover|", reliableChannel, clients);
            }
        }
    }
    private void onConnection(int cnnId)
    {
        ServerClient c = new ServerClient();
        c.connectionId = cnnId;
        c.playerName = "temp";
        clients.Add(c);

        string msg = "askname|" + cnnId + "|";

        foreach (ServerClient sc in clients)
            msg += sc.playerName + "%" + sc.connectionId + '|';

        msg = msg.Trim('|');
        Send(msg, reliableChannel, cnnId);
    }

    private void Send(string message, int channelId, int cnnId)
    {
        List<ServerClient> c = new List<ServerClient>();
        c.Add(clients.Find(x => x.connectionId == cnnId));
        Send(message, channelId, c);
    }

    private void Send(string message, int channelId, List<ServerClient> c)
    {
        byte[] msg = Encoding.Unicode.GetBytes(message);
        foreach (ServerClient sc in c)
        {
            NetworkTransport.Send(hostId, sc.connectionId, channelId, msg, message.Length * sizeof(char), out error);
        }
    }

    private void OnNameIs(int cnnId, string playerName)
    {
        clients.Find(x => x.connectionId == cnnId).playerName = playerName;
        Send("cnn|" + playerName + '|' + cnnId, reliableChannel, clients);
    }
}
