using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBall : MonoBehaviour {
    public GameObject arrow;
    public Vector3 direction = Vector3.zero;
	
	void Update () {
        transform.Translate(direction * 1 * Time.deltaTime);
	}
    public void SetShootDirection(Vector3 direction) {
        this.direction = direction;
    }
}
