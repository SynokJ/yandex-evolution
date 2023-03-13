using UnityEngine;

public class CollectableEvolve : MonoBehaviour, IEvolutionable
{


    [Header("Evolution Components:")]
    [SerializeField] private SpriteRenderer _renderer;

    private CollectableSO _collectableSO;

    private void Start()
    {
        EvolutionListener.OnListen(this);
        UpdateCollectableData();
    }

    private void OnDestroy()
    {
        EvolutionListener.OnUnListen(this);
    }

    public void OnEvoluted()
    {
        UpdateCollectableData();
    }

    private void UpdateCollectableData()
    {
        _collectableSO = LevelKeeper.instance.GetLevel().collectable;
        _renderer.sprite = _collectableSO.collectableSprite;
    }
}
