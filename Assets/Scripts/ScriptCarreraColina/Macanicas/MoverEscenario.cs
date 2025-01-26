using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEscenario : MonoBehaviour
{
    [SerializeField] GameObject escenario;
    [SerializeField] GameObject personaje1; // Referencia al primer personaje
    [SerializeField] GameObject personaje2; // Referencia al segundo personaje
    [SerializeField] float velocidadEscenario = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (personaje1 != null && personaje2 != null)
        {
            // Calcula la posición media de los personajes
            Vector3 posicionMedia = (personaje1.transform.position + personaje2.transform.position) / 2;
            Debug.Log("Posición media de los personajes: " + posicionMedia);
            MoverEnFuncionDelPersonaje(posicionMedia);
        }
    }

    // Método para mover el escenario en función de la posición del personaje
    public void MoverEnFuncionDelPersonaje(Vector3 posicionPersonaje)
    {
        Vector3 nuevaPosicion = escenario.transform.position;
        nuevaPosicion.x = posicionPersonaje.x * velocidadEscenario;
        nuevaPosicion.y = posicionPersonaje.y * velocidadEscenario; // Añadido para mover en y
        escenario.transform.position = nuevaPosicion;
    }
}
