using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private const int _TOUCH_INDEX = 0;

    [Header("Enemy Components:")]
    [SerializeField] private EnemySO _enemySO;

    [Header("Shoot Components:")]
    [SerializeField] private GameObject _bulletPref;

    private ShootSystem _shoot = default;
    private HealthSystem _enemyHealthSystem = default;

    private Touch _firstTouch = default;
    private Camera _camera = default;

    private SpawnController _spawnController = null;

    private void OnEnable()
    {
        _camera = Camera.main;
        _spawnController = SpawnController.Instance;

        _shoot = new ShootSystem(_bulletPref, _enemySO.attackDelay, new AimSystem());
        _enemyHealthSystem = new HealthSystem(_enemySO.healthPoints, _enemySO.rewardPoints);
        EnemyHitListener.OnEnemyInited(OnHitEnemy);

        SetRndColor();
    }

    private void SetRndColor()
    {
        float rndR = Random.Range(0.0f, 255f);
        float rndG = Random.Range(0.0f, 255f);
        float rndB = Random.Range(0.0f, 255f);

        GetComponentInChildren<SpriteRenderer>().color = new Color(rndR / 255, rndG / 255, rndB / 255);
    }

    private void OnDisable()
    {
        _shoot = null;
        _enemyHealthSystem = null;
    }

    private void Update()
    {
        _shoot.OnBulletShot();
    }

    private void OnHitEnemy(int damage)
    {
        _enemyHealthSystem.DecreaseHP(damage);

        if (_enemyHealthSystem.HealthPoints <= 0)
            _spawnController.OnEnemyChange();
    }
}
