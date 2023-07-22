using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 1);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other);
        // if (other.TryGetComponent<Enemy_Base>(out var e_hit))
        //     {
        //         e_hit.Enemy_Damage(10);
        //     }
    }
}
