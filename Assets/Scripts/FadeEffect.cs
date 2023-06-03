using System.Collections;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    private CanvasRenderer _canvasRenderer;
    private float _duration = 3;

    private void Start() => _canvasRenderer = GetComponent<CanvasRenderer>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartCoroutine(SetAlfa());
    }

    IEnumerator SetAlfa()
    {
        float elapsedTime = 0;
        float startValue = _canvasRenderer.GetAlpha();

        while (elapsedTime < _duration)
        {
            _canvasRenderer.SetAlpha(Mathf.Lerp(startValue, 0, elapsedTime / _duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _canvasRenderer.SetAlpha(0);
    }
}
