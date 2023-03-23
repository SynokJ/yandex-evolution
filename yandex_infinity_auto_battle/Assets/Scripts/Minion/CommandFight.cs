public class CommandFight : ICommand
{

    public delegate void OnCommandSwitched();
    private OnCommandSwitched _onCommandSwitched = default;

    private float _attackDelay = 0;
    private float _currentTimeDelay = 0.0f;
    private int _damagePoints = 0;

    public CommandFight(float delay, int damagePoints, OnCommandSwitched cmdSwitch)
    {
        _onCommandSwitched = cmdSwitch;
        _currentTimeDelay = _attackDelay;
        _damagePoints = damagePoints;
    }

    public void OnProcess()
    {
        if (_currentTimeDelay <= 0)
        {
            EnemyHitListener.OnHit(_damagePoints);
            _currentTimeDelay = _attackDelay;
        }
        else
            _currentTimeDelay = UnityEngine.Time.deltaTime;
    }

    public void OnSwitched()
    {
        _onCommandSwitched?.Invoke();
    }
}
