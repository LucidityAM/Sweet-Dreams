using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMusicLow : MonoBehaviour
{
 
    public GameObject MC;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "fairy")
        {
            MC.GetComponent<AudioSource>().volume = .3f; 
        }
        else
        {
            MC.GetComponent<AudioSource>().volume = .6f;
        }
    }
}
