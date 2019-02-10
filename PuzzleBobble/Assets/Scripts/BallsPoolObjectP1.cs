using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsPoolObjectP1 : MonoBehaviour {
    public GameObject[] balls;
    //private GameObject shootBall;
    private List<GameObject> ballListsP1 = new List<GameObject>();
    public GameObject BallPosSack;
    public GameObject BallPosArrow;
    private GameObject ArrowBall;
    //private int count = 0;

    public void fillBallsP1(string nmb) {
        string[] nm = nmb.Split('.');

        for (int i = 0; i < nm.Length - 1; i++) {
            ballListsP1.Add(Instantiate(balls[int.Parse(nm[i])], BallPosSack.transform.position, Quaternion.identity));
        }
    }

    public void CreateBallsSackP1(Vector3 pos) {
        GameObject putBalls = ballListsP1[0];
        //ballLists.RemoveAt(1);
        putBalls.transform.position = pos;
        putBalls.SetActive(true);
        putBalls.transform.parent = null;       
    }
    public void CreateBallArrowP1(Vector3 pos) {
        GameObject shootBall = ballListsP1[0];
        ArrowBall = ballListsP1[0];
        ballListsP1.RemoveAt(0);
        shootBall.transform.position = pos;
        shootBall.SetActive(true);
        shootBall.transform.parent = null;
        /*count++;
        if (count >= ballListsP1.Count) {
            count = 0;
        }*/
    }
    public GameObject GetP1CurrentBall() {
        return ArrowBall;
    }
}
