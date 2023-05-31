using UnityEngine;

public class SimpleLerp : MonoBehaviour
{
    void Update()
    {
        float _firstPoint = 0;
        float _secondPoint = 100;
        float _delta = 0.5f;

        var lerpResult = Mathf.Lerp(_firstPoint, _secondPoint, _delta);

        Debug.Log(lerpResult.ToString()); // Выведет 50 в консоль
    }
}
