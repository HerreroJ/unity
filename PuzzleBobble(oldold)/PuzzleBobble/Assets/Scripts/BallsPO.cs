using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsPO : MonoBehaviour {
    public GameObject[] balls;
    private List<GameObject> ballLists = new List<GameObject>();
    public GameObject BallPosSack;
    public GameObject BallPosArrow;
    public GameObject position;

    public void fillBalls(string nmb) {
        string[] nm = nmb.Split('.'); 
        for(int i = 0; i < nm.Length - 1; i++){
            ballLists.Add(Instantiate(balls[int.Parse(nm[i])], transform.position, Quaternion.identity));
        }       
    }

    public void CreateBallsSack(Vector3 pos) {       
        GameObject putBalls = ballLists[1];
        Debug.Log(ballLists[1]);
        ballLists.RemoveAt(1);
        putBalls.transform.position = pos;
        putBalls.SetActive(true);
        //putBalls.transform.parent = null;
    }
    public void CreateBallArrow(Vector3 pos) {
        GameObject shootBall = ballLists[0];
        Debug.Log(ballLists[0]);
        ballLists.RemoveAt(0);   
        shootBall.transform.position = pos;
        shootBall.SetActive(true);
        //shootBall.transform.parent = null;
    }
}
