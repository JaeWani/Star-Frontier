using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance{get; private set;}

    [Tooltip("플레이어 돈(Int)")]
    public int playerMoney = 0;

    void Awake()
    {
        instance = this;
    }


}
