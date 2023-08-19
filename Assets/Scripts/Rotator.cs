using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Rotator Instance;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }
    void Update()
    {
        Instance.transform.Rotate((float)(-1.0 * LevelGenerator.gameSpeed * Time.deltaTime), 0, 0);
    }
}
