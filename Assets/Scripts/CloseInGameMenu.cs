using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseInGameMenu : MonoBehaviour
{
    public string inputButtonName = "Cancel";
    public GameObject targetObj;

    void Update()
    {
        if (Input.GetButtonDown(inputButtonName))
            targetObj.SetActive(!targetObj.activeSelf);
    }
}