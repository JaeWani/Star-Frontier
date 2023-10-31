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
    private Animator anim;

    [HideInInspector] public Rigidbody2D rigid;
    public bool isNotActive;
    public GameObject eIndicator;

    private void Awake() {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        _instance = this;
    }

    void Update()
    {
        if(isNotActive) {
            anim.SetBool("isWalk", false);
            return;
        }

        PlayerMove();
        ItemCheck();
    }

    void PlayerMove()
    {
        float _inputX = Input.GetAxisRaw("Horizontal");
        float _inputY = Input.GetAxisRaw("Vertical");


        if(_inputX != 0 || _inputY != 0) anim.SetBool("isWalk", true);
        else anim.SetBool("isWalk", false);

        if(_inputX < 0) GetComponent<SpriteRenderer>().flipX = true;
        else if(_inputX > 0) GetComponent<SpriteRenderer>().flipX = false;
        
        anim.SetFloat("X", _inputX);
        anim.SetFloat("Y", _inputY);

        Vector2 _Vec = new Vector2(_inputX, _inputY).normalized;
        Vector3 localPosition = new Vector3(Mathf.Clamp(transform.position.x, -18.5f, 18.5f),
            Mathf.Clamp(transform.position.y, -10.18f, 8.69f), 0f);
        transform.localPosition = localPosition;
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
                eIndicator.SetActive(true);
                eIndicator.transform.position = transform.position + Vector3.up * (Mathf.Sin(Time.time * 2) * 0.05f + 0.5f);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    GameTurnManager.instance.isPause = true;
                    use.Use();
                    isNotActive = true;
                }
            } else
            eIndicator.SetActive(false);
        }
    }
}

