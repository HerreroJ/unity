﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotar : MonoBehaviour {
    private Transform miTransform;
    private float rotacionPorSeg = -2880f;
	// Use this for initialization
	void Start () {
        miTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        float rotacion = rotacionPorSeg * Time.deltaTime;
        float rotacionActual = miTransform.localRotation.eulerAngles.z;
        miTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, rotacionActual + rotacion));
	}
}
