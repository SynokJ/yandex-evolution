using UnityEngine;

public class MinionController : MonoBehaviour, IHitableEntity
{
    public enum CommandType
    {
        movement = 0,
        fight = 1
    }

    [Header("Movement Components:")]
    [SerializeField] private Transform _minionTr;

    [Header("Minion Components:")]
    [SerializeField] private MinionSO _minionSO;

    private CommandType _currentCommandType = default;
    private ICommand _currentCommand = default;
    private HealthSystem _enemyHealthSystem = default;

    private CommandMove _moveCommand = default;
    private CommandFight _fightCommand = default;

    private void OnEnable()
    {
        _enemyHealthSystem = new HealthSystem(_minionSO.healthPoints);
        _moveCommand = new CommandMove(_minionTr, OnSwitchCommand);
        _fightCommand = new CommandFight(_minionSO.attackSpeed, _minionSO.damagePoints, OnSwitchCommand);

        transform.position = OriginController.GetRndOrigin();
        _currentCommandType = CommandType.movement;
        _currentCommand = _moveCommand;
    }

    private void FixedUpdate()
    {
        _currentCommand.OnProcess();
    }

    public void OnRecieveDamage(int damage)
    {
        _enemyHealthSystem?.DecreaseHP(damage);
        if (_enemyHealthSystem.HealthPoints <= 0)
            OnKilled();
    }

    public void OnSwitchCommand()
    {
        _currentCommandType++;

        if (_currentCommandType > CommandType.fight)
            _currentCommandType = CommandType.movement;

        switch (_currentCommandType)
        {
            case CommandType.movement:
                _currentCommand = _moveCommand;
                break;
            case CommandType.fight:
                _currentCommand = _fightCommand;
                break;
        }
    }

    public void OnKilled()
    {
        transform.position = OriginController.GetRndOrigin();
        _enemyHealthSystem = new HealthSystem(_minionSO.healthPoints);
        _currentCommand = _moveCommand;
    }
}
