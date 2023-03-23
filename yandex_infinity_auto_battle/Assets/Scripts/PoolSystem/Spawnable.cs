using UnityEngine;

public abstract class Spawnable : MonoBehaviour
{
    [Header("Visual Componenets:")]
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Collider2D _collider;

    public void OnShowSpawnable()
    {
        _renderer.enabled = true;
        _collider.enabled = true;
    }

    public void OnHideSpawnable()
    {
        _renderer.enabled = false;
        _collider.enabled = false;
    }
}