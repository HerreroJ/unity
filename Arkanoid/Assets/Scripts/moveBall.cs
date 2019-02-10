using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBall : MonoBehaviour
{
    public int speed; //es el módulo del vector de la velocidad
    private Transform mTransform; //representa el sprite de la pelota
    public Vector3 _speed; //representa el vector de la velocidad para controlar dirección y sentido

    public GameObject gameOver;
    //se ejecuta al instanciar el script. Tomará la referencia el transform.
    void Start()
    {
        mTransform = this.transform;
    }

    // es la función que se ejecuta de forma periódica en el juego. Modifica la
    //posición de la pelota multiplicando el módulo por el vector y por el tiempo transcurrido
    //en cada vuelta del bucle.
    void Update()
    {
        transform.Translate(_speed * speed * Time.deltaTime);
    }

    //es la función que se ejecuta al detectar una colisión entre objetos
    //CADA VEZ QUE LA PELOTA COLISIONA CON ALGUNO DE LOS DELIMITADORES DEL CAMPO
    void OnTriggerEnter2D(Collider2D ball)
    {
        //CON CUALQUIERA DE LAS DOS PAREDES O COLUMNAS
        if (ball.transform.tag.Equals("wall"))
        {
            _speed.x *= -1;
            //CON EL TECHO
        }
        else if (ball.transform.tag.Equals("roof"))
        {
            _speed.y *= -1;
        }
        //CON EL SUELO
        else if (ball.transform.tag.Equals("floor"))
        {
            //Parar el juego
            Time.timeScale = 0;
            //Activar el fin del juego
            gameOver.SetActive(true);
        }
        //CON LA PALA
        else if (ball.transform.tag.Equals("shovel"))
        {
            _speed.y *= -1;
        }
        //CON LOS BLOQUES
        else if (ball.transform.tag.Equals("blockUp"))
        {
            _speed.y *= -1;
            //Destruye el objeto
            Destroy(ball.transform.parent.gameObject);
        }
        else if (ball.transform.tag.Equals("blockSide"))
        {
            _speed.x *= -1;
            //Destruye el objeto
            Destroy(ball.transform.parent.gameObject);
        }
        else if (ball.transform.tag.Equals("blockDown"))
        {
            _speed.y *= -1;
            //Destruye el objeto
            Destroy(ball.transform.parent.gameObject);
        }
    }
}
