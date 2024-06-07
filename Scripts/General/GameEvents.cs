using System;

public class GameEvents
{
    public static event Action<int> OnNewEnemyCount = null;
    public static event Action OnStartGame = null;
    public static event Action OnEndGame = null;
    public static event Action OnVictory = null;

    public static void RaiseNewEnemyCount(int count) => OnNewEnemyCount?.Invoke(count);
    public static void RaiseStartGame() => OnStartGame?.Invoke();
    public static void RaiseEndGame() => OnEndGame?.Invoke();
    public static void RaiseVictory() => OnVictory?.Invoke();
}