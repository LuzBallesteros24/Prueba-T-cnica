using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessagePopUp : MonoBehaviour
{
    public TextMeshProUGUI popUpText; // Referencia al texto en la UI
    public float fadeDuration = 1f; // Duración del desvanecimiento
    public float displayDuration = 2f; // Tiempo que se muestra el mensaje

    private Coroutine currentCoroutine;

    public void ShowMessage(string message)
    {
        // Si hay un mensaje en proceso, lo detiene
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        // Inicia la rutina para mostrar el mensaje
        currentCoroutine = StartCoroutine(DisplayMessage(message));
    }

    private IEnumerator DisplayMessage(string message)
    {
        // Muestra el mensaje y ajusta la opacidad
        popUpText.text = message;
        Color color = popUpText.color;
        color.a = 1f; // Totalmente visible
        popUpText.color = color;

        // Espera el tiempo de visualización
        yield return new WaitForSeconds(displayDuration);

        // Desvanece el texto
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, elapsed / fadeDuration); // Reduce la opacidad
            popUpText.color = color;
            yield return null;
        }

        // Vacía el mensaje una vez desvanecido
        popUpText.text = "";
    }
}

