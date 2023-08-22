using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Player : MonoBehaviour
{
    public static Player Instance;
    private Rigidbody _rigidbody;
    private Animator _animator;
    private AudioSource _audioSource;
    private CapsuleCollider _capsuleCollider;
    private void Awake()
    {
        Instance = this;
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Collectable coinScript = other.GetComponent<Collectable>();
            EventManager.StartCoinPickupEvent(coinScript.value);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Hole"))
        {

            Debug.Log(Instance.name + " fell in hole.");
            other.GetComponentInParent<MeshCollider>().enabled = true;

            SoundController.Instance.PlaySFX("Fall");
            _capsuleCollider.isTrigger = false;
            _rigidbody.useGravity = true;
            _audioSource.enabled = false;
            _animator.enabled = false;

            LevelGenerator.IsAlive = false;
        }
        else if (other.CompareTag("Obstacle"))
        {
            Debug.Log(Instance.name + " hit an obstacle.");

            SoundController.Instance.PlaySFX("WallHit");

            this.transform.SetParent(other.transform.parent, true);
            _audioSource.enabled = false;
            _animator.enabled = false;

            LevelGenerator.IsAlive = false;
        }
    }
}
