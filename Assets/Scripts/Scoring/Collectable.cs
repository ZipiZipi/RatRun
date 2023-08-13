using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int value;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //play sound
            CollectableManager.instance.IncreaseCoins(value);
            this.gameObject.SetActive(false);
        }


    }
}
