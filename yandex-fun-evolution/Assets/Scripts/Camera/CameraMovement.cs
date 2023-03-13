using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [Header("Player Components:")]
    [SerializeField] private Transform _playerTr;

    private Transform _currentTr;
    private Vector3 _cameraOffset;

    private void Start()
    {
        _currentTr = transform;
        _cameraOffset = new Vector3(0.0f, 0.0f, _currentTr.position.z);
    }

    void LateUpdate()
    {
        _currentTr.position = _playerTr.position + _cameraOffset;
    }
}
