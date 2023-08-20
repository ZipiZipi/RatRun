using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    [SerializeField] private List<Pipe> pipes;
    private float _moveSpeed;
    private InputManager _InputManager;


    private Vector3 _positionStart;
    private Vector3 _position2;
    private Vector3 _position3;
    private Vector3 _position4;
    private Vector3[] targets;
    private void Awake()
    {

        _positionStart = new Vector3(0, 0, 42);
        _position2 = new Vector3(0, 0, -14);
        _position3 = new Vector3(0, -7, -14);
        _position4 = new Vector3(0, -7, 42);
    }
    void Start()
    {
        _InputManager = InputManager.Instance;
        targets = new Vector3[] { _positionStart, _position2};
        _moveSpeed = 5f;
        StartCoroutine(GameSpeedUpdate());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        foreach (var pipe in pipes)
        {
            if(pipe.target == 0)
            {
                pipe.GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                pipe.GetComponent<MeshRenderer>().enabled = true;
            }
            MovePipe(pipe);
            pipe.transform.Rotate(0, _InputManager.Joystick.Horizontal, 0);
        }
    }
    IEnumerator GameSpeedUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            _moveSpeed += 0.5f;
        }
    }
    void MovePipe(Pipe pipe)
    {
        var step = _moveSpeed * Time.deltaTime;
        float y = pipe.transform.position.y;
        float z = pipe.transform.position.z;

        Vector3 target = targets[pipe.target];
        pipe.transform.position = Vector3.MoveTowards(pipe.transform.position, target, step);
        if (Vector3.Distance(pipe.transform.position, target) < 0.01f)
        {
            if(pipe.target == 1)
            {
                pipe.target = 0;
            }
            else
            {
                pipe.target += 1;
            }

        }
    }
}
