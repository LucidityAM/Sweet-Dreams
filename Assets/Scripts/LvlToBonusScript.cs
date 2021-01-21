using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlToBonusScript : MonoBehaviour
{
    public GameObject mainPlayer;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player" && (float)mainPlayer.GetComponent<PlayerControl>().dream == 13)
        {
            SceneManager.LoadScene("Bonus Level");
            
        }

        if (collision.gameObject.tag == "player" && (float)mainPlayer.GetComponent<PlayerControl>().dream >= 9 && (float)mainPlayer.GetComponent<PlayerControl>().dream < 13)
        {
            SceneManager.LoadScene("Win");
        }

        if (collision.gameObject.tag == "player" && (float)mainPlayer.GetComponent<PlayerControl>().dream < 9)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
