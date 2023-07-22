using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Turret : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private int level;
    [SerializeField] private float damage;
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
        }else cur_delay += Time.deltaTime;
    }

    private void Fire()
    {
        cur_delay = 0;
        int ranRot = Random.Range(0, 4);
        int rot = 0;
        //이따가 값 수정하셈
        switch(ranRot){
            case 0: rot = 0; break;
            case 1: rot = 45; break;
            case 2: rot = 90; break;
            case 3: rot = 135; break;
        }
        var temp = Instantiate(bullet, transform.position, Quaternion.Euler(0,0,rot)).GetComponent<Bullet_Base>();
    }
}
