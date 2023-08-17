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
            Debug.Log(player.name + " hit an obsticle!");
            player.transform.SetParent(this.transform.parent, true);
            InputManager.Instance.Joystick.enabled = false;
            LevelGenerator.isDead = true;
        }
    }
    private void Awake()
    {
        _playerLayer = LayerMask.NameToLayer("Player");
    }
}
