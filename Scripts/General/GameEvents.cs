using System;

public class GameEvents
{
    public static event Action OnStartGame = null;

    public static void RaiseStartGame() => OnStartGame?.Invoke();
}