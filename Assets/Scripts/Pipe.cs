using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private InputManager _InputManager;
    private float _moveSpeed;
    private bool _isExsisting;
    public LevelGenerator _LevelGenerator;
    // Start is called before the first frame update
    private void Awake()
    {
        _moveSpeed = LevelGenerator.gameSpeed;
    }
    void Start()
    {
        _isExsisting = true;
        _InputManager = InputManager.Instance;
        StartCoroutine(UpdateSpeed());
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (LevelGenerator.IsAlive)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - _moveSpeed * Time.deltaTime);
        }
        if(gameObject.transform.position.z < -14)
        {
            _isExsisting = false;
            Destroy(gameObject);
        }
    }
    void Update()
    {
        transform.Rotate(0, _InputManager.Joystick.Horizontal * (_moveSpeed / 5), 0);
    }
    IEnumerator UpdateSpeed()
    {
        while(_isExsisting)
        {
            yield return new WaitForEndOfFrame();
            _moveSpeed = LevelGenerator.gameSpeed;
        }
    }
}
