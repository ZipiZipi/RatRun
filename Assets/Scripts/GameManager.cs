using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float Highscore2;
    public float LastRun2;
    public int Cash2;

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
        Highscore2 = PlayerPrefs.GetFloat("Highscore", 0);
        LastRun2 = PlayerPrefs.GetFloat("LastRun", 0);
        Cash2 = PlayerPrefs.GetInt("Cash", 0);
    }
    public void UpdateScore()
    {
        float lastRun = ScoreManager.scoreCount;
        if(Highscore2 < lastRun)
        {
            Highscore2 = lastRun;
            LastRun2 = lastRun;
        }
        else
        {
            LastRun2 = lastRun;
        }
        Cash2 += CollectableManager.coinCount;
        SaveData();
    }
    public void SaveData()
    {
        PlayerPrefs.SetFloat("Highscore", Highscore2);
        PlayerPrefs.SetFloat("LastRun", LastRun2);
        PlayerPrefs.SetInt("Cash", Cash2);
    }
    private void OnDisable()
    {
        EventManager.DeathEvent -= UpdateScore;
    }
}
