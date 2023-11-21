using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DifficultyManager : MonoBehaviour
{
    public enum Difficulty
    {
        easy, nomal, hard, fuck
    }
    public Difficulty curDifficulty;

    public int indexDifficulty = 0;

    public List<int> goldPerDifficulty = new List<int>();

    public static DifficultyManager instance = null;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    void Start()
    {
        curDifficulty = Difficulty.easy;
    }

    void Update()
    {
        checkDifficulty();
    }
    void checkDifficulty()
    {
        int d = GameManager.instance.waveNumber;
        if (d >= 0 && d <= 5)
            curDifficulty = Difficulty.easy;
        else if (d >= 6 && d <= 10)
            curDifficulty = Difficulty.nomal;
        else if (d >= 11 && d <= 15)
            curDifficulty = Difficulty.hard;
        else if (d >= 16 && d <= 20)
            curDifficulty = Difficulty.fuck;

        indexDifficulty = (int)curDifficulty;
    }
}
