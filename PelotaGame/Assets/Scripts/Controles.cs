using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Añadimos la librería TMPro necesaría para la UI
using TMPro;

public class Controles : MonoBehaviour
{
    // Llamamos al Rigidbody para realizar las físicas de empuje
    Rigidbody cuerpo;

    //Creamos los elementos correspondiente al eje_x y al eje_z
    float MX = 0.0f;
    float MZ = 0.0f;

    //Añadimos una variable pública para controlar la velocidad de nuestro personajes
    public float velocidad = 0.0f;

    //Iniciamos un void start para añadir elementos que queramos que estes permanente
    //mente activos nada mas iniciar el juego
    private void Start()
    {
        //Activamos el Rigidbody
        cuerpo = GetComponent<Rigidbody>();
    }

    //Iniciamos un void Update para añadir elementos que se ejecutan automáticamente y en 
    //ciclos
    private void Update()
    {
        //Creamos los controles de la pelota:
        //Para ello A les añadimos al los elementos MX y MZ un comando de movimiento que
        //funciona de la siguiente manera: Con el input nos introducimos en el Systema 
        //Input (Todo botón externo como los del teclado o ratón) y ahí buscamos el Axis
        //(El valor virtual que tienen las teclas) correspondiente a cada dirección,
        //horizontal (A-D) y vertical (W-S). Seguido de eso le multiplicamos la velocidad
        //para que pueda avanzar y le multiplicamos Time.deltaTime para que
        //funcione igual de rápido en todos los dispositivos
        MX = Input.GetAxis("Horizontal") * velocidad * Time.deltaTime;
        MZ = Input.GetAxis("Vertical") * velocidad * Time.deltaTime;

        //Una vez le damos a MX y MZ el comando de movimiento, usamos esas variables junto
        //con el comando transform.Translate que modifica la posición del jugador. Y al ser
        //MX y MZ valores que aumentan o disminuyen con nuestra acción dentro del juego,
        //podemos usarlos dentro de dicho comando para que se actualizen a la par. El comando
        //requiere de un valor para cada eje separados por una ",", de la siguiente manera:
        //transform.Translate(eje_x, eje_y, eje_z). Como no usaremos el eje_y le pondremos 
        //valor 0 y para la x y la z tenemos MX y MZ.
        transform.Translate(MX, 0.0f, MZ);
    }

    //ahora añadidmos un void FixedUpdate que tiene la misma función que el Update pero se usa
    //para física
    private void FixedUpdate()
    {
        //Ahora añadimos las físicas de impulso para cada eje gracias a ForceMode y AddForce que nos sirven
        //para especificar como aplicar una fuerza y para añadir dicha fuerza a un objeto, respectivamente
        //Dentro del AddForce añadimos un transform.right (hacia derecha) y lo multiplicamos por MX
        //para que se mueva en el eje x. Repetimos lo mismo para el otro eje cambiando el right por
        //forward (Hacia adelante) y multiplicandolo por la MZ
        cuerpo.AddForce(transform.right * MX, ForceMode.Impulse);
        cuerpo.AddForce(transform.forward * MZ, ForceMode.Impulse);
    }

}
