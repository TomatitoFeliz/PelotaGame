using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetivo : MonoBehaviour
{
    //Primero creamos la variable Monedas y le pones de valor 0, ya que no queremos empezar
    //con monedas ya obtenidas
    float Monedas = 0f;

    //Creamos un onTriggerEnter para que al tocar los objetos con el tag "Moneda" estos 
    //desaparezcan y además que aumente su "valor" en 1 simulando que la hemos recogido
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Moneda")
        {
            other.gameObject.SetActive(false);
            Monedas = Monedas + 1;
        }
    }
}
