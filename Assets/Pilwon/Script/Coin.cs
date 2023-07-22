using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float flySpeed;
    private Vector2 playerDir;
    private bool isToPlayer; // 플레이어에게 닿으면 코인이 갈 지 판단해주는 변수

    Rigidbody2D rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Magnet();
    }

    void Magnet()
    {
        if (isToPlayer)
        {
            playerDir = -(transform.position - player.transform.position).normalized;
            rigid.velocity = new Vector2(playerDir.x, playerDir.y) * flySpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collison)
    {
        if(collison.gameObject.name.Equals("CoinMagnet"))
        {
            isToPlayer = true;
        }
    }
}
