public class MediumEnemy : Tank // INHERITANCE
{
    protected override void DestroyTank() // POLYMORPHISM
    {
        EventManager.EnemyKilled("medium");
        base.DestroyTank();
    }
}
