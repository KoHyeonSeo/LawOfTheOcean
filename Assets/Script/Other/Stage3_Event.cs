using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_Event : MonoBehaviour
{
    private AudioSource audioSource;
    private bool once = true;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (once && other.gameObject.CompareTag("Player"))
        {
            audioSource.Play();
            once = false;
        }
    }
}
