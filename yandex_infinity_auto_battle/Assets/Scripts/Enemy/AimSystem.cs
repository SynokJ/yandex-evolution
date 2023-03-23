public class AimSystem
{
    private UnityEngine.Transform _targetTr = default;

    public AimSystem()
    {
    }

    public bool TryGetTarget(out UnityEngine.Vector2 targetPos)
    {
        bool stat = AimTargetHandler.GetClosestTransform(out _targetTr);
        targetPos = !stat ? default : _targetTr.position;
        return stat;
    }
}
