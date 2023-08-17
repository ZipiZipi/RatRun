using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public float scoreCount;

    public TMP_Text scoreText;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Distance: " + scoreCount.ToString();
        StartCoroutine(DistanceCounter());
    }

    // Update is called once per frame
    IEnumerator DistanceCounter()
    {
        while (!LevelGenerator.isDead)
        {
            scoreCount += LevelGenerator.gameSpeed;
            scoreText.text = "Distance: " + scoreCount.ToString();
            yield return new WaitForSeconds(0.1f);
        }
    }
}
