using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private int _playerLayer;
    private void OnTriggerEnter(Collider player)
    {
        if(player.gameObject.layer == _playerLayer)
        {
            Debug.Log(player.name +  " fell in hole.");
            this.GetComponentInParent<MeshCollider>().enabled = true;
            player.GetComponent<Rigidbody>().useGravity = true;
            player.GetComponent<Animator>().enabled = false;
            LevelGenerator.IsAlive = false;
        }
    }
    private void Awake()
    {
        _playerLayer = LayerMask.NameToLayer("Player");
    }
}
