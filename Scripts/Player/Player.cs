using Godot;
using System;

public partial class Player : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] private AnimationPlayer animationPlayer = null;
    [Export] private Sprite3D sprite3D = null;

    private Vector2 direction = Vector2.Zero;

    public override void _Ready()
    {
        animationPlayer.Play(GameConstants.ANIM_IDLE);
    }

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
        if (direction == Vector2.Zero)
        {
            animationPlayer.Play(GameConstants.ANIM_IDLE);
        }
        else
        {
            animationPlayer.Play(GameConstants.ANIM_MOVE);
        }
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