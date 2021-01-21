using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingPortal : MonoBehaviour
{
    public GameObject mainPlayer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player" && (float)mainPlayer.GetComponent<BonusControl>().dream == 5)
        {
            SceneManager.LoadScene("Bonus Win");
        }

        if (collision.gameObject.tag == "player" && (float)mainPlayer.GetComponent<BonusControl>().dream < 5)
        {
            SceneManager.LoadScene("Lose");
        }

    }

}    
