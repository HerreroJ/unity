using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrenchRotate : MonoBehaviour {
    public Transform miTransform;
    public void FirstMove() { miTransform.rotation = Quaternion.Euler(0, 0, -25); }
    public void SecondMove() { miTransform.rotation = Quaternion.Euler(0, 0, -75); }
    public void ThirdMove() { miTransform.rotation = Quaternion.Euler(0, 0, -120); }
    public void FourthMove() { miTransform.rotation = Quaternion.Euler(0, 0, -180); }
    public void FifthMove() { miTransform.rotation = Quaternion.Euler(0, 0, -220); }
    public void SixthMove() { miTransform.rotation = Quaternion.Euler(0, 0, -270); }
    public void SeventhMove() { miTransform.rotation = Quaternion.Euler(0, 0, -305); }
    public void EightMove() { miTransform.rotation = Quaternion.Euler(0, 0, -360); }
}
