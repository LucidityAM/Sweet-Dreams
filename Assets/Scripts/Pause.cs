using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool jbToggle;
    public GameObject targetUI;
    public GameObject targetPlayer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            jbToggle = !jbToggle;
            if (jbToggle)
            {
                targetUI.SetActive(!targetUI.activeSelf);
                targetPlayer.GetComponent<PlayerControl>().enabled = false;
                targetPlayer.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            }
            else
            {
               
                targetUI.SetActive(!targetUI.activeSelf);
                targetPlayer.GetComponent<PlayerControl>().enabled = true;
            }
        }
    }
}
