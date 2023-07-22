using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject window;

    public void SpeedUp()
    {
        player.playerSpeed += 0.5f;
    }

    public void GoldUp()
    {
        player.goldMultiple += 0.2f;
    }

    public void CheckRadius()
    {
        player.coinMagent.GetComponent<CircleCollider2D>().radius += 0.2f;
    }

    public void Exit()
    {
        window.SetActive(false);
        if(GameTurnManager.instance.isBreakTime) player.isNotActive = false;
    }
}
