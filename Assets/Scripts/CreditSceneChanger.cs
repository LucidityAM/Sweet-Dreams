using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditSceneChanger : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("Credits");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene("Bonus Level");
        }
    }
}
