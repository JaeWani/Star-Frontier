using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    // 적의 공통점 : 체력, 움직임속도, 공격력, 공격딜레이, 공격타겟
    [Header("# Enemy Info")]
    [SerializeField] protected GameObject attTarget;
    [SerializeField] protected int hp;
    [SerializeField] protected int moveSpeed;
    [SerializeField] protected int att;
    [SerializeField] protected float enemyAttDelay;
    [SerializeField] protected int enemyGold;

}
