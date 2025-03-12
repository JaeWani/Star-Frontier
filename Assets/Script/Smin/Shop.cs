using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject window;

    public void SpeedUp()
    {
        if(GameManager.instance.playerMoney - 25 >= 0) GameManager.instance.playerMoney -= 25;
        player.playerSpeed += 0.5f;
        SoundManager.Instance.SoundInt(5, 0.5f, Random.Range(0.5f,1.5f));
    }

    public void GoldUp()
    {
        if(GameManager.instance.playerMoney - 25 >= 0) GameManager.instance.playerMoney -= 25;
        player.goldMultiple += 0.2f;
        SoundManager.Instance.SoundInt(5, 0.5f, Random.Range(0.5f, 1.5f));
    }

    public void CheckRadius()
    {
        if(GameManager.instance.playerMoney - 25 >= 0) GameManager.instance.playerMoney -= 25;
        player.coinMagent.GetComponent<CircleCollider2D>().radius += 0.2f;
        SoundManager.Instance.SoundInt(5, 0.5f, Random.Range(0.5f, 1.5f));
    }

    public void Exit()
    {
        GameTurnManager.instance.isPause = false;
        window.SetActive(false);
        if(GameTurnManager.instance.isBreakTime) player.isNotActive = false;
    }
}
