using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverFlecha : MonoBehaviour {
    private Transform miTransform;
    public float rotacion;
    public float rotacionActual = 0;
    public int velocidad;

    // Use this for initialization
    void Start() {
        miTransform = this.transform;
    }

    // Update is called once per frame
    void Update() {

        float rotacion = velocidad * Time.deltaTime;
        float rotacionActual = miTransform.localRotation.eulerAngles.z;
        miTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, rotacionActual + rotacion));

    }

    public void CambiarDireccion(int velo) {
        this.velocidad = velo;
    }
}
