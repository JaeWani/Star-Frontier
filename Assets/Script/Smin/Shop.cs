using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject window;
    [SerializeField] List<Text> textList = new List<Text>();
    [SerializeField] int pay = 25;

    private void InitText()
    {
        pay = Mathf.RoundToInt(pay * 1.2f);
        textList[0].text = new string("Speed : " + pay + "Coins");
        textList[1].text = new string("Gold : " + pay + "Coins");
        textList[2].text = new string("Radius : " + pay + "Coins");
    }
    public void SpeedUp()
    {
        if (GameManager.instance.playerMoney - 25 >= 0) GameManager.instance.playerMoney -= 25;
        else return;
        InitText();
        player.playerSpeed += 0.5f;
        SoundManager.Instance.SoundInt(5, 0.5f, Random.Range(0.5f,1.5f));
    }

    public void GoldUp()
    {
        if(GameManager.instance.playerMoney - 25 >= 0) GameManager.instance.playerMoney -= 25;
        else return;
        InitText();
        player.goldMultiple += 0.2f;
        SoundManager.Instance.SoundInt(5, 0.5f, Random.Range(0.5f, 1.5f));
    }

    public void CheckRadius()
    {
        if(GameManager.instance.playerMoney - 25 >= 0) GameManager.instance.playerMoney -= 25;
        else return;
        InitText();
        player.coinMagent.GetComponent<CircleCollider2D>().radius += 0.2f;
        SoundManager.Instance.SoundInt(5, 0.5f, Random.Range(0.5f, 1.5f));
    }

    public void Exit()
    {
        window.SetActive(false);
        if(GameTurnManager.instance.isBreakTime) player.isNotActive = false;
    }
}
