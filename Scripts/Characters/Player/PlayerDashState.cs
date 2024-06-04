using Godot;
using System;

public partial class PlayerDashState : Node
{
    [Export] private Timer timer = null;

    [Export] private float speed = 10.0f;

    private Player player = null;

    public override void _Ready()
    {
        player = GetOwner<Player>();
        timer.Timeout += HandleDashTimeout;
    }

    public override void _PhysicsProcess(double delta)
    {
        player.MoveAndSlide();
        player.Flip();
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == 5001)
        {
            player.animationPlayer.Play(GameConstants.ANIM_DASH);
            player.Velocity = new Vector3(player.direction.X, 0.0f, player.direction.Y);
            if (player.Velocity == Vector3.Zero)
            {
                player.Velocity = player.sprite3D.FlipH ? Vector3.Left : Vector3.Right;
            }

            player.Velocity *= speed;
            timer.Start();
        }
    }

    private void HandleDashTimeout()
    {
        player.Velocity = Vector3.Zero;
        player.stateMachine.SwitchState<PlayerIdleState>();
    }
}
