using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSource;


    void Start()
    {
        
    }


    void Update()
    {

        
    }

    private void OnTriggerEnter(Collider other)
    {

        audioSource.Play();
        
    }
}
