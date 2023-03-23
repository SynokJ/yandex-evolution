using System.Collections;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private const float _MINION_SPAWN_DELAY = 1.0f;
    private const int _MINION_SPAWN_AMOUNT = 3;

    public static SpawnController Instance = null;

    [Header("Spawn Components:")]
    [SerializeField] private GameObject _enemyPref;
    [SerializeField] private GameObject _minionPref;

    private SpawnSystem _enemySpawn;
    private SpawnSystem _minionSpawn;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        _enemySpawn = new EnemySpawnSystem(_enemyPref);
        _minionSpawn = new MinionSpawnSystem(_minionPref);

        _enemySpawn.OnSpawn();
        StartCoroutine(SpawnMinionWithDelay());
    }

    private IEnumerator SpawnMinionWithDelay()
    {
        for (int i = 0; i < _MINION_SPAWN_AMOUNT; ++i)
        {
            _minionSpawn.OnSpawn();
            yield return new WaitForSeconds(_MINION_SPAWN_DELAY);
        }
    }

    public void OnMinionSpawn() => _minionSpawn.OnSpawn();
    public void OnEnemyChange() => _enemySpawn.OnSpawn();
}
