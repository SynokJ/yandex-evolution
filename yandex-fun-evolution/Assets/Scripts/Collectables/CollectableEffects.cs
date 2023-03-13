using UnityEngine;

public class CollectableEffects : MonoBehaviour
{

    [Header("Particle Components:")]
    [SerializeField] private ParticleSystem _particle;

    [Header("Take Components:")]
    [SerializeField] private CollectableTake _take;

    private bool _isEffected = false;

    private void Start()
    {
        _take.onHitEffected = OnCollectEffected;
    }

    private void Update()
    {
        if (!_isEffected)
            return;

        if (!_particle.isPlaying)
        {
            _isEffected = false;
            _take.OnCollectableShown();
        }
    }

    private void OnCollectEffected()
    {
        _particle.Play();
        _isEffected = true;
    }
}
