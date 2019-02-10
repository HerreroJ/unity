using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveShovel : MonoBehaviour {
    private Transform mTransform;
    public int speed;
	// Use this for initialization
	void Start () {
        mTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            mTransform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow)) {
            mTransform.Translate(Vector3.right * speed * Time.deltaTime);
        }
	}
}
