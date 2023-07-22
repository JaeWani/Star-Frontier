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
        if(GameManager.instance.playerMoney - 50 >= 0) GameManager.instance.playerMoney -= 50;
        window.SetActive(false);
        turret.Init(0);
    }

    public void Explosion_Turret()
    {
        if(GameManager.instance.playerMoney - 50 >= 0) GameManager.instance.playerMoney -= 50;
        window.SetActive(false);
        turret.Init(1);
    }

    public void Laser_Turret()
    {
        if(GameManager.instance.playerMoney - 50 >= 0) GameManager.instance.playerMoney -= 50;
        window.SetActive(false);
        turret.Init(2);
    }

    public void Exit()
    {
        window.SetActive(false);
        if(GameTurnManager.instance.isBreakTime) player.isNotActive = false;
    }
}
