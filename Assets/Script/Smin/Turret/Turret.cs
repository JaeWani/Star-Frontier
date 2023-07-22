using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Turret_Base
{
    [Header("Turret")]
    [SerializeField] private float bulletSpeed;

    private void Update()
    {
        if (cur_delay >= fire_delay)
        {
            Fire();
        }else cur_delay += Time.deltaTime;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }

    private void Fire()
    {
        var hit = Physics2D.OverlapCircleAll(transform.position, checkRadius);

        float minDistance = float.MaxValue;
        Vector3 target = Vector3.zero;

        foreach (var n in hit)
        {
            if(n.CompareTag("Enemy")){
                float curDistance = Vector3.Distance(transform.position, n.transform.position);
                if (curDistance < minDistance)
                {
                    minDistance = curDistance;
                    target = n.transform.position;
                }
            }
        }

        cur_delay = 0;
        if(target == Vector3.zero) return;

        Vector3 direction = target - transform.position;
        float z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rot = Quaternion.Euler(0, 0, z - 90f);
        var temp = Instantiate(bullet, transform.position, rot).GetComponent<Bullet_Base>();
        temp.Init(3, bulletSpeed, damage);
    }
}
