using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private int _playerLayer;
    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.layer == _playerLayer)
        {
            Debug.Log("TRIGERRRRrr");
            player.transform.SetParent(transform, true);
            InputManager.Instance.Joystick.enabled = false;
        }
    }
    private void Awake()
    {
        _playerLayer = LayerMask.NameToLayer("Player");
    }
}
