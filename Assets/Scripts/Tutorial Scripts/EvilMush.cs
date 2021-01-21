using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilMush : MonoBehaviour
{
    public GameObject target;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ball"))
        {
            target.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
