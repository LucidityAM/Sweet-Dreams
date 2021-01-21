using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Audio : MonoBehaviour
{

    AudioSource audioSrc;

    public GameObject cameraBorder1;
    public GameObject cameraBorder2;
    public GameObject cameraBorder3;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player" || collision.tag == "death")
        {
            if (audioSrc.isPlaying)
               
            cameraBorder1.GetComponent<AudioSource>().volume = 0;
            cameraBorder2.GetComponent<AudioSource>().volume = 0;
            cameraBorder3.GetComponent<AudioSource>().volume = 0;
        }
      
    }
}
