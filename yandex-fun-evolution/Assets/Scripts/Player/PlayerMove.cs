using System.Linq;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [Header("Movement Components:")]
    [SerializeField] private PlayerInput _input;
    [SerializeField] private PlayerHitDetector _hitDetector;

    private const float _MOVEMENT_SPEED = 3.0f;

    private Camera _camera;
    private Vector2 _destinationalPos;

    private void Start()
    {
        _input.onDestintaionalSetted = OnDestinationalSet;
        _camera = Camera.main;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _destinationalPos, _MOVEMENT_SPEED * Time.deltaTime);
    }

    private void OnDestinationalSet(Vector2 pos) => _destinationalPos = _camera.ScreenToWorldPoint(pos);
}
