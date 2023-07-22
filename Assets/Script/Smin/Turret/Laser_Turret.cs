using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Turret : Turret_Base
{
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
        var temp = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, ranRot + 180)).GetComponent<Bullet_Base>();
    }
}
