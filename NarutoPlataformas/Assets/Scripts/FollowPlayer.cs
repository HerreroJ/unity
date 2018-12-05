using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform miTransform;
    public Transform posJugador;
    public float difJugador;

	// Use this for initialization
	void Start ()
    {
        miTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        miTransform.position = new Vector3(posJugador.position.x + difJugador, posJugador.position.y, -10);
	}
}
