using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret_Bullet : Bullet_Base
{
    protected override void Update()
    {
        base.Update();
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
    }

    protected override void Hit_Event(){
        Destroy(gameObject);
    }
}
