public class LightEnemy : Tank
{
    public LightEnemy()
    {
        health = 1;
    }

    protected override void DestroyTank()
    {
        EventManager.EnemyKilled("light");
        base.DestroyTank();
    }
}
