using Godot;
using System;
using static Godot.TextServer;

public partial class PlayerMoveState : PlayerState
{
    [Export] private float speed = 5.0f;

    public override void _PhysicsProcess(double delta)
    {
        if (player.direction == Vector2.Zero)
        {
            player.stateMachine.SwitchState<PlayerIdleState>();
            return;
        }

        player.Velocity = new Vector3(player.direction.X, 0.0f, player.direction.Y);
        player.Velocity *= speed;

        player.MoveAndSlide();

        player.Flip();
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_DASH))
        {
            player.stateMachine.SwitchState<PlayerDashState>();
        }
    }

    protected override void EnterState()
    {
        base.EnterState();

        player.animationPlayer.Play(GameConstants.ANIM_MOVE);
    }
}