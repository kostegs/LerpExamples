using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoving : MonoBehaviour
{
    [SerializeField] private Transform _goalObject;

    private float _timeForMoving = 4;
    private float _elapsedTime;
    private Vector2 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        if ( _elapsedTime < _timeForMoving)
        {
            float delta = _elapsedTime / _timeForMoving;
            transform.position = Vector2.Lerp(_startPosition, _goalObject.position, delta);
            _elapsedTime += Time.deltaTime;
        }
        else
        {
            transform.position = _goalObject.position;
        }
           

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _elapsedTime = 0;
            transform.position = _startPosition;
        }
    }
}
