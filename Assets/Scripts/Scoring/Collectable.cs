using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int value;
    private int _playerLayer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == _playerLayer)
        {
            //play sound
            CollectableManager.Instance.IncreaseCoins(value);
            this.gameObject.SetActive(false);
        }
    }
    private void Start()
    {
        _playerLayer = LayerMask.NameToLayer("Player");
    }
}
