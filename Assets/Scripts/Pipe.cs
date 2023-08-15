using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{

    private float _moveSpeed;
    private bool _isExsisting;
    // Start is called before the first frame update
    private void Awake()
    {
        _moveSpeed = LevelGenerator.gameSpeed;
    }
    void Start()
    {
        _isExsisting = true;
        StartCoroutine(UpdateSpeed());
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - _moveSpeed * Time.deltaTime);
        transform.Rotate(0, InputManager.Instance.Joystick.Horizontal * (_moveSpeed/10), 0);
        if(gameObject.transform.position.z < -14)
        {
            _isExsisting = false;
            Destroy(gameObject);
        }
    }
    IEnumerator UpdateSpeed()
    {
        while(_isExsisting)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            _moveSpeed = LevelGenerator.gameSpeed;
        }
    }
}
