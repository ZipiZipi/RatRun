using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float Highscore;
    public float LastRun;
    public int Cash;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        EventManager.DeathEvent += UpdateScore;
        Highscore = PlayerPrefs.GetFloat("Highscore", 0);
        LastRun = PlayerPrefs.GetFloat("LastRun", 0);
        Cash = PlayerPrefs.GetInt("Cash", 0);
    }
    public void UpdateScore()
    {
        float lastRun = ScoreManager.scoreCount;
        if(Highscore < lastRun)
        {
            Highscore = lastRun;
            LastRun = lastRun;
        }
        else
        {
            LastRun = lastRun;
        }
        Cash += CollectableManager.coinCount;
        SaveData();
    }
    public void SaveData()
    {
        PlayerPrefs.SetFloat("Highscore", Highscore);
        PlayerPrefs.SetFloat("LastRun", LastRun);
        PlayerPrefs.SetInt("Cash", Cash);
    }
    private void OnDisable()
    {
        EventManager.DeathEvent -= UpdateScore;
    }
}
