using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveMoving : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private Transform _goalObject;
    [SerializeField] private float _timeToMove = 4f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(LerpMove());                
    }

    IEnumerator LerpMove()
    {
        Vector2 startPosition = transform.position;
        Vector2 goalPosition = _goalObject.position;
        yield return StartCoroutine(Move(startPosition, goalPosition, _timeToMove));

        (startPosition, goalPosition) = (goalPosition, startPosition);

        yield return StartCoroutine(Move(startPosition, goalPosition, _timeToMove));
    }

    IEnumerator Move(Vector2 startPosition, Vector2 goalPosition, float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            float delta = elapsedTime / duration;
            transform.position = Vector2.Lerp(startPosition, goalPosition, _curve.Evaluate(delta));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = goalPosition;
    }

}
