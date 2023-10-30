using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Turret_Pos : MonoBehaviour
{

    public Turret_Base curTurret;

    public GameObject turret;
    public GameObject turretProp;
    public int curTurretIndex;
    public int level;

    public void Init(int level)
    {
        curTurret.Init(2, 0.5f, 0.2f);
        level++;
    }
    private void OnMouseEnter()
    {
        //여기에 자식 오브젝트들 outline 쉐이더 활성화 하는 코드 넣기
        Debug.Log("Mouse Enter");
    }
    private void OnMouseExit()
    {
        // 여기에 자식 오브젝트들 outline 쉐이더 비활성화 하는 코드 넣김
        Debug.Log("Mouse Exit");
    }

    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        Upgrade.instance.CallUpgradePanel(curTurret);
    }
}
