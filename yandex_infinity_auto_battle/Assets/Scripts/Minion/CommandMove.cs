public class CommandMove : ICommand
{
    private const float _MOVEMENT_SPEED = 1.0f;
    private const float _TARGET_DISTANCE = 1.5f;

    private const float _DESTINATION_POS_X = 0.0f;
    private const float _DESTIANTION_POS_Y = 0.0f;

    private UnityEngine.Transform _minionTr = default;
    private UnityEngine.Vector2 _destPoint = new UnityEngine.Vector2(_DESTINATION_POS_X, _DESTIANTION_POS_Y);

    public delegate void OnCommandSwitched();
    private OnCommandSwitched _onCommandSwitched = default;

    public CommandMove(UnityEngine.Transform minionTr, OnCommandSwitched cmdSwitch)
    {
        _minionTr = minionTr;
        _onCommandSwitched = cmdSwitch;
    }

    public void OnProcess()
    {
        if (!IsDestinationReached())
            _minionTr.position =
                UnityEngine.Vector2.MoveTowards(_minionTr.position, _destPoint, _MOVEMENT_SPEED * UnityEngine.Time.deltaTime);
        else
            OnSwitched();
    }

    public void OnSwitched()
    {
        _onCommandSwitched?.Invoke();
    }

    private bool IsDestinationReached()
        => UnityEngine.Vector2.Distance(_minionTr.position, _destPoint) <= _TARGET_DISTANCE;
}
