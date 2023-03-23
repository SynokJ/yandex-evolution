public class MinionSpawnSystem : SpawnSystem
{

    private UnityEngine.GameObject _enemyPref;
    private UnityEngine.GameObject _tempEnemy;

    public MinionSpawnSystem(UnityEngine.GameObject pref)
    {
        _enemyPref = pref;
    }

    public override void OnSpawn()
    {

        _tempEnemy = UnityEngine.GameObject.Instantiate(_enemyPref);
        AimTargetHandler.AddTargetTransform(_tempEnemy.transform);
    }
}
