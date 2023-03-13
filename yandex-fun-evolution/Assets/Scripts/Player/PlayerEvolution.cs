using UnityEngine;

public class PlayerEvolution : MonoBehaviour, IEvolutionable
{
    [Header("Evolution Components:")]
    [SerializeField] private LineRenderer _line;

    private PlayerSO _playerData = null;

    private void Start()
    {
        EvolutionListener.OnListen(this);
        UpdatePlayerData();
    }

    private void OnDestroy()
    {
        EvolutionListener.OnUnListen(this);
    }

    public void OnEvoluted()
    {
        UpdatePlayerData();
    }

    private void UpdatePlayerData()
    {
        _playerData = LevelKeeper.instance.GetLevel().player;
        _line.material = _playerData.tailMaterail;
    }
}