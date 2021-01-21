using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb2;
    public float wait = 1.5f;
    public float stop = 0f;
    public bool Destroyable;
  

    Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
        rb2.velocity = -transform.right * speed;
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "camera border" || collision.gameObject.tag == "emush" || collision.gameObject.tag == "MainCamera")
        {
            rb2.velocity = transform.right * stop;
            anim.SetBool("Collided", true);
            AutoScrollCamera.step = 0.0f;
            BonusScroll.step = 0;
            BackgroundMoving.step = 0.0f;
            MidgroundMoving.step = 0.0f;
            AutoScrollCamera.run = false;
            BonusScroll.run = false;
            Invoke("UnPause", 2.6f);
            Destroyable = true;
            Invoke("Destroy", 2);
            

        }
    }
          
    void UnPause()
    {

        AutoScrollCamera.run = true;
        BonusScroll.run = true;
        AutoScrollCamera.step = 0.15f;
        BonusScroll.step = 0.15f;
        BackgroundMoving.step = 0.06f;
        MidgroundMoving.step = 0.03f;
    }
    void Update()
    {

    }

    void Destroy()
    {
        if (Destroyable == true)
        {
            Destroy(gameObject, .65f);
        }
    }

  
}
