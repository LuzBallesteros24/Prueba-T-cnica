using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float velocidad = 5f;
    public GameObject panelPerdiste; // Referencia al panel de "Perdiste"

    void Update()
    {
        // Obtener entrada del jugador
        float movimientoHorizontal = 0f;
        float movimientoVertical = 0f;

        // Movimiento controlado solo por las flechas
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movimientoHorizontal = -1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            movimientoHorizontal = 1f;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movimientoVertical = 1f;
        }

        // Movimiento hacia los lados y adelante
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical) * velocidad * Time.deltaTime;

        // Aplicar movimiento al jugador
        transform.Translate(movimiento);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Si colisiona con un Cubo_Object
        if (other.CompareTag("Cubo_Object"))
        {
            // Mostrar el panel de "Perdiste"
            panelPerdiste.SetActive(true);

            // Opcional: Detener el movimiento del jugador
            this.enabled = false;

            // Opcional: Detener la física del jugador
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.isKinematic = true;
            }
        }
    }
}

