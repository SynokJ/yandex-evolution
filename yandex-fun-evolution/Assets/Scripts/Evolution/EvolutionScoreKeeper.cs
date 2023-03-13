public static class EvolutionScoreKeeper
{
    private const int _ADD_POINTS = 10;
    //private const 

    public static int _currentValue;

    public static void AddEvolutionScore() => _currentValue += _ADD_POINTS;
}
