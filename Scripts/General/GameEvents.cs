using System;

public class GameEvents
{
    public static Action OnStartGame = null;

    public static void RaiseStartGame() => OnStartGame?.Invoke();
}