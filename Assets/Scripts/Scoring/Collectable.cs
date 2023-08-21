using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collectable : MonoBehaviour
{
    public int value;

    private int _playerLayer;
    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.layer == _playerLayer)
        {
            EventManager.StartCoinPickupEvent(value);
            //CollectableManager.Instance.IncreaseCoins(value);
            this.gameObject.SetActive(false);
        }
    }
    private void Awake()
    {
        _playerLayer = LayerMask.NameToLayer("Player");
    }
}
