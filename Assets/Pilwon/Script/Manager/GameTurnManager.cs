using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Wave
{
    [Header("# Wave Info")]
    public List<GameObject> enemy = new List<GameObject>();
    public float maxSpawnTime;
}

public class GameTurnManager : MonoBehaviour
{
    public static GameTurnManager instance { get; private set; }

    public Wave[] wave;

    [Header("# TurnMgr Info")]  
    public int curWave = 0;
    public bool isBreakTime;

    [Header("# TurnMgr UI Info")]
    [SerializeField] private Camera mainCam;
    [SerializeField] private Button waveStart_Btn;
    [SerializeField] private Text text;
    private float curTime;

    [Header("breakTime")]
    [SerializeField] private Player player;
    [SerializeField] private GameObject breakTimeObj;
    [SerializeField] private float waitTime;

    void Awake()
    {
        instance = this;

        //waveStart_Btn.onClick.AddListener(() => GameWaveStart());
        breakTime();
    }

    void Update()
    {
        GameWave();
    }

    void GameWave()
    {
        if (curWave >= wave.Length)
        {
            Debug.Log("웨이브 끝");
            return;
        }

        if (curTime >= wave[curWave].maxSpawnTime && !isBreakTime)
        {
            var enemy = GameObject.FindWithTag("Enemy");
            Destroy(enemy);

            curTime = 0;
            curWave++; // 다음 웨이브
            breakTime();
        }

        if(curTime > waitTime && isBreakTime) GameWaveStart();
        curTime += Time.deltaTime;
    }

    void breakTime(){
        player.transform.position = new Vector3(0,-4);
        player.isNotActive = false;
        isBreakTime = true;
        breakTimeObj.SetActive(true);
        mainCam.orthographicSize = 5;
    }

    void GameWaveStart()
    {
        player.transform.position = new Vector3(0,0);
        player.rigid.velocity = new Vector2(0,0);
        player.isNotActive = true;
        curTime = 0;
        isBreakTime = false;
        breakTimeObj.SetActive(false);
        mainCam.orthographicSize = 11;
    }
}
 