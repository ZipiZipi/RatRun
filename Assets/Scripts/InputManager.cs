using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    [SerializeField]
    private Joystick _joystick;
    public Joystick Joystick { get { return _joystick; } set { _joystick = value; } }
    private void Awake()
    {
        Instance = this;
    }

}
