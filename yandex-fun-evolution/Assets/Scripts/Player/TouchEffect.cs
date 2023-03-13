using UnityEngine;

public class TouchEffect : MonoBehaviour
{

    [Header("Effect Parameters:")]
    [SerializeField] private GameObject _particleEffectPref;
    [Range(3, 10)]
    [SerializeField] private int _maxParticles;

    [Header("Player Input:")]
    [SerializeField] private PlayerInput _input;

    private System.Collections.Generic.Queue<GameObject> _effectObjects =
        new System.Collections.Generic.Queue<GameObject>();

    private Camera _camera;
    private GameObject _tempObject;

    private void Start()
    {
        _input.onTouchEffected = OnStartEffect;
        _camera = Camera.main;

        InitBasicEffects();
    }

    private void InitBasicEffects()
    {
        _effectObjects.Clear();

        for (int i = 0; i < _maxParticles; ++i)
        {
            _tempObject = Instantiate(_particleEffectPref);
            _effectObjects.Enqueue(_tempObject);
        }
    }

    private void OnStartEffect(Vector2 pos)
    {
        Vector2 originPos = _camera.ScreenToWorldPoint(pos);
        //Instantiate(_particleEffectPref, originPos, Quaternion.identity);

        _tempObject = _effectObjects.Dequeue();
        _tempObject.GetComponent<ParticleSystem>().Play();
        _tempObject.transform.position = originPos;

        _effectObjects.Enqueue(_tempObject);
    }
}
