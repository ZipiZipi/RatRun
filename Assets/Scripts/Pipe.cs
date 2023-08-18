using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    private MeshRenderer _MeshRenderer;
    private BoxCollider _BoxCollider;
    private InputManager _InputManager;
    public float _moveSpeed;
    private bool _isExsisting;
    // Start is called before the first frame update
    private void Awake()
    {
        _MeshRenderer = GetComponent<MeshRenderer>();
        _BoxCollider = GetComponent<BoxCollider>();
        _moveSpeed = LevelGenerator.gameSpeed;
        _isExsisting = true;
    }
    void Start()
    {
        _InputManager = InputManager.Instance;
        _moveSpeed = LevelGenerator.gameSpeed;
        StartCoroutine(MovePipe());
        StartCoroutine(UpdateSpeed());
    }
    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator MovePipe()
    {
        // z =(-14, 41)
        // y =(-5 , 0)

        while (!LevelGenerator.isDead)
        {
            yield return new WaitForEndOfFrame();
            float y = transform.position.y;
            float z = transform.position.z;
            //gore ide na levo
            if(z > -14 && y >= 0)
            {
                _BoxCollider.enabled = false;
                _MeshRenderer.enabled = true;
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1*_moveSpeed*Time.deltaTime);
            }//ide dole
            else if(z <= -14 && y >= -4)
            {
                _MeshRenderer.enabled = false;
                transform.position = new Vector3(transform.position.x, transform.position.y - 1 * _moveSpeed * Time.deltaTime, transform.position.z);
            }//dole ide na desno
            else if(z < 42 && y <= -4)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1 * _moveSpeed * Time.deltaTime);
            }//ide gore
            else if(z >= 42 && y <= 0)
            {
                _BoxCollider.enabled = true;
                transform.position = new Vector3(transform.position.x, transform.position.y + 1 * _moveSpeed * Time.deltaTime, transform.position.z);
            }
            transform.Rotate(0, _InputManager.Joystick.Horizontal, 0);
        }
    }
    IEnumerator UpdateSpeed()
    {
        while(_isExsisting)
        {
            yield return new WaitForSeconds(4);
            _moveSpeed = LevelGenerator.gameSpeed;
        }
    }
}
