using UnityEngine;

public class CollectableTake : MonoBehaviour, ICollectable
{
    public delegate void OnHitEffected();
    public OnHitEffected onHitEffected = default;

    public delegate void OnPositionChanged();
    public OnPositionChanged onPositionChanged = default;

    [Header("Visual Components:")]
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Collider2D _collider;

    private Vector2 _lastPlayerPos;

    public void OnCollect(Vector2 pos)
    {
        onHitEffected?.Invoke();
        OnCollectableHidden();

        _lastPlayerPos = pos;
    }

    public void OnCollectableShown()
    {
        _renderer.enabled = true;
        _collider.enabled = true;

        onPositionChanged?.Invoke();
    }

    private void OnCollectableHidden()
    {
        _renderer.enabled = false;
        _collider.enabled = false;
    }
}
