using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreamScript : MonoBehaviour
{
    public GameObject target;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
