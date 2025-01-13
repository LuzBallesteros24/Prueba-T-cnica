using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PistaInfinita : MonoBehaviour
{
    public GameObject jugador; // Referencia al jugador
    public GameObject segmentoPrefab; // Prefab de la pista
    public int numeroSegmentos = 5; // Número inicial de segmentos activos
    public float longitudSegmento = 10f; // Longitud de cada segmento

    private Queue<GameObject> segmentos; // Cola para manejar los segmentos

    void Start()
    {
        // Inicializar la cola
        segmentos = new Queue<GameObject>();

        // Crear los segmentos iniciales
        for (int i = 0; i < numeroSegmentos; i++)
        {
            Vector3 posicion = new Vector3(0, 0, i * longitudSegmento);
            AgregarSegmento(posicion);
        }
    }

    void Update()
    {
        // Verificar si el jugador ha avanzado más allá del primer segmento
        if (jugador.transform.position.z > segmentos.Peek().transform.position.z + longitudSegmento)
        {
            // Mueve el segmento más antiguo al final de la pista
            GameObject segmentoAntiguo = segmentos.Dequeue();
            segmentoAntiguo.transform.position = segmentos.ToArray()[segmentos.Count - 1].transform.position + new Vector3(0, 0, longitudSegmento);
            segmentos.Enqueue(segmentoAntiguo);
        }
    }

    void AgregarSegmento(Vector3 posicion)
    {
        // Instanciar un nuevo segmento y agregarlo a la cola
        GameObject nuevoSegmento = Instantiate(segmentoPrefab, posicion, Quaternion.identity);
        segmentos.Enqueue(nuevoSegmento);
    }
}

