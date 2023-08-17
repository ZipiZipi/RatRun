using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private int _playerLayer;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == _playerLayer)
        {
            Debug.Log(other.name +  " fell in hole.");
            this.GetComponentInParent<MeshCollider>().enabled = true;
            other.GetComponent<Rigidbody>().useGravity = true;
            LevelGenerator.isDead = true;
        }
    }
    private void Awake()
    {
        _playerLayer = LayerMask.NameToLayer("Player");
    }
}
