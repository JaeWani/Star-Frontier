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

    public Material outlineMaterial;
    public Material defaultMaterial;

    public void Init(int level)
    {
        curTurret.Init(2, 0.5f, 0.2f);
        level++;
    }
    private void OnMouseEnter()
    {
        if (turret != null)
        {
            SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

            if (srs != null)
            {
                foreach (SpriteRenderer sr in srs)
                {
                    sr.material = outlineMaterial;
                }
            }
        }
    }
    private void OnMouseExit()
    {
        if (turret != null)
        {
            SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

            if (srs != null)
            {
                foreach (SpriteRenderer sr in srs)
                {
                    sr.material = defaultMaterial;
                }
            }
        }
    }

    private void OnMouseDown()
    {
        Upgrade.instance.CallUpgradePanel(curTurret);
    }
}
