public static class AimTargetHandler
{
    private static System.Collections.Generic.List<UnityEngine.Transform> _targets
        = new System.Collections.Generic.List<UnityEngine.Transform>();

    public static void AddTargetTransform(UnityEngine.Transform targetTr)
    {
        if (!_targets.Contains(targetTr))
            _targets.Add(targetTr);
    }

    public static void RemoveTargetTransform(UnityEngine.Transform targetTr)
    {
        if (_targets.Contains(targetTr))
            _targets.Remove(targetTr);
    }

    public static bool GetClosestTransform(out UnityEngine.Transform resTr)
    {
        resTr = default;

        if (_targets.Count == 0)
            return false;
        else if (_targets.Count == 1)
        {
            resTr = _targets[0];
            return true;
        }

        resTr = _targets[0];
        for (int i = 1; i < _targets.Count; ++i)
            if (IsTransformCloser(resTr.position, _targets[i].position))
                resTr = _targets[i];

        return true;
    }

    private static bool IsTransformCloser(UnityEngine.Vector2 currentPos, UnityEngine.Vector2 targetPos)
    {
        float dist_1 = UnityEngine.Vector2.Distance(UnityEngine.Vector2.zero, currentPos);
        float dist_2 = UnityEngine.Vector2.Distance(UnityEngine.Vector2.zero, targetPos);

        return dist_1 > dist_2;
    }
}