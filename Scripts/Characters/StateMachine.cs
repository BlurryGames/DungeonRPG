using Godot;
using System.Linq;

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
        Node newState = states.FirstOrDefault(s => s is T);

        if (newState == null)
        {
            return;
        }

        currentState.Notification(GameConstants.NOTIFICATION_EXIT_STATE);
        currentState = newState;
        currentState.Notification(GameConstants.NOTIFICATION_ENTER_STATE);
    }
}