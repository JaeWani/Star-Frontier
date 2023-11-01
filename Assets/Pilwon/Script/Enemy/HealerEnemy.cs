using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealerEnemy : EnemyBase
{
    public enum EnemySize
    {
        Small = 1,
        Middle,
        Big
    }
    [SerializeField] private EnemySize curSize;
    [SerializeField] private float healRange;
    [SerializeField] private LayerMask whatIsEnemy;
    Rigidbody2D rigid;
    GameTurnManager turnMgr;

    protected override void Start()
    {
        base.Start();
        rigid = GetComponent<Rigidbody2D>();
        attTarget = GameObject.Find("Tower");

        turnMgr = GameTurnManager.instance;
        
        InvokeRepeating(nameof(HealSkill), 2, 3);
    }

    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        Vector2 enemyDir = attTarget.transform.position - this.transform.position;
        rigid.velocity = enemyDir.normalized * moveSpeed;
        if (rigid.velocity.x > 0) GetComponent<SpriteRenderer>().flipX = false;
        else if (rigid.velocity.x < 0) GetComponent<SpriteRenderer>().flipX = true;
    }
    
    private void HealSkill()
    {
        Debug.Log("힐스킬 발동");
        
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, healRange, whatIsEnemy);

        if (targets != null)
        {
            foreach (var target in targets)
            {
                // 적의 체력을 20% 회복시킨다.
                target.GetComponent<EnemyBase>().HealEnemy(0.2f);
            }
        }
    }

    protected override void DieDestroy()
    {
        SoundManager.Instance.Sound(SoundManager.Instance.soundList[4], false, 1);
        var item = Instantiate(coin, transform.position, Quaternion.identity).GetComponent<Coin>();
        item.gold = DifficultyManager.instance.goldPerDifficulty[DifficultyManager.instance.indexDifficulty] * (int)curSize;
        GameManager.instance.monsterKill++;
        ObjectPoolManager.ReturnToPool(poolKey,gameObject);
        StopAllCoroutines();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireSphere(transform.position, healRange);
    }
}