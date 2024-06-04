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
        animationPlayer.Play("Idle");
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = new Vector3(direction.X, 0.0f, direction.Y);
        Velocity *= 5.0f;

        MoveAndSlide();
    }

    public override void _Input(InputEvent @event)
    {
        direction = Input.GetVector("MoveLeft", "MoveRight", "MoveForward", "MoveBackward");
        if (direction == Vector2.Zero)
        {
            animationPlayer.Play("Idle");
        }
        else
        {
            animationPlayer.Play("Move");
        }
    }
}