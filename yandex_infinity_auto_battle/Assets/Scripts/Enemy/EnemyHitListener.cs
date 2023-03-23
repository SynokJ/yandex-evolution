public static class EnemyHitListener 
{
    public delegate void OnHitEnemy(int damage);
    private static OnHitEnemy _onHitEnemy = default; 
    
    public static void OnEnemyInited(OnHitEnemy onHitEnemy)
    {
        _onHitEnemy = onHitEnemy;
    }

    public static void OnHit(int damage)
    {
        _onHitEnemy?.Invoke(damage);
    }
}
