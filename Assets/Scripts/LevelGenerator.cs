using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator Instance;
    public List<GameObject> pipes = new List<GameObject>();

    public bool spawnPipe;
    public static float gameSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
        gameSpeed = 5f;
    }
    void Start()
    {
        spawnPipe = true;
        StartCoroutine(GeneratePipe());
        StartCoroutine(GameSpeedUpdate());
    }

    IEnumerator GameSpeedUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            gameSpeed += 0.5f;
        }
    }
    IEnumerator GeneratePipe()
    {
        while(true)
        {
            if (spawnPipe)
            {
                int rand = Random.Range(0, pipes.Count);
                Instantiate(pipes[rand], new Vector3(0, 0, 41), Quaternion.Euler(new Vector3(Random.Range(0f, 360f), 90, -90)));
                spawnPipe = false;
            }
            yield return null;
        }
        
    }
    private void OnTriggerExit(Collider pipe)
    {
        if (pipe.CompareTag("Pipe")) // Adjust the tag based on your setup
        {
            spawnPipe=true;
            pipe.gameObject.GetComponent<BoxCollider>().enabled = false;
            pipe.gameObject.GetComponent<MeshCollider>().enabled = false;
        }
    }
}
