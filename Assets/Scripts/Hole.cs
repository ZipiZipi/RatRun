using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private int _playerLayer;
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().useGravity = true;
    }
    private void Start()
    {
        _playerLayer = LayerMask.NameToLayer("Player");
    }
}
