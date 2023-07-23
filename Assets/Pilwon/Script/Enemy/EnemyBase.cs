using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    // 적의 공통점 : 체력, 움직임속도, 공격력, 공격딜레이, 공격타겟
    [Header("# Enemy Info")]
    [SerializeField] protected GameObject attTarget;
    [SerializeField] protected GameObject coin;
    [SerializeField] protected int hp;
    [SerializeField] protected float moveSpeed;
    public GameObject deathEffect;
    public Action dieAction;
    protected Animator anim;
    bool isDie;

    protected virtual void Start()
    {
        hp += GameTurnManager.instance.curWave * 2;
        moveSpeed += GameTurnManager.instance.curWave / 2;
        anim = GetComponent<Animator>();
        dieAction += DieDestroy;
    }

    public virtual void Damage(int damage)
    {
        hp -= damage;
        StartCoroutine(alpha(GetComponent<SpriteRenderer>(), 1));

        if (hp <= 0)
        {
            if(isDie) return;
            isDie = true;
            Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity), 2);
            dieAction?.Invoke();
        }
    }

    IEnumerator alpha(SpriteRenderer image, int sec)
    {
        float timer = 0.5f;
        while (timer <= sec)
        {
            image.color = new Color(1, 1, 1, timer / sec);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    protected abstract void DieDestroy();
}
