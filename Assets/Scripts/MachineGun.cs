using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : GUN
{
    private bool shooting;
    private int shootTimer;
    public void HeldUpdate()
    {
        if (!shooting)
        {
            Shoot();
        }
    }

    public void OnMagEnter(Magazine mag)
    {
        SetMagazine(mag);
    }
}
