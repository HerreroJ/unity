using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArrow : MonoBehaviour {
    private Transform miTransform;
    private int rotationPerSec;

    // Use this for initialization
    void Start()
    {
        miTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = rotationPerSec * Time.deltaTime;
        float actualRotation = miTransform.localRotation.eulerAngles.z;
        miTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, actualRotation + rotation));
    }
    public void MoveArrowOne(int speed)
    {
        this.rotationPerSec = speed;
    }

    public Vector3 GetShootDirection() {
        return miTransform.Find("PuntoLejano").transform.position - miTransform.Find("PuntoCentro").transform.position;
    }
}
