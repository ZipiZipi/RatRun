using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private bool IsAlive;
    public static float scoreCount;
    public TMP_Text scoreText;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        IsAlive = true;
        EventManager.DeathEvent += PlayerDeath;
        scoreCount = 0;
        scoreText.text = "Distance: " + scoreCount.ToString() + "cm";
        StartCoroutine(DistanceCounter());
    }

    // Update is called once per frame
    IEnumerator DistanceCounter()
    {
        while (IsAlive)
        {
            scoreCount += LevelGenerator.gameSpeed*0.05f;
            scoreText.text = "Distance: " + scoreCount.ToString("F0") + "cm";
            yield return new WaitForFixedUpdate();
        }
    }
    private void OnDisable()
    {
        EventManager.DeathEvent -= PlayerDeath;
    }
    private void PlayerDeath()
    {
        IsAlive = false;
    }
}
