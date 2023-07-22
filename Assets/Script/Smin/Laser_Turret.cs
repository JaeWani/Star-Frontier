using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Turret : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private int level;
    [SerializeField] private float damage;
    [SerializeField] private float radius;
    [SerializeField] private float fire_delay;
    private float cur_delay;


    public void Init(float _damage, float _fire_delay)
    {
        damage = _damage;
        fire_delay = _fire_delay;
    }

    private void Update()
    {
        if (cur_delay >= fire_delay)
        {
            Fire();
        }
        else cur_delay += Time.deltaTime;
    }

    private void Fire()
    {
        cur_delay = 0;
        int ranRot = Random.Range(90, 271);
        Vector3 pos = transform.position + new Vector3(Mathf.Cos(ranRot * Mathf.Deg2Rad) * radius,
                        Mathf.Sign(ranRot * Mathf.Rad2Deg) * radius);
        var temp = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, ranRot + 180)).GetComponent<Bullet_Base>();
    }
}
