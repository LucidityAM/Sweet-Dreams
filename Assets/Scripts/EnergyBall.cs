using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{

    public GameObject mainPlayer;
    public GameObject energyBar;
    public GameObject energyBall;
    public int energyAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            IncreaseEnergy();
            UpdateEnergyBar();
            DestroyBall();
        }

    }

    private void IncreaseEnergy()
    {
        mainPlayer.GetComponent<PlayerStats>().gainEnergy(energyAmount);
    }

    private void UpdateEnergyBar()
    {
        float percent = (float)mainPlayer.GetComponent<PlayerStats>().energy /
            (float)mainPlayer.GetComponent<PlayerStats>().maxEnergy;
        energyBar.GetComponent<EnergyBar>().UpdateEnergyBar(percent);
    }

   private void DestroyBall()
    {
        Destroy(energyBall);
    }




}   
