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
    [SerializeField] protected float hp;
    [SerializeField] protected float maxHP;
    [SerializeField] protected float moveSpeed;
    [SerializeField] public string poolKey;
    public GameObject deathEffect;
    public GameObject FloatingText;
    public Action dieAction;
    protected Animator anim;
    bool isDie;
    SpriteRenderer spr;

    private float baseMoveSpeed;
    
    private Material _material;

    private void Awake()
    {
        baseMoveSpeed = moveSpeed;
        dieAction += DieDestroy;
    }

    private void OnEnable()
    {
        isDie = false;
        spr = GetComponent<SpriteRenderer>();
        maxHP = maxHP * GameTurnManager.instance.enemyHealthMultiply;
        
        hp = maxHP;

        spr.color = new Color(1, 1, 1, 1);
        StopAllCoroutines();

        _material = spr.material;

        StartCoroutine(DissolveShow());
    }
    protected virtual void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    public virtual void Damage(float damage)
    {
        hp -= damage;
        //var obj = ObjectPoolManager.SpawnFromPool("FloatingText",new Vector3(0,0,1) + transform.position).GetComponent<FloatingText>().str = damage.ToString("0.0");
        if (hp <= 0)
        {
            if (isDie) return;
            isDie = true;
           ObjectPoolManager.ReturnToPool("DeathEffect",ObjectPoolManager.SpawnFromPool("DeathEffect",transform.position), 2);
            dieAction?.Invoke();
            return;
        }
        
        StartCoroutine(alpha(spr, 1));
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Speed UP Col"))
        {
            // Speed Up Col 에 닿으면 스피드 40% 증가
            moveSpeed += baseMoveSpeed * 0.4f;
        }
        
        if (other.gameObject.CompareTag("Tower"))
        {
            other.GetComponent<Tower>().Damage();
            DieDestroy();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Speed UP Col"))
        {
            // Speed Up Col 에서 나가면 원래 스피드로 바뀜
            moveSpeed -= baseMoveSpeed * 0.4f;
        }
    }
    
    private IEnumerator DissolveShow()
    {
        float count = 1;

        while (count > 0)
        {
            _material.SetFloat("_DissolveAmount", count);
            count -= Time.deltaTime;
            yield return null;
        }
    }

    public void HealEnemy(float healRate)
    {
        float healHP = maxHP * healRate;

        hp = Mathf.Min(hp + healHP, maxHP);
    }

    protected abstract void DieDestroy();
}
