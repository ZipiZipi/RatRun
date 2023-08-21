using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;
    [SerializeField]
    public AudioSource coinSource;


    private void Awake()
    {
        Instance = this;
    }
}
