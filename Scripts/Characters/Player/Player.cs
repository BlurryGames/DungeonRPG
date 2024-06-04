using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer animationPlayer = null;
    [Export] public Sprite3D sprite3D = null;
    [Export] public StateMachine stateMachine = null;

    public Vector2 direction = Vector2.Zero;

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector3(direction.X, 0.0f, direction.Y);
        Velocity *= 5.0f;

        MoveAndSlide();

        Flip();
    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector(GameConstants.INPUT_MOVE_LEFT, GameConstants.INPUT_MOVE_RIGHT,
                GameConstants.INPUT_MOVE_FORWARD, GameConstants.INPUT_MOVE_BACKWARD);
    }

    private void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0.0f;
        if (isNotMovingHorizontally)
        {
            return;
        }

        bool isMovingLeft = Velocity.X < 0.0f;
        sprite3D.FlipH = isMovingLeft;
    }
}