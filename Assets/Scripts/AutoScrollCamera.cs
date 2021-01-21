using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoScrollCamera : MonoBehaviour
{
    public static float step;
    public bool isStopped;
    public GameObject targetUI;
    public GameObject targetPlayer;
    public GameObject targetBackground;
    public GameObject targetMidground;
    public GameObject MCamera;
    public Text countdown;
    public GameObject Count;
    public bool jbToggle;
    public float deltaT;
    public static bool run;
    public static float running = 0;


    // Start is called before the first frame update

    void Start()
    {
        step = 0f;
        targetBackground.GetComponent<BackgroundMoving>().enabled = false;
        targetMidground.GetComponent<MidgroundMoving>().enabled = false;
        deltaT = 0;
        isStopped = false;
        jbToggle = false;
    }

    // Update is called once per frame

    void Update()
    {
        deltaT += Time.deltaTime;

        var cameraPosition = Camera.main.gameObject.transform.position;
        cameraPosition.x += step;
        Camera.main.gameObject.transform.position = cameraPosition;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            jbToggle = !jbToggle;
            if (jbToggle)
            {
                isStopped = true;
                run = false;
                running = 0;
                step = 0.0f;
                targetUI.SetActive(!targetUI.activeSelf);
                targetPlayer.GetComponent<PlayerControl>().enabled = false;
                targetPlayer.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            }
            else
            {
                run = true;
                running = 1;
                isStopped = false;
                step = 0.15f;
                targetUI.SetActive(!targetUI.activeSelf);
                targetPlayer.GetComponent<PlayerControl>().enabled = true;
            }
        }

        if(deltaT > 0 && deltaT < 1)
        {
            countdown.text = "3".ToString();
            run = false;
            targetPlayer.GetComponent<PlayerControl>().moveForce = 0;
            targetPlayer.GetComponent<PlayerControl>().jumpForce = 0;
            targetPlayer.GetComponent<PlayerStats>().energy = 0;
        }

        if (deltaT > 1 && deltaT < 2)
        {
            countdown.text = "2".ToString();
            run = false;
            targetPlayer.GetComponent<PlayerControl>().moveForce = 0;
            targetPlayer.GetComponent<PlayerControl>().jumpForce = 0;
            targetPlayer.GetComponent<PlayerStats>().energy = 0 ;
        }

        if (deltaT > 2 && deltaT < 3)
        {
            countdown.text = "1".ToString();
            run = false;
            targetPlayer.GetComponent<PlayerControl>().moveForce = 0;
            targetPlayer.GetComponent<PlayerControl>().jumpForce = 0;
            targetPlayer.GetComponent<PlayerStats>().energy= 0;
        }

        if (deltaT > 3 && deltaT < 4)
        {
            countdown.text = "Begin".ToString();
            run = false;
            targetPlayer.GetComponent<PlayerControl>().moveForce = 0;
            targetPlayer.GetComponent<PlayerControl>().jumpForce = 0;
            targetPlayer.GetComponent<PlayerStats>().energy = 0;
        }

        if (deltaT > 4 && deltaT < 4.1f)
        {
            Count.SetActive(false);
            countdown.text = "".ToString();
            run = true;
            targetPlayer.GetComponent<PlayerControl>().moveForce = 9;
            targetPlayer.GetComponent<PlayerControl>().jumpForce = 8;
            targetPlayer.GetComponent<PlayerStats>().energy = 25;

        }
        

        if(run == true)
        {
            
            step = .15f;
            MCamera.GetComponent<AutoScrollCamera>().enabled = true;
            targetBackground.GetComponent<BackgroundMoving>().enabled = true;
            targetMidground.GetComponent<MidgroundMoving>().enabled = true;
        }
        else if (run == false)
        {
            step = 0f;
            targetBackground.GetComponent<BackgroundMoving>().enabled = false;
            targetMidground.GetComponent<MidgroundMoving>().enabled = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ball")
        {
             run = false;
        }
    }
}