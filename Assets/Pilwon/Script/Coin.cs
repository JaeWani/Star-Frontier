using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float flySpeed;
    private Vector2 playerDir;
    [SerializeField] private bool isToPlayer; // 플레이어에게 닿으면 코인이 갈 지 판단해주는 변수

    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Magnet();
    }

    void Magnet()
    {
        // if (isToPlayer)
        // {
        //     playerDir = -(transform.position - Player.Instance.transform.position).normalized;
        //     rigid.velocity = new Vector2(playerDir.x, playerDir.y) * flySpeed;
        // }
    }

    void OnTriggerEnter2D(Collider2D collison)
    {
        if (collison.gameObject.name.Equals("CoinMagnet"))
        {
            StartCoroutine(MoveTo(1));
        }
    }

    IEnumerator MoveTo(float sec)
    {
        float timer = 0f;
        Vector3 start = transform.position;

        while (timer <= sec)
        {
            transform.position = Vector3.LerpUnclamped(start, Player.Instance.transform.position, Easing.easeInOutBack(timer / sec));
            timer += Time.deltaTime;
            yield return null;
        }
        GameManager.instance.playerMoney += Mathf.RoundToInt(10 * Player.Instance.goldMultiple);
        Destroy(gameObject);
        yield break;
    }
}
