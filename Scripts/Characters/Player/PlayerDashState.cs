using Godot;
using System;

public partial class PlayerDashState : Node
{
    [Export] private Timer timer = null;

    private Player player = null;

    public override void _Ready()
    {
        player = GetOwner<Player>();
        timer.Timeout += HandleDashTimeout;
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == 5001)
        {
            player.animationPlayer.Play(GameConstants.ANIM_DASH);
            timer.Start();
        }
    }

    private void HandleDashTimeout()
    {
        player.stateMachine.SwitchState<PlayerIdleState>();
    }
}
