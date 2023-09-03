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
    public void WalkSfx()
    {
        _audioSource.enabled = !_audioSource.enabled;
    }
    private void Awake()
    {
        Instance = this;
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _capsuleCollider = GetComponent<CapsuleCollider>();
        _audioSource = GetComponent<AudioSource>();
    }
    private void Start()
    {
        Time.timeScale = 1f;
        _audioSource.enabled = true;
        Health = 2;
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
            EventManager.StartCameraShakeEvent();
            if (Health > 1)
            {
                Health -= 1;
                healthText.text = "Health: " + Health.ToString();
            }
            else if(Health == 1)
            {
                Health -= 1;
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
            }
            else if(Health <= 2)
            {
                EventManager.StartSFXEvent("Heart");
                Health += 1;
                healthText.text = "Health: " + Health.ToString();
                other.gameObject.SetActive(false);
            }
        }
        else if (other.CompareTag("Star"))
        {
            EventManager.StartSFXEvent("Star");
            other.gameObject.SetActive(false);
            StartCoroutine(StarProtection());
        }
    }
    IEnumerator StarProtection()
    {   
        _capsuleCollider.enabled = false;
        _animator.enabled = false;
        _transform.Find("Wings").gameObject.SetActive(true);
        EventManager.StartSFXEvent("Wings");
        _audioSource.enabled = false;

        _transform.DOMove(new Vector3(-0.07f, -0.5f, -0.5f), 1, false);
        yield return new WaitForSecondsRealtime(6);
        _transform.DOMove(new Vector3(-0.05f, -1.7f, -2f), 1, false);
        yield return new WaitForSecondsRealtime(1);

        _transform.Find("Wings").gameObject.SetActive(false);
        _audioSource.enabled = true;
        _animator.enabled = true;
        _capsuleCollider.enabled = true;
    }   

}
