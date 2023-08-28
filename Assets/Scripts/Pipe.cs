using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    Transform _transform;
    private InputManager _InputManager;
    private bool IsAlive;
    private float _moveSpeed;
    private float step;

    Vector3 endPoint = new(0, 0, -14);
    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    void Start()
    {
        IsAlive = true;
        EventManager.DeathEvent += PlayerDeath;
        _moveSpeed = LevelGenerator.gameSpeed;
        _InputManager = InputManager.Instance;
    }

    void FixedUpdate()
    {

        if (IsAlive)
        {
            _moveSpeed = LevelGenerator.gameSpeed;
            _transform.Rotate(0, _InputManager.Joystick.Horizontal * (_moveSpeed*0.45f), 0);

            step = Time.fixedDeltaTime * _moveSpeed;
            _transform.position = Vector3.MoveTowards(_transform.position, endPoint, step);
        }
        if (_transform.position.z <= -14)
        {
            Destroy(gameObject);
        }
    }
    private void PlayerDeath()
    {
        IsAlive = false;
    }
    private void OnDisable()
    {
        EventManager.DeathEvent -= PlayerDeath;
    }
}
