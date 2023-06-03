using System.Collections;
using UnityEngine;

public class FadeSound : MonoBehaviour
{
    [SerializeField] private float _targetValue = 0.8f;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _fadeDuration = 10f;
    
    void Start() => StartCoroutine(LerpAudio(_audioSource.volume, _targetValue, _fadeDuration));

    IEnumerator LerpAudio(float startValue, float endValue, float duration)
    {
        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            _audioSource.volume = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _audioSource.volume = endValue;
    }
}
