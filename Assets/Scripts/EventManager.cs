using System;

public class EventManager
{
    public static event Action<string> OnEnemyKilled;
    public static event Action<int> OnPlayerHarmed;
    public static event Action OnPlayerDestroyed;
    public static event Action <int>OnLevelPassed;

    public static void EnemyKilled(string enemyType)
    {
        OnEnemyKilled?.Invoke(enemyType);
    }

    public static void PlayerHarmed(int health)
    {
        OnPlayerHarmed?.Invoke(health);
    }

    public static void PlayerDestroyed()
    {
        OnPlayerDestroyed?.Invoke();
    }

    public static void LevelPassed(int score)
    {
        OnLevelPassed?.Invoke(score);
    }
}
