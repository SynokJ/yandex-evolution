public class HealthSystem
{
    private int _healthPoints = 0;
    private int _rewardAmount = 0;

    public int HealthPoints { get => _healthPoints; }
    public int RewardAmount { get => _rewardAmount; }

    public HealthSystem(int healthPoints, int rewardCmount = 0)
    {
        _healthPoints = healthPoints;
        _rewardAmount = rewardCmount;
    }

    ~HealthSystem()
    {
        _healthPoints = 0;
        _rewardAmount = 0;
    }

    public void DecreaseHP(int damage)
    {
        _healthPoints -= damage;

        if (_healthPoints < 0)
            _healthPoints = 0;
    }
}
