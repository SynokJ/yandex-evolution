public class PoolSystem
{
    private System.Collections.Generic.Queue<Spawnable> _pool
         = new System.Collections.Generic.Queue<Spawnable>();

    private UnityEngine.GameObject _prefObject = null;
    private Spawnable _currentObject = null;

    public PoolSystem(UnityEngine.GameObject pref)
    {
        _prefObject = pref;
    }

    ~PoolSystem()
    {
        _prefObject = null;
        _currentObject = null;

        _pool.Clear();
    }

    public void InitPoolObjects(int amount, string poolName)
    {
        UnityEngine.Transform parentTr = new UnityEngine.GameObject(poolName).GetComponent<UnityEngine.Transform>();
        UnityEngine.GameObject tempObj = default;
        Spawnable tempSpawnable = null;

        for (int i = 0; i < amount; ++i)
        {
            tempObj = UnityEngine.GameObject.Instantiate(_prefObject);

            if (tempObj.TryGetComponent<Spawnable>(out tempSpawnable))
            {
                tempObj.transform.parent = parentTr;
                tempSpawnable.OnHideSpawnable();
                _pool.Enqueue(tempSpawnable);
            }
        }
    }

    public UnityEngine.GameObject OnSpawnObject()
    {
        _currentObject = _pool.Dequeue();
        _currentObject.OnShowSpawnable();
        _pool.Enqueue(_currentObject);

        return _currentObject.gameObject;
    }
}
