using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovil : MonoBehaviour {
    private Transform miTransform;
    public float velocidad;
    public string direccion;
    public float tiempo;
    private float tiempoActual;

	// Use this for initialization
	void Start () {
        miTransform = this.transform;
        tiempoActual = 0;
	}
	
	// Update is called once per frame
	void Update () {
        tiempoActual += Time.deltaTime;
        if (direccion.Equals("Horizontal")) {
            miTransform.Translate(Vector3.right * velocidad * Time.deltaTime);
        } else {
            miTransform.Translate(Vector3.up * velocidad * Time.deltaTime);
        }

        if (tiempoActual >= tiempo) {
            cambiarDireccion();
        }
	}

    private void cambiarDireccion() {
        velocidad *= -1;
        tiempoActual = 0;
    }
}
