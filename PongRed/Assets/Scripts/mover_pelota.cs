using UnityEngine;
using System.Collections;

public class mover_pelota : MonoBehaviour
{
    private Transform miTransform;
    public Vector3 _velocidad;
    public float velocidad = 0;
    public GameObject cliente;
    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        miTransform = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //miTransform.Translate(Vector3.up * velocidad * Time.deltaTime);
        miTransform.Translate(_velocidad * velocidad * Time.deltaTime);

   }

    public void MoverPelota(float velocidad, Vector3 _velocidad)
    {
        this._velocidad=new Vector3(_velocidad.x,_velocidad.y,_velocidad.z);
        this.velocidad = velocidad;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //cuando choco
        string NombreJugColi = cliente.GetComponent<Cliente>().playerName + "";
        string jugador1 = cliente.GetComponent<Cliente>().jugadores[0].playerName;
        Debug.Log("Colision de jugador " + NombreJugColi);
        if (other.transform.tag.Equals("Barra"))
        {
            cliente.GetComponent<Cliente>().Colision("PELOTACHOQUEPALAS|");
        }else if (other.transform.tag.Equals("Pared") && NombreJugColi == jugador1)
        {
            cliente.GetComponent<Cliente>().Colision("PELOTACHOQUEFONDO|");
            Debug.Log("ENTRAAAAAA");
        }
        else if (other.transform.tag.Equals("Suelo") && NombreJugColi == jugador1 || other.transform.tag.Equals("Techo") && NombreJugColi == jugador1)
        {
            Debug.Log("ENTRAAAAAA");
            cliente.GetComponent<Cliente>().Colision("PELOTACHOQUESUELOTECHO|");
        }
    }
        
}

