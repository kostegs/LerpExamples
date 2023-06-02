using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LerpRotation : MonoBehaviour
{
    [SerializeField] private float _timeToTurn = 1.5f;

    private float _elapsedTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(LerpCoroutine());
    }

    IEnumerator LerpCoroutine()
    {
        Quaternion _targetRotation = Quaternion.Euler(0f, 0f, -90f); // 90 degrees rotation along z-axis
        yield return StartCoroutine(RotationCoroutine(transform.rotation, _targetRotation, _timeToTurn));

        _elapsedTime = 0;
        _targetRotation = Quaternion.Euler(Vector3.zero); // return to start position
        yield return StartCoroutine(RotationCoroutine(transform.rotation, _targetRotation, _timeToTurn));
    }

    IEnumerator RotationCoroutine(Quaternion startRotation, Quaternion targetRotation, float rotationTime)
    {
        _elapsedTime = 0;
        
        while (_elapsedTime < rotationTime)
        {
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, _elapsedTime / rotationTime);
            _elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        transform.rotation = targetRotation;
        yield return new WaitForSeconds(1);
    }
}
