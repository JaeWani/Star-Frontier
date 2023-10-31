using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrade : MonoBehaviour
{
    public static Upgrade instance;

    public bool isUpgrade;

    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI dmgTxt;
    [SerializeField] private TextMeshProUGUI spdTxt;
    [SerializeField] private TextMeshProUGUI upgTxt;

    [SerializeField] private TextMeshProUGUI upgPriceTxt;

    [SerializeField] private Button dmgBtn;
    [SerializeField] private Button spdBtn;
    [SerializeField] private Button upgBtn;

    [SerializeField] private Button exitBtn;

    private void Awake()
    {
        if (instance == null) instance = this;
        gameObject.SetActive(false);
    }
    private void Start()
    {
        exitBtn.onClick.AddListener(() =>
        {
            GameTurnManager.instance.isPause = false;
            isUpgrade = false;
            gameObject.SetActive(false);
        });
    }

    public void Init(Turret_Base turret)
    {

        Turret_Kind turret_Kind = turret.turret_Kind;
        string name = "";
        switch (turret_Kind)
        {
            case Turret_Kind.Basic: name = "기본 포탑"; break;
            case Turret_Kind.Boom: name = "폭탄 포탑"; break;
            case Turret_Kind.Lazer: name = "레이저 포탑"; break;
            default: break;
        }
        nameTxt.text = name;
        dmgTxt.text = turret.damage.ToString();
        spdTxt.text = turret.fire_delay.ToString();
        upgPriceTxt.text = turret.upgradePrice.ToString();


        if (turret.speedLv >= 5)
        {
            spdBtn.gameObject.SetActive(false);
            spdTxt.text = "최대";
        }
        else
        {
            spdBtn.gameObject.SetActive(true);
        }

        if (turret.isUpgrade) upgTxt.text = "활성화";
        else upgTxt.text = "비활성화";

        var gameManager = GameManager.instance;

        dmgBtn.onClick.AddListener(() =>
        {
            if (gameManager.playerMoney >= 100)
            {
                Debug.Log("공업글");
                gameManager.playerMoney -= 100;
                turret.damage += 1;
                turret.damageLv += 1;
                dmgTxt.text = turret.damage.ToString();
            }
        });

        spdBtn.onClick.AddListener(() =>
        {
            if (gameManager.playerMoney >= 200)
            {
                Debug.Log("스피드 업글");
                gameManager.playerMoney -= 200;
                turret.fire_delay -= turret.increase;
                spdTxt.text = turret.fire_delay.ToString("0.00");
                turret.speedLv++;
                if (turret.speedLv >= 5)
                {
                    spdBtn.gameObject.SetActive(false);
                    spdTxt.text = "최대";
                }
            }
        });

        upgBtn.onClick.AddListener(() =>
        {
            if (gameManager.playerMoney >= turret.upgradePrice)
            {
                Debug.Log("업그레이드");
                gameManager.playerMoney -= turret.upgradePrice;
                turret.isUpgrade = true;
                upgBtn.gameObject.SetActive(false);
                upgTxt.text = "활성화";
            }
        });

        if (turret.isUpgrade) upgBtn.gameObject.SetActive(false);
        else upgBtn.gameObject.SetActive(true);
    }

    public void CallUpgradePanel(Turret_Base turret)
    {
        if (!isUpgrade)
        {
            isUpgrade = true;
            GameTurnManager.instance.isPause = true;
            dmgBtn.onClick.RemoveAllListeners();
            spdBtn.onClick.RemoveAllListeners();
            upgBtn.onClick.RemoveAllListeners();
            gameObject.SetActive(true);
            Init(turret);
        }
    }
}
