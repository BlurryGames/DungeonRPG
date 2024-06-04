using Godot;
using System;
using static Godot.TextServer;

public partial class PlayerMoveState : Node
{
    private Player player = null;

    public override void _Ready()
    {
        player = GetOwner<Player>();
        SetPhysicsProcess(false);
        SetProcessInput(false);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (player.direction == Vector2.Zero)
        {
            player.stateMachine.SwitchState<PlayerIdleState>();
            return;
        }

        player.Velocity = new Vector3(player.direction.X, 0.0f, player.direction.Y);
        player.Velocity *= 5.0f;

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

    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == 5001)
        {
            player.animationPlayer.Play(GameConstants.ANIM_MOVE);
            SetPhysicsProcess(true);
            SetProcessInput(true);
        }
        else if (what == 5002)
        {
            SetPhysicsProcess(false);
            SetProcessInput(false);
        }
    }
}