using System;

public class GameEvents
{
    public static event Action OnStartGame = null;
    public static event Action OnEndGame = null;

    public static void RaiseStartGame() => OnStartGame?.Invoke();
    public static void RaiseEndGame() => OnEndGame?.Invoke();
}