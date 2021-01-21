using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBar : MonoBehaviour
{
    private SpriteMask smask;
    private float smaskWidth;

    void Start()
    {
    
        smask = GetComponent<SpriteMask>();
        smaskWidth = smask.transform.localScale.x;

    }

    public void UpdateEnergyBar(float percent)
    {
        float newWidth = percent * smaskWidth;
        smask.transform.localScale =
            new Vector3(newWidth, transform.localScale.y, transform.localScale.z);
    }


}