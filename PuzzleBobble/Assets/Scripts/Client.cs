﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Player
{
    public string playerName;
    public int posJugador;
    public GameObject avatar;
    public int connectId;
}

public class Client : MonoBehaviour {
    private const int MAX_CONNECTION = 100;
    private int port = 5701;

    private int hostId;
    private int webHostId;

    private int reliableChannel;
    private int unReliableChannel;

    private float connectionTime;
    private int connectionId;
    private bool isConnected;
    private bool isStarted = false;

    private byte error;
    public string playerName;
    private int ourClientId;

    public Transform jugador1, jugador2;


    public List<Player> players = new List<Player>();
    public GameObject playerPrefab;
    public GameObject canvas1;
    public GameObject canvas2;

    public void Connect()
    {
        string pName = GameObject.Find("namePlayer").GetComponent<InputField>().text;
        if (pName == "")
        {
            return;
        }
        playerName = pName;

        NetworkTransport.Init();
        ConnectionConfig cc = new ConnectionConfig();

        reliableChannel = cc.AddChannel(QosType.Reliable);
        unReliableChannel = cc.AddChannel(QosType.Unreliable);

        HostTopology hTopology = new HostTopology(cc, MAX_CONNECTION);

        hostId = NetworkTransport.AddHost(hTopology, 0);
        connectionId = NetworkTransport.Connect(hostId, "127.0.0.1", port, 0, out error);
        connectionTime = Time.time;
        isConnected = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isConnected)
        {
            return;
        }
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
            case NetworkEventType.DataEvent:
                string msg = Encoding.Unicode.GetString(recBuffer, 0, dataSize);
                string[] splitData = msg.Split('|');
                switch (splitData[0])
                {
                    case "askname":
                        OnAskName(splitData);
                        break;
                    case "cnn":
                        SpawnPlayer(splitData[1], int.Parse(splitData[2]));
                        break;
                    case "move":
                        players.Find(x => x.playerName == splitData[1]).avatar.transform.FindChild("Arrow").GetComponent<MoveArrow>().MoveArrowOne(int.Parse(splitData[2]));
                        break;
                    default:
                        Debug.Log("Mensaje Invalido" + msg);
                        break;
                }
                break;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Send("left|" + playerName, reliableChannel);
            Debug.Log(playerName);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Send("right|" + playerName, reliableChannel);
            Debug.Log(playerName);
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            Send("stop|" + playerName, reliableChannel);
        }
    }
    private void OnAskName(string[] data)
    {
        ourClientId = int.Parse(data[1]);
        Send("nameis|" + playerName, reliableChannel);
        for (int i = 2; i < data.Length - 1; i++)
        {
            string[] d = data[i].Split('%');
            SpawnPlayer(d[0], int.Parse(d[1]));
        }
    }
    private void Send(string message, int channelId)
    {
        //Debug.Log("Sending: " + message);
        byte[] msg = Encoding.Unicode.GetBytes(message);
        NetworkTransport.Send(hostId, connectionId, channelId, msg, message.Length * sizeof(char), out error);
    }

    public void Colision(string message)
    {
        //Debug.Log("Sending colision: " + message);
        byte[] msg = Encoding.Unicode.GetBytes(message);
        NetworkTransport.Send(hostId, connectionId, reliableChannel, msg, message.Length * sizeof(char), out error);

    }

    private void SpawnPlayer(string playerName, int cnnId)
    {
        if (cnnId == ourClientId)
        {
            canvas1.SetActive(false);
            canvas2.SetActive(true);

        }
        Player p = new Player();
        if (cnnId % 2 != 0)
        {
            p.avatar = Instantiate(playerPrefab, jugador1.position, Quaternion.identity);//con esto creo un jugador
        }
        else
        {
            p.avatar = Instantiate(playerPrefab, jugador2.position, Quaternion.identity);//con esto creo un jugador
        }
        p.playerName = playerName;
        p.connectId = cnnId;

        players.Add(p);
    }

    public int getClienteId()
    {
        return connectionId;
    }
}
