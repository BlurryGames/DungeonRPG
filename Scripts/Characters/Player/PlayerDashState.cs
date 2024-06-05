using Godot;
using System;

public partial class PlayerDashState : PlayerState
{
    [Export] private Timer timer = null;

    [Export(PropertyHint.Range, "0.0f, 20.0f, 0.1f")] private float speed = 10.0f;

    public override void _Ready()
    {
        base._Ready();
        timer.Timeout += HandleDashTimeout;
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
        timer.Start();
    }

    private void HandleDashTimeout()
    {
        character.Velocity = Vector3.Zero;
        character.StateMachine.SwitchState<PlayerIdleState>();
    }
}
