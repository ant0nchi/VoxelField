public class HeavyEnemy : Tank
{
    public HeavyEnemy()
    {
        health = 3;
    }

    protected override void DestroyTank()
    {
        EventManager.EnemyKilled("heavy");
        base.DestroyTank();
    }
}
