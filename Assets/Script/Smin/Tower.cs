using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [SerializeField] float hp;
    [SerializeField] Image damage_ui;
    [SerializeField] private Image healthBarImage;

    private float maxHp;

    private void Start()
    {
        maxHp = hp;
    }

    private void Update()
    {
        HPBarUpdate();
    }
    
    private void HPBarUpdate()
    {
        healthBarImage.fillAmount = Mathf.Lerp(healthBarImage.fillAmount, hp / maxHp, Time.deltaTime * 12f );
    }

    public void Damage(){
        hp--;
        CameraShake.ShakeCamera(0.1f,0.1f);
        if(hp <= 0){
            GameManager.instance.GameOver();
        }
    }
    
}
