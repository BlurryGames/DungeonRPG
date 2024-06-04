using Godot;
using System;
using static Godot.TextServer;

public partial class PlayerMoveState : PlayerState
{
    [Export(PropertyHint.Range, "0.0f, 20.0f, 0.1f")] private float speed = 5.0f;

    public override void _PhysicsProcess(double delta)
    {
        if (player.Direction == Vector2.Zero)
        {
            player.StateMachine.SwitchState<PlayerIdleState>();
            return;
        }

        player.Velocity = new Vector3(player.Direction.X, 0.0f, player.Direction.Y);
        player.Velocity *= speed;

        player.MoveAndSlide();

        player.Flip();
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_DASH))
        {
            player.StateMachine.SwitchState<PlayerDashState>();
        }
    }

    protected override void EnterState()
    {
        base.EnterState();

        player.AnimationPlayer.Play(GameConstants.ANIM_MOVE);
    }
}