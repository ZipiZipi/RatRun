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
            SoundController.Instance.PlaySFX("WallHit");

            player.transform.SetParent(this.transform.parent, true);
            player.GetComponent<AudioSource>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
            LevelGenerator.IsAlive = false;
        }
    }
    private void Awake()
    {
        _playerLayer = LayerMask.NameToLayer("Player");
    }
}
