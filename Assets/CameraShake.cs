using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    static float ShakeAmount;
    static float ShakeTime;
    Vector3 initPos;
    public static void ShakeCamera(float time, float shakeSize){
        ShakeTime = time;
        ShakeAmount = shakeSize;
    }
    private void _ShakeCamera(){
        if(ShakeTime > 0){
            transform.position = Random.insideUnitSphere * ShakeAmount + initPos;
            ShakeTime -= Time.deltaTime;
        }
        else{
            ShakeTime = 0f;
            transform.position = initPos;
        }
    }
    private void Start() {
        initPos = new Vector3(0,0,-10);
    }
    void Update()
    {
        _ShakeCamera();
    }
}