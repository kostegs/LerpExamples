using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LerpRotation : MonoBehaviour
{
    private float _elapsedTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(LerpCoroutine());            

        // TODO - корутины - поворот в одну сторону, потом обратно
    }

    IEnumerator LerpCoroutine()
    {
        Quaternion _targetRotation = Quaternion.Euler(0f, 0f, -90f); // 90 degrees rotation along z-axis
        yield return StartCoroutine(RotationCoroutine(transform.rotation, _targetRotation, 3));

        _elapsedTime = 0;
        _targetRotation = Quaternion.Euler(0f, 0f, 0f);
        yield return StartCoroutine(RotationCoroutine(transform.rotation, _targetRotation, 3));
    }

    IEnumerator RotationCoroutine(Quaternion startRotation, Quaternion targetRotation, float _rotationTime)
    {
        _elapsedTime = 0;
        
        while (_elapsedTime < _rotationTime)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, _elapsedTime / _rotationTime);
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        transform.rotation = targetRotation;
    }
}
