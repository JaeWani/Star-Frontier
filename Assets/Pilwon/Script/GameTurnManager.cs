using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Wave
{
    [Header("# Wave Info")]
    [Tooltip("처치해야 하는 킬 수 -> 다음 스테이지")]
    public int enemyCount = 0;
    // 그 웨이브에 뜨는 몬스터
    public List<GameObject> enemy = new List<GameObject>();
}

public class GameTurnManager : MonoBehaviour
{
    public static GameTurnManager instance { get; private set; }

    public Wave[] wave;

    [Header("# TurnMgr Info")]  
    [Tooltip("현재웨이브")]
    public int curWave = 0;
    [Tooltip("게임최대웨이브")]
    public int maxWave;

    [Header("# TurnMgr Bool Info")]
    // 쉬는시간인지 판단해주는 값
    public bool isBreakTime = false;

    [Header("# TurnMgr UI Info")]
    [SerializeField] private Button waveStart_Btn;
    [SerializeField] private Text text;

    void Awake()
    {
        instance = this;

        // Button
        waveStart_Btn.onClick.AddListener(() => GameWaveStart());
    }

    void Update()
    {
        text.text = "게임턴 : " + (curWave + 1);
        GameWave();
    }

    void GameWave()
    {
        // 예외처리
        if (curWave >= wave.Length)
        {
            Debug.Log("웨이브 끝");
            return;
        }
        // 예외처리

        if (wave[curWave].enemyCount == 0)
        {
            var enemy = GameObject.FindWithTag("Enemy");
            Destroy(enemy);

            curWave++; // 다음 웨이브
            isBreakTime = true;
        }
    }

    void GameWaveStart()
    {
        isBreakTime = false;
    }
}
 