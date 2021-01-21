using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTextAppear : MonoBehaviour
{
    public GameObject targetText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            targetText.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            targetText.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
