using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        float movimientoHorizontal = 0f;
        float movimientoVertical = 0f;

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

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, movimientoVertical) * velocidad * Time.deltaTime;

        transform.Translate(movimiento);
    }
}
