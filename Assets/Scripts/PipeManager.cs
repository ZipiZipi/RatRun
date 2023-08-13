using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeManager : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    private float _moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _moveSpeed = LevelGenerator.gameSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - _moveSpeed * Time.deltaTime);
        transform.Rotate(0, _joystick.Horizontal * (_moveSpeed/2), 0);
    }
}
