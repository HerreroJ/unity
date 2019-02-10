using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsPoolObjectP2 : MonoBehaviour {
    public GameObject[] balls;
    //private GameObject shootBall;
    private List<GameObject> ballListsP2 = new List<GameObject>();
    public GameObject BallPosSack;
    public GameObject BallPosArrow;
    private GameObject ArrowBall;

    public void fillBallsP2(string nmb) {
        string[] nm = nmb.Split('.');

        for (int i = 0; i < nm.Length - 1; i++) {
            ballListsP2.Add(Instantiate(balls[int.Parse(nm[i])], BallPosSack.transform.position, Quaternion.identity));
        }
    }

    public void CreateBallsSackP2(Vector3 pos) {
        GameObject putBalls = ballListsP2[0];
        //ballLists.RemoveAt(1);
        putBalls.transform.position = pos;
        putBalls.SetActive(true);
        putBalls.transform.parent = null;
    }
    public void CreateBallArrowP2(Vector3 pos) {
        GameObject shootBall = ballListsP2[0];
        ArrowBall = ballListsP2[0];
        ballListsP2.RemoveAt(0);
        shootBall.transform.position = pos;
        shootBall.SetActive(true);
        shootBall.transform.parent = null;
    }
    public GameObject GetP2CurrentBall() {
        return ArrowBall;
    }
}
