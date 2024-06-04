using Godot;
using System;

public partial class StateMachine : Node
{
    [Export] private Node currentState = null;
    [Export] private Node[] states = null;

    public override void _Ready()
    {
        currentState.Notification(GameConstants.NOTIFICATION_ENTER_STATE);
    }

    public void SwitchState<T>()
    {
        Node newState = null;
        foreach (Node s in states)
        {
            if (s is T)
            {
                newState = s;
            }
        }

        if (newState == null)
        {
            return;
        }

        currentState.Notification(GameConstants.NOTIFICATION_EXIT_STATE);
        currentState = newState;
        currentState.Notification(GameConstants.NOTIFICATION_ENTER_STATE);
    }
}