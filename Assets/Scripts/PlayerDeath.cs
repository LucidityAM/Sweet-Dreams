using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public GameObject targetUI;
    public GameObject targetCountdown;
    public GameObject MainCamera;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D collision)
    { 
        if(collision.tag == "camera border" || collision.tag == "death")
        {
            Destroy(gameObject);
            targetUI.SetActive(!targetUI.activeSelf);
            targetCountdown.SetActive(!targetCountdown.activeSelf);
            AutoScrollCamera.step = 0.0f;
            BackgroundMoving.step = 0.0f;
            MidgroundMoving.step = 0.0f;

            AutoScrollCamera.run = false;

        }

       
    }


    
    
}
