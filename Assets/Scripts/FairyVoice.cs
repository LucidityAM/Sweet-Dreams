using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyVoice : MonoBehaviour
{

    AudioSource audioSrc;

    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "player")
        {
            audioSrc.Play();
        }
        else
        {
            audioSrc.Stop();
        }
    }
}
