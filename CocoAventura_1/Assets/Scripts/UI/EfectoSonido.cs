using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EfectoSonido : MonoBehaviour
{
    public AudioClip sonido; // Arrastra tu archivo de audio aquí
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ReproducirSonido()
    {
        audioSource.PlayOneShot(sonido);
    }
}

