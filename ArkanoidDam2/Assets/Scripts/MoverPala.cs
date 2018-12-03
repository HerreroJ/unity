using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPala : MonoBehaviour {
    public int velocidad;
    private Transform miTransform;

	// Use this for initialization
	void Start ()
    {
        miTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            if(miTransform.position.x > -2.3)
            miTransform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (miTransform.position.x < 2.5)
            miTransform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }		
	}
}
