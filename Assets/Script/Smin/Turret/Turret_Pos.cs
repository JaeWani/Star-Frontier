using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Turret_Pos : MonoBehaviour
{
    public Turret_Base curTurret;
    public int level;

    public void Init(int level){
        curTurret.Init(2, 0.5f, 0.2f);
        level++;
    }
}
