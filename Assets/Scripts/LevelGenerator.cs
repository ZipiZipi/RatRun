using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<GameObject> pipes;

    public bool spawnPipe;
    public static float gameSpeed;
    // Start is called before the first frame update
    void Start()
    {
        spawnPipe = true;
        gameSpeed = 5f;
        int rand = Random.Range(0, pipes.Count);
        Instantiate(pipes[rand], new Vector3(0, 0, 41), Quaternion.AngleAxis(-90, Vector3.right));
        StartCoroutine(GameSpeedUpdate());
        StartCoroutine(GeneratePipe());
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
        while(spawnPipe)
        {
            yield return new WaitForSeconds(1);
            int rand = Random.Range(0, pipes.Count);
            Instantiate(pipes[rand], new Vector3(0, 0, 41), Quaternion.AngleAxis(-90, Vector3.right));
            spawnPipe = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pipe")) // Adjust the tag based on your setup
        {
            spawnPipe=true;
        }
    }
}
