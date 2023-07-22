using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{
    Rigidbody2D rigid;
    GameTurnManager turnMgr;

    protected override void Start()
    {
        base.Start();
        rigid = GetComponent<Rigidbody2D>();
        attTarget = GameObject.Find("Tower");

        turnMgr = GameTurnManager.instance;
    }

    void Update()
    {
        EnemyMove();
    }

    void EnemyMove()
    {
        Vector2 enemyDir = attTarget.transform.position - this.transform.position;
        rigid.velocity = enemyDir.normalized * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D collison)
    {
        if(collison.gameObject.CompareTag("Tower"))
        {
            //타워 체력 까기
            DieDestroy();
        }
    }

    protected override void DieDestroy()
    {
        Debug.Log("test");
        Destroy(gameObject);
    }
}
