using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Smithy : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject window;
    [SerializeField] Installation_Turret turret;

    [SerializeField] List<Text> textList = new List<Text>();

    [SerializeField] int pay = 50;

    private void InitText(){
        pay = Mathf.RoundToInt(pay * 1.2f);
        textList[0].text = new string("Turret : " + pay + "Coin");
        textList[1].text = new string("Explosion : " + pay + "Coin");
        textList[2].text = new string("Laser : " + pay + "Coin");
    }

    public void Turret()
    {
        if(GameManager.instance.playerMoney - pay >= 0) GameManager.instance.playerMoney -= pay;
        else return;
        InitText();
        window.SetActive(false);
        turret.Init(0);
    }

    public void Explosion_Turret()
    {
        if(GameManager.instance.playerMoney - pay >= 0) GameManager.instance.playerMoney -= pay;
        else return;
        InitText();
        window.SetActive(false);
        turret.Init(1);
    }

    public void Laser_Turret()
    {
        if(GameManager.instance.playerMoney - pay >= 0) GameManager.instance.playerMoney -= pay;
        else return;
        InitText();
        window.SetActive(false);
        turret.Init(2);
    }

    public void Exit()
    {
        GameTurnManager.instance.isPause = false;
        window.SetActive(false);
        if(GameTurnManager.instance.isBreakTime) player.isNotActive = false;
    }
}
