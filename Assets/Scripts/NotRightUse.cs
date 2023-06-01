using UnityEngine;

public class NotRightUse : MonoBehaviour
{
    [SerializeField] private Transform _goalObject;

    private Vector2 _startPosition;

    private void Start() => _startPosition = transform.position;

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, _goalObject.position, Time.deltaTime * 2);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = _startPosition;
        }
    }
}
