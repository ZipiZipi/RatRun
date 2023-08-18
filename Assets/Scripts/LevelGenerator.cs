using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public static float gameSpeed;
    public static bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        gameSpeed = 5f;
        //int rand = Random.Range(0, pipes.Count);
        //Instantiate(pipes[rand], new Vector3(0, 0, 41), Quaternion.Euler(new Vector3(Random.Range(0f, 360f), 90, -90)));
        StartCoroutine(GameSpeedUpdate());
        //StartCoroutine(GeneratePipe());
    }

    IEnumerator GameSpeedUpdate()
    {
        while (!isDead)
        {
            yield return new WaitForSeconds(4);
            gameSpeed += 0.5f;
        }
        if (isDead)
        {
            gameSpeed = 0f;
        }
    }
    /*IEnumerator GeneratePipe()
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
        
    }*/
    private void OnTriggerEnter(Collider pipe)
    {
        if (pipe.CompareTag("Pipe")) // Adjust the tag based on your setup
        {
            Debug.Log("Pipe randomly rotated");
            pipe.transform.rotation = Quaternion.Euler(new Vector3(Random.Range(0f, 360f), 90, -90));
        }
    }
}
