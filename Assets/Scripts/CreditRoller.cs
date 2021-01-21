using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditRoller : MonoBehaviour
{
    private static int nScreens = 8;
    private GameObject[] creditScenes = new GameObject[nScreens];
    private static int swapCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        creditScenes[0] = GameObject.Find("Credit1");
        creditScenes[1] = GameObject.Find("Credit2");
        creditScenes[2] = GameObject.Find("Credit3");
        creditScenes[3] = GameObject.Find("Credit4");
        creditScenes[4] = GameObject.Find("Credit5");
        creditScenes[5] = GameObject.Find("Credit6");
        creditScenes[6] = GameObject.Find("Credit7");
        creditScenes[7] = GameObject.Find("Credit8");

        for (int i = 0; i < nScreens; i++)
        {
            creditScenes[i].SetActive(false);
        }
        creditScenes[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            int currentScene = swapCount % nScreens;
            creditScenes[currentScene].SetActive(false);
            swapCount++;
            currentScene = swapCount % nScreens;
            creditScenes[currentScene].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Title");
        }
    }
}
