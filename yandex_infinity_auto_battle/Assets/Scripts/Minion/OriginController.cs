public static class OriginController
{
    private const float _MIN_HOR_RANGE = 8;
    private const float _MAX_HOR_RANGE = 12;

    private const float _MIN_VER_RANGE = 8;
    private const float _MAX_VER_RANGE = 12;

    public static UnityEngine.Vector2 GetRndOrigin()
        => new UnityEngine.Vector2(GetRndValue(_MIN_HOR_RANGE, _MAX_HOR_RANGE), GetRndValue(_MIN_VER_RANGE, _MAX_VER_RANGE));

    private static float GetRndValue(float min, float max)
    {
        float val = UnityEngine.Random.Range(min, max);
        float rndNum = UnityEngine.Random.Range(0, 2);

        return rndNum == 0 ? val : -val;
    }
}
