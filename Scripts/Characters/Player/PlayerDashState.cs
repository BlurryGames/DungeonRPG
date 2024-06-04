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
        player.MoveAndSlide();
        player.Flip();
    }

    protected override void EnterState()
    {
        base.EnterState();
        player.AnimationPlayer.Play(GameConstants.ANIM_DASH);
        player.Velocity = new Vector3(player.Direction.X, 0.0f, player.Direction.Y);
        if (player.Velocity == Vector3.Zero)
        {
            player.Velocity = player.Sprite3D.FlipH ? Vector3.Left : Vector3.Right;
        }

        player.Velocity *= speed;
        timer.Start();
    }

    private void HandleDashTimeout()
    {
        player.Velocity = Vector3.Zero;
        player.StateMachine.SwitchState<PlayerIdleState>();
    }
}
