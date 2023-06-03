using System.Collections;
using UnityEngine;

public class FadeText : MonoBehaviour
{
    [SerializeField] private CanvasRenderer[] _letters;
    [SerializeField] private float _durationToShow;
    [SerializeField] private float _durationToFade;

    private void Start()
    {
        foreach (var letter in _letters)
        {
            Debug.Log(letter.GetAlpha());
            letter.SetAlpha(0);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
            StartCoroutine(FadeLetter());                       
    }

    IEnumerator FadeLetter()
    {
        foreach(var letter in _letters)
        {
            float startValue = letter.GetAlpha();
            yield return StartCoroutine(SetAlfa(letter, startValue, 1, _durationToShow));
        }

        foreach (var letter in _letters)
        {
            float startValue = letter.GetAlpha();
            StartCoroutine(SetAlfa(letter, startValue, 0, _durationToFade));
        }        
    }

    IEnumerator SetAlfa(CanvasRenderer letter, float startValue, float endValue, float duration)
    {
        float elapsedTime = 0;        

        while (elapsedTime < duration)
        {
            letter.SetAlpha(Mathf.Lerp(startValue, endValue, elapsedTime / duration));            
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        letter.SetAlpha(endValue);
    }
}
