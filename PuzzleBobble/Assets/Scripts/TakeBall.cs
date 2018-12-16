using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBall : MonoBehaviour {
    public GameObject PJ_0_TakingBall;

    public void shootBall()
    {
        PJ_0_TakingBall.GetComponent<Animator>().SetTrigger("TakeBall");
    }
}
