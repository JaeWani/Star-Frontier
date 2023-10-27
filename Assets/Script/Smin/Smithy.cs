using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Smithy : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] GameObject window;
    [SerializeField] Installation_Turret turret;

    [Header ("Panel Rect")] 
    [SerializeField] private RectTransform SmithyPanelRect;
    [SerializeField] private RectTransform UpgradePanelRect;

    [Header("Panel Button")]
    [SerializeField] private Button ExitButton;
    [SerializeField] private Button PanelChangeButton;


    [Header("Turret Buy Button")]
    [SerializeField] private Button BasicTurretBuy;
    [SerializeField] private Button ExplosionTurretBuy;
    [SerializeField] private Button LaserTurretBuy;

    [SerializeField] private List<TextMeshProUGUI> textList = new List<TextMeshProUGUI>();

    [Header("Turret Price")]
    [SerializeField] private int BasicTurretPrice;
    [SerializeField] private int ExplosionTurretPrice;
    [SerializeField] private int LaserTurretPrice;
    [SerializeField] private int PlacementSlot1Price = 300;
    [SerializeField] private int PlacementSlot2Price = 1000;

    [Header("Any")]
    [SerializeField] private Button Placement_Btn;
    [SerializeField] private GameObject Placement_UI;
    [SerializeField] private GameObject Placement_1;
    [SerializeField] private Turret_Pos Placement_1_Pos;

    [SerializeField] private Button Placement2_Btn;
    [SerializeField] private GameObject Placement2_UI;
    [SerializeField] private GameObject Placement_2;
    [SerializeField] private Turret_Pos Placement_2_Pos;
    [SerializeField] private Turret_Pos Placement_2_Pos2;

    private void Start()
    {
        BasicTurretBuy.onClick.AddListener(() => Turret());
        ExplosionTurretBuy.onClick.AddListener(() => Explosion_Turret());
        LaserTurretBuy.onClick.AddListener(() => Laser_Turret());
        Placement_Btn.onClick.AddListener(() => PlacementSlotUpgrade_1());
        Placement2_Btn.onClick.AddListener(() => PlacementSlotUpgrade_2());

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
    public void PlacementSlotUpgrade_1()
    {
        if (GameManager.instance.playerMoney - PlacementSlot1Price >= 0) GameManager.instance.playerMoney -= PlacementSlot1Price;
        else return;

        Placement_1.SetActive(true);
        Installation_Turret.instance.pos.Add(Placement_1_Pos);
        Exit();
        Destroy(Placement_UI.gameObject);
    }
    public void PlacementSlotUpgrade_2()
    {
        if(GameManager.instance.playerMoney - PlacementSlot2Price >= 0) GameManager.instance.playerMoney -= PlacementSlot2Price;
        else return;

        Placement_2.SetActive(true);
        Installation_Turret.instance.pos.Add(Placement_2_Pos);
        Installation_Turret.instance.pos.Add(Placement_2_Pos2);
        Exit();
        Destroy(Placement2_UI.gameObject);
    }
    public void Exit()
    {
        GameTurnManager.instance.isPause = false;
        window.SetActive(false);
        if (GameTurnManager.instance.isBreakTime) player.isNotActive = false;
    }
}
