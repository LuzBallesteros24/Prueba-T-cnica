using System.Collections;
using System.Collections.Generic;
// Movimiento del jugador en Unity usando C#
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidad = 5f;

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
}

