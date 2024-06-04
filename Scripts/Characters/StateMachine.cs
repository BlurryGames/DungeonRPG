using Godot;
using System;

public partial class StateMachine : Node
{
    [Export] private Node currentState = null;
    [Export] private Node[] states = null;

    public override void _Ready()
    {
        currentState.Notification(5001);
    }
}