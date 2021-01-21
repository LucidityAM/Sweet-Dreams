using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxEnergy;
    public int energy;
    public bool canShoot;

    public Transform firePoint;
    public GameObject bullePrefab;

    public GameObject mainPlayer;
    public GameObject energyBar;



    public void gainEnergy (int power)
    {
        energy += power;
        if(energy >= maxEnergy)
        {
            energy = maxEnergy;
        }
        print("Current energy =" + energy);

        
    }

    private void Update()
    {
        if (energy > 5)
        {
            canShoot = true;
        }
        else
        {
            canShoot = false;
        }

        if (canShoot == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                UpdateEnergyBar();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bullePrefab, firePoint.position, firePoint.rotation);
        energy -= 5;
        Invoke("SpeedUp", 7);
    }

    private void UpdateEnergyBar()
    {
        float percent = (float)mainPlayer.GetComponent<PlayerStats>().energy /
            (float)mainPlayer.GetComponent<PlayerStats>().maxEnergy;
        energyBar.GetComponent<EnergyBar>().UpdateEnergyBar(percent);
    }

    void SpeedUp()
    {
        AutoScrollCamera.step = .15f;
    }



}
