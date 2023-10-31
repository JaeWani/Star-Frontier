using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] int hp;
    [SerializeField] Image damage_ui;

    public void Damage(){
        hp--;
        CameraShake.ShakeCamera(0.1f,0.1f);
        if(hp <= 0){
            GameManager.instance.moneyUi.SetActive(false);
            GameManager.instance.timeUi.SetActive(false);
            GameManager.instance.skipBtn.SetActive(false);

            GameManager.instance.ReStartbtn.SetActive(true);
            GameManager.instance.MainMenuBtn.SetActive(true);

            GameManager.instance.End(true);
        }
    }
   
}
