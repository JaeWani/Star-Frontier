using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player _instance = null;
    public static Player Instance => _instance;

    [Header("# Player Info <<")]
    [Tooltip("움직임 속도(float)")]
    public float playerSpeed;
    public float goldMultiple = 1;
    public GameObject coinMagent;

    [SerializeField] private float radius;

    [HideInInspector] public Rigidbody2D rigid;
    public bool isNotActive;

    private void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        _instance = this;
    }

    void Update()
    {
        if(isNotActive) return;

        PlayerMove();
        if(Input.GetKeyDown(KeyCode.E)) ItemCheck();
    }

    void PlayerMove()
    {
        float _inputX = Input.GetAxisRaw("Horizontal");
        float _inputY = Input.GetAxisRaw("Vertical");

        Vector2 _Vec = new Vector2(_inputX, _inputY).normalized;
        rigid.velocity = _Vec * playerSpeed;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void ItemCheck()
    {
        var hits = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (var item in hits)
        {
            if(item.TryGetComponent<Item>(out var use)){
                use.Use();
                isNotActive = true;
            }
        }
    }
}

