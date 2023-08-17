using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{

    public float _moveSpeed;
    private bool _isExsisting;
    // Start is called before the first frame update
    private void Awake()
    {

        _isExsisting = true;
    }
    void Start()
    {
        _moveSpeed = LevelGenerator.gameSpeed;
        StartCoroutine(MovePipe());
        StartCoroutine(UpdateSpeed());
    }
    // Update is called once per frame
    void Update()
    {
            transform.Rotate(0, InputManager.Instance.Joystick.Horizontal * (_moveSpeed)*Time.deltaTime, 0);
    }
    IEnumerator MovePipe()
    {
        // z =(-14, 41)
        // y =(-5 , 0)
        
        while (!LevelGenerator.isDead)
        {

            float y = transform.position.y;
            float z = transform.position.z;
            //gore ide na levo
            if(z > -14 && y == 0)
            {
                GetComponent<MeshRenderer>().enabled = true;
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 0.5f);
            }//ide dole
            else if(z == -14 && y > -4)
            {
                GetComponent<MeshRenderer>().enabled = false;
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            }//dole ide na desno
            else if(z < 41 && y == -4)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f);
            }//ide gore
            else if(z == 41 && y < 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z);
            }
            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
    IEnumerator UpdateSpeed()
    {
        while(_isExsisting)
        {
            yield return new WaitForSeconds(3);
            _moveSpeed = LevelGenerator.gameSpeed;
        }
    }
}
