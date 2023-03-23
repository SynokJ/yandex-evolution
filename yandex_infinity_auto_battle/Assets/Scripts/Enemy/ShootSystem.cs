public class ShootSystem
{
    private const int _AMMO_SIZE = 10;
    private const string _PARENT_NAME = "Bullet Parent";

    private PoolSystem _poolSystem = default;
    private AimSystem _aimSystem = default;
    private SpawnableBullet _currentBullet = default;

    private float _shootDelay = 0;
    private float _currentShootDealy = 0;
    private UnityEngine.Vector2 _targetPos = default;

    public ShootSystem(UnityEngine.GameObject bulletPref, float shootDelay, AimSystem aim)
    {
        _poolSystem = new PoolSystem(bulletPref);
        _poolSystem.InitPoolObjects(_AMMO_SIZE, _PARENT_NAME);

        _shootDelay = shootDelay;
        _currentShootDealy = shootDelay;
        _aimSystem = aim;
    }

    ~ShootSystem()
    {
        _poolSystem = null;
        _currentBullet = null;

        _shootDelay = 0;
    }

    public void OnBulletShot()
    {
        if (_currentShootDealy <= 0)
            OnShootByAim();
        else
            _currentShootDealy -= UnityEngine.Time.deltaTime;
    }

    private void OnShootByAim()
    {
        _currentShootDealy = _shootDelay;
        _currentBullet = _poolSystem.OnSpawnObject().GetComponent<SpawnableBullet>();

        if (_currentBullet != null && _aimSystem.TryGetTarget(out _targetPos))
            _currentBullet.OnShotBullet(_targetPos);
    }
}
