using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private InputManager _InputManager;
    private LevelGenerator _LevelGenerator;
    private float _moveSpeed;
    private float step;
    Vector3 endPoint = new(0, 0, -14);
    void Start()
    {
        _moveSpeed = LevelGenerator.gameSpeed;
        _InputManager = InputManager.Instance;
        _LevelGenerator = LevelGenerator.Instance;
    }

    void FixedUpdate()
    {

        if (LevelGenerator.IsAlive)
        {
            _moveSpeed = LevelGenerator.gameSpeed;
            transform.Rotate(0, _InputManager.Joystick.Horizontal * (_moveSpeed / 3), 0);
            step = Time.fixedDeltaTime * _moveSpeed;
            transform.position = Vector3.MoveTowards(transform.position, endPoint, step);
            //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - _moveSpeed * Time.deltaTime);
        }
        if (gameObject.transform.position.z <= -14)
        {
            Destroy(gameObject);
        }
    }
}
