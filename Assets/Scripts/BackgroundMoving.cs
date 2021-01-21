using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoving : MonoBehaviour
{
    public static float step;
    public bool isStopped;
    public GameObject targetUI;
    public GameObject targetPlayer;
    public GameObject Background;
    public bool jbToggle;


    // Start is called before the first frame update

    void Start()
    {
        step = .06f;
        isStopped = false;
        jbToggle = false;
    }

    // Update is called once per frame

    void Update()
    {
        var midgroundPosition = Background.gameObject.transform.position;
        midgroundPosition.x += step;
        Background.gameObject.transform.position = midgroundPosition;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            jbToggle = !jbToggle;
            if (jbToggle)
            {
                isStopped = true;
                step = 0.0f;
                targetUI.SetActive(!targetUI.activeSelf);
                targetPlayer.GetComponent<PlayerControl>().enabled = false;
                targetPlayer.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            }
            else
            {
                isStopped = false;
                step = 0.1f;
                targetUI.SetActive(!targetUI.activeSelf);
                targetPlayer.GetComponent<PlayerControl>().enabled = true;
            }
        }
    }
}