using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;
    public TMP_Text highscoreText;
    public TMP_Text lastRunText;
    public TMP_Text cashText;

    void Start()
    {
        _gameManager = GameManager.Instance;
        highscoreText.text = "Longest distance:\n" + _gameManager.Highscore.ToString("F0") + "cm";
        lastRunText.text = "Last run:\n" + _gameManager.LastRun.ToString("F0") + "cm";
        cashText.text = "Cash:\n" + "$" + _gameManager.Cash.ToString();
    }
}
