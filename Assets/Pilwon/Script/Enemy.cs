using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : EnemyBase
{

    Rigidbody2D rigid;
    GameTurnManager turnMgr;

    void Start()
    {
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
            GameTurnManager.instance.wave[turnMgr.curWave].enemyCount--;
            Destroy(gameObject);
        }
    }
}
