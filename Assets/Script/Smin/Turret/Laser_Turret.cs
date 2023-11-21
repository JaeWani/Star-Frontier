using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Laser_Turret : Turret_Base
{

    private void Update()
    {
        if (cur_delay >= fire_delay)
        {
            Fire();
        }
        else if (!GameTurnManager.instance.isBreakTime) cur_delay += Time.deltaTime;

        if(GameTurnManager.instance.isBreakTime) cur_delay = 0;
    }

    private void Fire()
    {
        cur_delay = 0;
        int ranRot = Random.Range(0, 4);
        int rot = 0;

        switch (ranRot)
        {
            case 0: rot = 0; break;
            case 1: rot = 45; break;
            case 2: rot = 90; break;
            case 3: rot = 135; break;
        }
        var parent = new GameObject("parent");
        parent.transform.position = transform.position;
        var temp = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, rot)).GetComponent<Laser_Charge>();
        var temp2 = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, rot + 180)).GetComponent<Laser_Charge>();
        temp.transform.SetParent(parent.transform);
        temp2.transform.SetParent(parent.transform);
        if(isUpgrade) StartCoroutine(Rotate(0,parent.transform));
    }
    public IEnumerator  Rotate(float z, Transform t)
    {
        yield return new WaitForSeconds(2);
        t.DOLocalRotate(new Vector3(0, 0,z + 360), 1, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.Linear);
        Destroy(t.gameObject,1.1f);
    }
}
