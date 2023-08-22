using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject DeathPanel;
    public TMP_Text Score;
    public TMP_Text Coins;

    public static LevelGenerator Instance;
    public static bool IsAlive;

    public List<GameObject> pipes = new();

    public static float gameSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        IsAlive = true;
        gameSpeed = 4f;
    }
    void Start()
    {
        StartCoroutine(GameSpeedUpdate());
    }
    private void Update()
    {
        if(!IsAlive)
        {
            DeathPanel.SetActive(true);
            Score.text = "Distance: " + ScoreManager.scoreCount.ToString("F2");
            Coins.text = "Total coins: " + CollectableManager.coinCount.ToString();
        }
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
        int rand = Random.Range(0, pipes.Count);
        Instantiate(pipes[rand], new Vector3(0, 0, 41), Quaternion.Euler(new Vector3(Random.Range(0f, 360f), 90, -90)));
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
}
