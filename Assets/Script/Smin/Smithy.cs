using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Smithy : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject window;
    [SerializeField] Installation_Turret turret;

    [Header("Panel Button")]
    [SerializeField] private Button ExitButton;

    [Header("Turret Buy Button")]
    [SerializeField] private Button BasicTurretBuy;
    [SerializeField] private Button ExplosionTurretBuy;
    [SerializeField] private Button LaserTurretBuy;

    [SerializeField] private List<TextMeshProUGUI> textList = new List<TextMeshProUGUI>();

    [Header("Turret Price")]
    [SerializeField] private int BasicTurretPrice;
    [SerializeField] private int ExplosionTurretPrice;
    [SerializeField] private int LaserTurretPrice;

    private void Start()
    {
        BasicTurretBuy.onClick.AddListener(() => Turret());
        ExplosionTurretBuy.onClick.AddListener(() => Explosion_Turret());
        LaserTurretBuy.onClick.AddListener(() => Laser_Turret());

        ExitButton.onClick.AddListener(() => Exit());

        InitText();
    }

    private void InitText()
    {
        textList[0].text = new string(BasicTurretPrice.ToString());
        textList[1].text = new string(ExplosionTurretPrice.ToString());
        textList[2].text = new string(LaserTurretPrice.ToString());
    }

    public void Turret()
    {
        if (GameManager.instance.playerMoney - BasicTurretPrice >= 0) GameManager.instance.playerMoney -= BasicTurretPrice;
        else return;
        InitText();
        window.SetActive(false);
        turret.Init(0);
    }

    public void Explosion_Turret()
    {
        if (GameManager.instance.playerMoney - ExplosionTurretPrice >= 0) GameManager.instance.playerMoney -= ExplosionTurretPrice;
        else return;
        InitText();
        window.SetActive(false);
        turret.Init(1);
    }

    public void Laser_Turret()
    {
        if (GameManager.instance.playerMoney - LaserTurretPrice >= 0) GameManager.instance.playerMoney -= LaserTurretPrice;
        else return;
        InitText();
        window.SetActive(false);
        turret.Init(2);
    }

    public void Exit()
    {
        GameTurnManager.instance.isPause = false;
        window.SetActive(false);
        if (GameTurnManager.instance.isBreakTime) player.isNotActive = false;
    }
}
