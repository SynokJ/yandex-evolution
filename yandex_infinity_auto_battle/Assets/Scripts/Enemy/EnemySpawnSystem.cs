public class EnemySpawnSystem : SpawnSystem
{

    private UnityEngine.GameObject _enemyPref = default;

    public EnemySpawnSystem(UnityEngine.GameObject pref)
    {
        _enemyPref = pref;
    }

    ~EnemySpawnSystem()
    {
        _enemyPref = null;
    }

    public override void OnSpawn() 
        => UnityEngine.GameObject.Instantiate(_enemyPref);
}
