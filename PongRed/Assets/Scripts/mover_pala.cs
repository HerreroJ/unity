using UnityEngine;
using System.Collections;

public class mover_pala : MonoBehaviour {

    private Transform miTransform;
    public int velocidad;
    // Use this for initialization
    void Start()
    {
        miTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (miTransform.position.y >= 3.6f && velocidad < -1)
        {
            velocidad = 0;
        } else if (miTransform.position.y <= -3.6f && velocidad > 1) {
            velocidad = 0;
        }
        miTransform.Translate(Vector3.down * velocidad * Time.deltaTime);
        
    }

    public void CambiarDireccion(int velo) {
        this.velocidad = velo;
    }

}
