using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {
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
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
