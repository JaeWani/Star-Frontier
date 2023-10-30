using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrade : MonoBehaviour
{
    public static Upgrade instance;

    [SerializeField] private TextMeshProUGUI nameTxt;
    [SerializeField] private TextMeshProUGUI dmgTxt;
    [SerializeField] private TextMeshProUGUI spdTxt;

    private void Awake()
    {
        if (instance == null) instance = this;
        gameObject.SetActive(false);
    }
    void Start()
    {

    }

    void Update()
    {

    }
    public void Init(Turret_Base turret)
    {
        Debug.Log("1");
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
    }

    public void CallUpgradePanel(Turret_Base turret)
    {
        gameObject.SetActive(true);
        Init(turret);
    }
}
