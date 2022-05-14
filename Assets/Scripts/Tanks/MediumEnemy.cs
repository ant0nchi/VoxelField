public class MediumEnemy : Tank
{
    protected override void DestroyTank()
    {
        EventManager.EnemyKilled("medium");
        base.DestroyTank();
    }
}
