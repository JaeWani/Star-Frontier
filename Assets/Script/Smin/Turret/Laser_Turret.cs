using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Turret : Turret_Base
{
    private void Update()
    {
        if (cur_delay >= fire_delay)
        {
            Fire();
        }
        else if(!GameTurnManager.instance.isBreakTime) cur_delay += Time.deltaTime;
    }

    private void Fire()
    {
        cur_delay = 0;
        int ranRot = Random.Range(0, 4);
        int rot = 0;

        switch(ranRot){
            case 0 : rot = 0; break;
            case 1 : rot = 45; break;
            case 2 : rot = 90; break;
            case 3 : rot = 135; break;
        }
        var temp = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, rot)).GetComponent<Bullet_Base>();
        var temp2 = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, rot + 180)).GetComponent<Bullet_Base>();
    }
}
