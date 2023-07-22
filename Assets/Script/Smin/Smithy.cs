using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smithy : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject window;
    [SerializeField] Installation_Turret turret;

    public void Turret()
    {
        window.SetActive(false);
        turret.Init(0);
    }

    public void Explosion_Turret()
    {
        window.SetActive(false);
        turret.Init(1);
    }

    public void Laser_Turret()
    {
        window.SetActive(false);
        turret.Init(2);
    }

    public void Exit()
    {
        window.SetActive(false);
        if(GameTurnManager.instance.isBreakTime) player.isNotActive = false;
    }
}
