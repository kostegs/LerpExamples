using System.Collections;
using UnityEngine;

public class LerpColor : MonoBehaviour
{
    [SerializeField] private float _timeToScale = 0.2f;
    [SerializeField] private Color _targetColor;

    private SpriteRenderer _spriteRenderer;

    private void Start() => _spriteRenderer = GetComponent<SpriteRenderer>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(LerpCoroutine());
    }

    IEnumerator LerpCoroutine()
    {
        Color savedColor = _spriteRenderer.color;
        yield return StartCoroutine(ColorCoroutine(_targetColor, _timeToScale));

        yield return StartCoroutine(ColorCoroutine(savedColor, _timeToScale));
    }

    IEnumerator ColorCoroutine(Color targetColor, float scaleTime)
    {
        float elapsedTime = 0;
        Color startColor = _spriteRenderer.color;
        
        while (elapsedTime < scaleTime)
        {
            _spriteRenderer.color = Color.Lerp(startColor, targetColor, elapsedTime / scaleTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _spriteRenderer.color = targetColor;
        yield return new WaitForSeconds(1);
    }
}
