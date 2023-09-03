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
        Highscore = PlayerPrefs.GetFloat("Highscore2", 0);
        LastRun = PlayerPrefs.GetFloat("LastRun2", 0);
        Cash = PlayerPrefs.GetInt("Cash2", 0);
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
        PlayerPrefs.SetFloat("Highscore2", Highscore);
        PlayerPrefs.SetFloat("LastRun2", LastRun);
        PlayerPrefs.SetInt("Cash2", Cash);
    }
    private void OnDisable()
    {
        EventManager.DeathEvent -= UpdateScore;
    }
}
