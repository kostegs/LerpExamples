using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SimpleMovingCourutine : MonoBehaviour
{
    [SerializeField] private Transform _goalObject;

    private float _timeForMoving = 4;    
    private Vector2 _startPosition;
    private bool _isMoving;   
    
    void Start() => _startPosition = transform.position;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isMoving == false)
            StartCoroutine(LerpCoroutine());
    }

    IEnumerator LerpCoroutine()
    {
        float elapsedTime = 0;
        float delta = 0;
        _isMoving = true;

        while (elapsedTime < _timeForMoving)
        {
            delta = elapsedTime / _timeForMoving;
            transform.position = Vector2.Lerp(_startPosition, _goalObject.position, delta);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = _goalObject.position;
        _isMoving = false;
    }
}
