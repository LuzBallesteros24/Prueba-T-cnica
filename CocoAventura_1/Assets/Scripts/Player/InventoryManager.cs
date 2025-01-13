using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public GameObject panelInventario; // Panel del inventario
    public Sprite coquitoSprite; // Sprite del Coquito
    private PlayerMovement playerMovement; // Referencia al script del jugador
    private MessagePopUp messagePopUp; // Referencia al sistema de mensajes

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>(); // Encuentra al jugador
        messagePopUp = FindObjectOfType<MessagePopUp>(); // Encuentra el sistema de mensajes
    }

    public void AgregarCoquito()
    {
        foreach (Transform slot in panelInventario.transform)
        {
            Button boton = slot.GetComponent<Button>();
            if (boton != null && boton.image.sprite == null) // Encuentra un botón vacío
            {
                boton.image.sprite = coquitoSprite; // Asigna el sprite del Coquito
                boton.image.color = Color.white; // Asegúrate de que sea visible
                boton.onClick.AddListener(() => UsarCoquito(boton)); // Añade el evento de clic
                return;
            }
        }

        Debug.Log("Inventario lleno. No se puede agregar más Coquitos.");
    }

    public void UsarCoquito(Button boton)
    {
        // Cambiar velocidad del jugador de forma aleatoria
        float randomChange = Random.Range(-2f, 2f); // Cambios entre -2 y 2
        playerMovement.velocidad += randomChange;

        // Mostrar el mensaje correspondiente
        if (randomChange > 0)
        {
            messagePopUp.ShowMessage("¡Velocidad aumentada!");
        }
        else
        {
            messagePopUp.ShowMessage("¡Velocidad reducida!");
        }

        // Vaciar el botón del inventario
        boton.image.sprite = null;
        boton.image.color = new Color(1, 1, 1, 0); // Hacerlo transparente
        boton.onClick.RemoveAllListeners(); // Quitar el evento de clic
    }
}




