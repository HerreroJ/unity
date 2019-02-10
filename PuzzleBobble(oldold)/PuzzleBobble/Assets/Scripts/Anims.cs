using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anims : MonoBehaviour {
    public GameObject PJ_0_TakingBall;
    public GameObject blower;

    public void takeBall() {
        PJ_0_TakingBall.GetComponent<Animator>().SetTrigger("TakeBall");
    }

    public void shootBall() {
        blower.GetComponent<Animator>().SetTrigger("ShootBall");
    }
}
