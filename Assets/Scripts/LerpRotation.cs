using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LerpRotation : MonoBehaviour
{
    private Quaternion _startRotation;
    private Quaternion _targetRotation;

    private float _elapsedTime;
    private float _rotationTime = 3;

    private void Start()
    {
        _startRotation = transform.rotation;
        _targetRotation = Quaternion.Euler(0f, 0f, -90f); // 90 degrees rotation along z-axis
    }

    private void Update()
    {
        float delta = _elapsedTime / _rotationTime;
        
        if (_elapsedTime < _rotationTime)
        {
            transform.rotation = Quaternion.Lerp(_startRotation, _targetRotation, delta);
            _elapsedTime += Time.deltaTime;
        }
        else
        {
            transform.rotation = _targetRotation;
        }

        // TODO - корутины - поворот в одну сторону, потом обратно
    }
}
