﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //Cargar la escena de nombre Arkanoid
    public void jugar() {
        SceneManager.LoadScene("Arkanoid");
    }

}