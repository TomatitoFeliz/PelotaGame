using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A�adimos la librer�a TMPro necesar�a para la UI
using TMPro;

public class Controles : MonoBehaviour
{
    // Llamamos al Rigidbody para realizar las f�sicas de empuje
    Rigidbody cuerpo;

    //Creamos los elementos correspondiente al eje_x y al eje_z
    float MX = 0.0f;
    float MZ = 0.0f;

    //A�adimos una variable p�blica para controlar la velocidad de nuestro personajes
    public float velocidad = 0.0f;

    //Iniciamos un void start para a�adir elementos que queramos que estes permanente
    //mente activos nada mas iniciar el juego
    private void Start()
    {
        //Activamos el Rigidbody
        cuerpo = GetComponent<Rigidbody>();
    }

    //Iniciamos un void Update para a�adir elementos que se ejecutan autom�ticamente y en 
    //ciclos
    private void Update()
    {
        //Creamos los controles de la pelota:
        //Para ello A les a�adimos al los elementos MX y MZ un comando de movimiento que
        //funciona de la siguiente manera: Con el input nos introducimos en el Systema 
        //Input (Todo bot�n externo como los del teclado o rat�n) y ah� buscamos el Axis
        //(El valor virtual que tienen las teclas) correspondiente a cada direcci�n,
        //horizontal (A-D) y vertical (W-S). Seguido de eso le multiplicamos la velocidad
        //para que pueda avanzar y le multiplicamos Time.deltaTime para que
        //funcione igual de r�pido en todos los dispositivos
        MX = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        MZ = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;

        //Una vez le damos a MX y MZ el comando de movimiento, usamos esas variables junto
        //con el comando transform.Translate que modifica la posici�n del jugador. Y al ser
        //MX y MZ valores que aumentan o disminuyen con nuestra acci�n dentro del juego,
        //podemos usarlos dentro de dicho comando para que se actualizen a la par. El comando
        //requiere de un valor para cada eje separados por una ",", de la siguiente manera:
        //transform.Translate(eje_x, eje_y, eje_z). Como no usaremos el eje_y le pondremos 
        //valor 0 y para la x y la z tenemos MX y MZ.
        transform.Translate(MX, 0.0f, MZ);
    }

    //ahora a�adidmos un void FixedUpdate que tiene la misma funci�n que el Update pero se usa
    //para f�sica
    private void FixedUpdate()
    {
        //Ahora a�adimos las f�sicas de impulso para cada eje gracias a ForceMode y AddForce que nos sirven
        //para especificar como aplicar una fuerza y para a�adir dicha fuerza a un objeto, respectivamente
        //Dentro del AddForce a�adimos un transform.right (hacia derecha) y lo multiplicamos por MX
        //para que se mueva en el eje x. Repetimos lo mismo para el otro eje cambiando el right por
        //forward (Hacia adelante) y multiplicandolo por la MZ
        cuerpo.AddForce(transform.right * MX, ForceMode.Impulse);
        cuerpo.AddForce(transform.forward * MZ, ForceMode.Impulse);
    }

}
