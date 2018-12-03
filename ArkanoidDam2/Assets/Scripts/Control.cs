using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour {
    public GameObject[] niveles;
    static public int nivelActual = 0;
    public Transform padre;
    private bool final;
    public GameObject win;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("nivel " + nivelActual);
        //Instanciar el nivel actual
        final = false;
        padre = (Instantiate(niveles[nivelActual]) as GameObject).transform;
    }
	
    public void comprobarHijos()
    {
        //Comprobar cuantos hijos tiene el objeto
        Debug.Log("num hijos = " + padre.childCount);

        if(padre.childCount == 1 && !final)
        {
            activarPanel();
            final = true;
        }
    }

    public void activarPanel()
    {
        Control.nivelActual++;
        if(Control.nivelActual >= niveles.Length)
        {
            Time.timeScale = 0;
            win.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
