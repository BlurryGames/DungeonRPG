using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
    [Export] private PackedScene bombScene = null;

    [Export] private Timer dashTimer = null;
    [Export] private Timer cooldownTimer = null;

    [Export(PropertyHint.Range, "0.0f, 20.0f, 0.1f")] private float speed = 10.0f;

    public override void _Ready()
    {
        base._Ready();
        dashTimer.Timeout += HandleDashTimeout;
        CanTransition = () => cooldownTimer.IsStopped();
    }

    public override void _PhysicsProcess(double delta)
    {
        character.MoveAndSlide();
        character.Flip();
    }

    protected override void EnterState()
    {
        base.EnterState();
        character.AnimationPlayer.Play(GameConstants.ANIM_DASH);
        character.Velocity = new Vector3(character.Direction.X, 0.0f, character.Direction.Y);
        if (character.Velocity == Vector3.Zero)
        {
            character.Velocity = character.Sprite3D.FlipH ? Vector3.Left : Vector3.Right;
        }

        character.Velocity *= speed;
        dashTimer.Start();

        Bomb bomb = bombScene.Instantiate<Bomb>();
        GetTree().CurrentScene.AddChild(bomb);
        bomb.GlobalPosition = character.GlobalPosition;
    }

    private void HandleDashTimeout()
    {
        cooldownTimer.Start();

        character.Velocity = Vector3.Zero;
        character.StateMachine.SwitchState<PlayerIdleState>();
    }
}
