using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;
    private float _moveSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        _moveSpeed = LevelGenerator.gameSpeed;
    }
    void Start()
    {
        StartCoroutine(UpdateSpeed());
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - _moveSpeed * Time.deltaTime);
        transform.Rotate(0, _joystick.Horizontal * (_moveSpeed/2), 0);
    }
    IEnumerator UpdateSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            _moveSpeed = LevelGenerator.gameSpeed;
        }
    }
}
