using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelGenerator : MonoBehaviour
{

    public GameObject DeathPanel;
    public TMP_Text Score;
    public TMP_Text Coins;

    public static LevelGenerator Instance;
    public static bool IsAlive;

    public GameObject[] pipes;
    public float[] spawnProbabilities;

    public GameObject[] collectables;
    public float[] spawnCollectablesProbabilities;

    public static float gameSpeed;

    private void Awake()
    {
        Instance = this;
        gameSpeed = 5f;
    }
    void Start()
    {
        IsAlive = true;
        EventManager.DeathEvent += PlayerDeath;
        StartCoroutine(GameSpeedUpdate());
    }
    IEnumerator GameSpeedUpdate()
    {
        while (IsAlive)
        {
            yield return new WaitForSeconds(4);
            gameSpeed += 0.25f;
        }
    }
    void GeneratePipe()
    {
        if (pipes.Length != spawnProbabilities.Length || spawnProbabilities.Length == 0)
        {
            Debug.LogError("Prefab array length doesn't match spawn probabilities array length, or probabilities array is empty.");
            return;
        }

        float randomValue = Random.value; // Generate a random value between 0 and 1
        float cumulativeProbability = 0f;

        for (int i = 0; i < pipes.Length; i++)
        {
            cumulativeProbability += spawnProbabilities[i];

            if (randomValue <= cumulativeProbability)
            {
                // Instantiate the selected pipe prefab
                GameObject pipe = Instantiate(pipes[i], new Vector3(0, 0, 36), Quaternion.Euler(new Vector3(0, 0, Random.Range(0f, 360f))));
                GenerateCollectibles(pipe);
                break;
            }
        }
    }
    void GenerateCollectibles(GameObject pipe)
    {
        Transform _transform = pipe.transform.Find("Point");
        if (collectables.Length != spawnCollectablesProbabilities.Length || spawnCollectablesProbabilities.Length == 0)
        {
            Debug.LogError("Prefab array length doesn't match spawn probabilities array length, or probabilities array is empty.");
            return;
        }

        float randomValue2 = Random.value; // Generate a random value between 0 and 1
        float cumulativeProbability2 = 0f;

        for (int i = 0; i < collectables.Length; i++)
        {
            cumulativeProbability2 += spawnCollectablesProbabilities[i];

            if (randomValue2 <= cumulativeProbability2)
            {
                // Instantiate the selected pipe prefab
                GameObject newCollectible = Instantiate(collectables[i], _transform.position, _transform.rotation);
                newCollectible.transform.parent = pipe.transform;
                break;
            }
        }
    }
    private void OnTriggerExit(Collider pipe)
    {
        if (pipe.CompareTag("Pipe")) // Adjust the tag based on your setup
        {
            GeneratePipe();
            pipe.gameObject.GetComponent<BoxCollider>().enabled = false;
            pipe.gameObject.GetComponent<MeshCollider>().enabled = false;
            
        }
    }
    private void OnDisable()
    {
        EventManager.DeathEvent -= PlayerDeath;
    }
    private void PlayerDeath()
    {
        IsAlive = false;
        DeathPanel.SetActive(true);
        Score.text = "Distance: " + ScoreManager.scoreCount.ToString("F0") + "cm";
        Coins.text = "Cash collected: " + CollectableManager.coinCount.ToString();
    }
}
