using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private Transform _transform;

    public int Health;
    public TMP_Text healthText;

    private bool Protected;
    private void Awake()
    {
        Instance = this;
        Health = 2;
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
        _animator = GetComponent<Animator>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }
    private void Start()
    {
        healthText.text = "Health: " + Health.ToString();
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

            EventManager.StartSFXEvent("Fall");

            _capsuleCollider.isTrigger = false;
            _rigidbody.useGravity = true;
            _audioSource.enabled = false;
            _animator.enabled = false;
            EventManager.StartDeathEvent();
        }
        else if (other.CompareTag("Obstacle"))
        {
            Debug.Log(Instance.name + " hit an obstacle.");
            EventManager.StartSFXEvent("WallHit");
            if (Health > 1)
            {
                Health -= 1;
                healthText.text = "Health: " + Health.ToString();
            }
            else if(Health == 1)
            {
                Health = 0;
                healthText.text = "Health: " + Health.ToString();

                this.transform.SetParent(other.transform.parent, true);
                _audioSource.enabled = false;
                _animator.enabled = false;
                EventManager.StartDeathEvent();
            }
        }else if (other.CompareTag("Heart"))
        {
            if(Health == 3)
            {
                EventManager.StartCoinPickupEvent(20);
                other.gameObject.SetActive(false);
            }else if(Health <= 2)
            {
                EventManager.StartSFXEvent("Heart");
                Health += 1;
                healthText.text = "Health: " + Health.ToString();
                other.gameObject.SetActive(false);
            }
        }
        else if (other.CompareTag("Star"))
        {
            EventManager.StartSFXEvent("Heart");
            other.gameObject.SetActive(false);
            StartCoroutine(StarProtection());
        }
    }
    IEnumerator StarProtection()
    {
        _capsuleCollider.enabled = false;
        _transform.DOMove(new Vector3(-0.05f, -0.5f, -0.5f), 0.5f);
        yield return new WaitForSeconds(5f);
        _transform.DOMove(new Vector3(-0.05f, -1.7f, -2f), 0.5f);
        yield return new WaitForSeconds(1f);
        _capsuleCollider.enabled = true;
    }

}
