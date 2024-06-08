using Godot;
using System.Linq;

public partial class StateMachine : Node
{
    [Export] private CharacterState currentState = null;
    [Export] private CharacterState[] states = null;

    public override void _Ready()
    {
        currentState.Notification(GameConstants.NOTIFICATION_ENTER_STATE);
    }

    public void SwitchState<T>()
    {
        CharacterState newState = states.FirstOrDefault(s => s is T);

        if (newState == null)
        {
            return;
        }

        if (currentState is T)
        {
            return;
        }

        if (!newState.CanTransition())
        {
            return;
        }

        currentState.Notification(GameConstants.NOTIFICATION_EXIT_STATE);
        currentState = newState;
        currentState.Notification(GameConstants.NOTIFICATION_ENTER_STATE);
    }
}