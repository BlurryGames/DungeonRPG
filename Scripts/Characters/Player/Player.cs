using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimationPlayer { get; private set; } = null;
    [Export] public Sprite3D Sprite3D { get; private set; } = null;
    [Export] public StateMachine StateMachine { get; private set; } = null;

    public Vector2 Direction { get; private set; } = Vector2.Zero;

    public override void _Input(InputEvent @event)
    {
        Direction = Input.GetVector(GameConstants.INPUT_MOVE_LEFT, GameConstants.INPUT_MOVE_RIGHT,
                GameConstants.INPUT_MOVE_FORWARD, GameConstants.INPUT_MOVE_BACKWARD);
    }

    public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0.0f;
        if (isNotMovingHorizontally)
        {
            return;
        }

        bool isMovingLeft = Velocity.X < 0.0f;
        Sprite3D.FlipH = isMovingLeft;
    }
}