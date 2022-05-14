public class HeavyEnemy : Tank // INHERITANCE
{
    public HeavyEnemy()
    {
        health = 3;
    }

    protected override void DestroyTank() // POLYMORPHISM
    {
        EventManager.EnemyKilled("heavy");
        base.DestroyTank();
    }
}
