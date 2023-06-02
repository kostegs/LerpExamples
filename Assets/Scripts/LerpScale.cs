using System.Collections;
using UnityEngine;

public class LerpScale : MonoBehaviour
{
    [SerializeField] private float _timeToScale = 0.5f;

    private Vector3 _savedLocalScale;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(LerpCoroutine());
    }

    IEnumerator LerpCoroutine()
    {
        float originalScale = 1f;
        float howMuchTimesScale = 2f;

        _savedLocalScale = transform.localScale;
        yield return StartCoroutine(ScaleCoroutine(originalScale, howMuchTimesScale, _timeToScale));
        
        yield return StartCoroutine(ScaleCoroutine(howMuchTimesScale, originalScale, _timeToScale));
    }

    IEnumerator ScaleCoroutine(float startValue, float endValue, float scaleTime)
    {
        float elapsedTime = 0;
        Vector3 startScale = _savedLocalScale;
        float scaleModifier;

        while (elapsedTime < scaleTime)
        {
            scaleModifier = Mathf.Lerp(startValue, endValue, elapsedTime / scaleTime);            
            transform.localScale = startScale * scaleModifier;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = startScale * endValue;
        yield return new WaitForSeconds(1);
    }
}
