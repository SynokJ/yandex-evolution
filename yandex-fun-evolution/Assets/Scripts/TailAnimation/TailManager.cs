using UnityEngine;

public class TailManager : MonoBehaviour
{
    [SerializeField] private int length;
    [SerializeField] private LineRenderer _line;
    [SerializeField] private Transform _targetPos;
    [SerializeField] private float _targetDist;
    [SerializeField] private float _smoothSpeeed;
    [SerializeField] private float _trailSpeeed;

    private Vector3[] _segments;
    private Vector3[] _segmentsV;

    private void Start()
    {
        _line.positionCount = length;
        _segments = new Vector3[length];
        _segmentsV = new Vector3[length];
    }

    private void Update()
    {
        _segments[0] = _targetPos.position;

        for (int i = 1; i < _segments.Length; ++i)
        {
            Vector3 target = _segments[i - 1] + _targetPos.right * _targetDist;
            _segments[i] = Vector3.SmoothDamp(_segments[i], target, ref _segmentsV[i], _smoothSpeeed + i / _trailSpeeed);
        }

        _line.SetPositions(_segments);
    }
}