using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightmareEntrance : MonoBehaviour
{
    public float DT;
    public bool timeHasPassed;
    public GameObject Nightmare;

    Animator anim;
    SpriteRenderer sr;

    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        DT += Time.deltaTime;

        if(DT > 3.4f)
        {
            anim.SetBool("timeHasPassed", true);
            Nightmare.GetComponent<Animator>().enabled = true;
        }

        if(DT > 4)
        {
            Disable();
        }

    }

    public void Disable()
    {
        sr.enabled = false;
        anim.enabled = false;
    }
  
}
