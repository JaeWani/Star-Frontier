using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Charge : MonoBehaviour
{
    public GameObject laser;

    public float sizeup;
    public float shot_delay;
    public float shot_time;
    

    private void Start() {
        StartCoroutine(Chage());
    }   

    IEnumerator Chage()
    {
        while(true){
            if(transform.lossyScale == new Vector3(2, 2))
                break;
            else
                transform.localScale = new Vector3(transform.localScale.x + sizeup, transform.localScale.y + sizeup, 0);
            
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(shot_delay);

        laser.SetActive(true);

        yield return new WaitForSeconds(shot_time);

        Destroy(gameObject);
    }
}
