using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Wave
{
    [Header("# Wave Info")]
    public List<GameObject> enemy = new List<GameObject>();
    public float maxSpawnDelay;
    public float maxSpawnTime;
}

public class GameTurnManager : MonoBehaviour
{
    public static GameTurnManager instance { get; private set; }

    public Wave[] wave;

    [Header("# TurnMgr Info")] 
    public float enemyHealthMultiply = 1;
    public int curWave = 0;
    public bool isBreakTime;
    public bool coinMagnet;
    public bool isEnd;
    public bool isPause = false;

    public float totalGameTime = 0;
   

    [Header("# TurnMgr UI Info")]
    [SerializeField] private Camera mainCam;
    [SerializeField] private Text timer;
    [SerializeField] private Button waveStart_Btn;
    [SerializeField] private E_SpawnManager spawn;
    private float curTime;

    [Header("breakTime")]
    [SerializeField] private Player player;
    [SerializeField] private GameObject breakTimeObj;
    [SerializeField] private float waitTime;

    void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        //waveStart_Btn.onClick.AddListener(() => GameWaveStart());
        breakTime();
    }

    void Update()
    {
        GameWave();
        mainCam.orthographicSize = Mathf.Lerp(mainCam.orthographicSize, isBreakTime ? 5 : 11, Time.deltaTime * 15);
    }

    void GameWave()
    {
        if (isEnd) return;

        if(isBreakTime) timer.text = new string((int)curTime + " : " + waitTime);
        else timer.text = new string((int)curTime + " : " + wave[curWave].maxSpawnTime);

        if (!isBreakTime)
        {
            if (wave[curWave].maxSpawnTime - curTime < 0.5f)
            {
                coinMagnet = true;
            }
            else
            {
                coinMagnet = false;
            }
        }

        if (curTime >= wave[curWave].maxSpawnTime && !isBreakTime)
        {
            curTime = 0;
            curWave = Random.Range(1, wave.Length);
            enemyHealthMultiply += 0.5f;
            GameManager.instance.waveNumber++;
            breakTime();
        }

        if (curTime > waitTime && isBreakTime) GameWaveStart();
        if (isPause == false)
        {
            curTime += Time.deltaTime;
            totalGameTime += Time.deltaTime;
        }
    }

    void breakTime()
    {
        player.transform.position = new Vector3(0, -4);
        player.isNotActive = false;
        isBreakTime = true;
        breakTimeObj.SetActive(true);
    }

    public void GameWaveStart()
    {
        player.transform.position = new Vector3(0, 0);
        player.rigid.velocity = new Vector2(0, 0);
        player.isNotActive = true;
        spawn.maxSpawnTime = wave[curWave].maxSpawnDelay;
        curTime = 0;
        isBreakTime = false;
        breakTimeObj.SetActive(false);
    }
}
