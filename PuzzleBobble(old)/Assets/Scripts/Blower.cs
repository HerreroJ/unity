using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blower : MonoBehaviour {
    public GameObject blower;

    public void shootBall()
    {
        blower.GetComponent<Animator>().SetTrigger("ShootBall");
    }
}
