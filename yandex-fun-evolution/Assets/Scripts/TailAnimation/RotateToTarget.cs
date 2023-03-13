using UnityEngine;

public class RotateToTarget : MonoBehaviour
{

    [Header("Animation Parameters:")]
    [Range(3, 10)]
    [SerializeField] private float rotationSpeed;

    [Header("Player Input Componenets:")]
    [SerializeField] private PlayerInput _input;

    private Vector2 _direction;
    private Camera _camera;
    private Quaternion _rotation;
    private float _angle;

    private void Start()
    {
        _camera = Camera.main;
        _input.onDirectionSetted = OnRotatedToDirection;
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, _rotation, rotationSpeed * Time.deltaTime);
    }

    private void OnRotatedToDirection(Vector2 touchPos)
    {
        _direction = (_camera.ScreenToWorldPoint(touchPos) - transform.position).normalized;
        _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        _rotation = Quaternion.AngleAxis(_angle, transform.forward);
    }
}