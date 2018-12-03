using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPelota : MonoBehaviour {

    public int velocidad;
    public Vector3 _velocidad;
    public GameObject gameOver;
    public GameObject btnReintentar;
    private Transform miTransform;

	// Use this for initialization
	void Start () {
        miTransform = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
        miTransform.Translate(_velocidad * velocidad * Time.deltaTime);
    }

    //Cuando choca con cualquier elemento 2D
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag.Equals("columna"))
        {
            _velocidad.x *= -1;
        }
        else if (other.transform.tag.Equals("techo"))
        {
            _velocidad.y *= -1;
        }
        else if (other.transform.tag.Equals("suelo"))
        {
            //Parar el juego
            Time.timeScale = 0;

            //Activar Game Over
            gameOver.SetActive(true);
            btnReintentar.SetActive(true);
        }
        else if (other.transform.tag.Equals("pala"))
        {
            _velocidad.y *= -1;
        }
        else if (other.transform.tag.Equals("bloqueArriba") || 
                other.transform.tag.Equals("bloqueAbajo"))
        {
            //Cambiamos la direccion de la pelota
            _velocidad.y *= -1;

            //Destruimos el objeto
            Destroy(other.transform.parent.gameObject);

            //Buscamos el objeto padre
            GameObject.Find("Padre").gameObject.GetComponent<Control>().comprobarHijos();
        }
        else if (other.transform.tag.Equals("bloqueLaterales"))
        {
            //Cambiar la direccion de la pelota
            _velocidad.x *= -1;

            //Destruimos el objeto
            Destroy(other.transform.parent.gameObject);

            //Buscamos el objeto padre
            GameObject.Find("Padre").gameObject.GetComponent<Control>().comprobarHijos();
        }
    }
}
