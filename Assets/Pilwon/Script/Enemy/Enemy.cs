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
        if(rigid.velocity.x > 0) GetComponent<SpriteRenderer>().flipX = true;
        else if(rigid.velocity.x < 0) GetComponent<SpriteRenderer>().flipX = false;
    }

    void OnCollisionEnter2D(Collision2D collison)
    {
        if(collison.gameObject.CompareTag("Tower"))
        {
            collison.collider.GetComponent<Tower>().Damage();
            DieDestroy();
        }
    }

    protected override void DieDestroy()
    {
        SoundManager.Instance.Sound(SoundManager.Instance.soundList[4], false, 1);
        Instantiate(coin, transform.position, Quaternion.identity);
        GameManager.instance.monsterKill++;
        Destroy(gameObject);
    }
}
