public class LightEnemy : Tank // INHERITANCE
{ 
    public LightEnemy()
    {
        health = 1;
    }

    protected override void DestroyTank() // POLYMORPHISM
    {
        EventManager.EnemyKilled("light");
        base.DestroyTank();
    }
}
