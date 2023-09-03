using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Vector3 _positionStrength;
    [SerializeField] private Vector3 _rotationStrength;

    private void OnEnable()
    {
        EventManager.CameraShakeEvent += CameraShake;
    }
    private void CameraShake()
    {
        _camera.DOComplete();
        _camera.DOShakePosition(0.3f, _positionStrength);
        _camera.DOShakeRotation(0.3f, _rotationStrength);
    }
    private void OnDisable()
    {
        EventManager.CameraShakeEvent -= CameraShake;
    }
}
