using Godot;
using System;

public partial class PlayerDashState : Node
{
    private Player player = null;

    public override void _Ready()
    {
        player = GetOwner<Player>();
        SetPhysicsProcess(false);
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == 5001)
        {
            player.animationPlayer.Play(GameConstants.ANIM_DASH);
            SetPhysicsProcess(true);
        }
        else if (what == 5002)
        {
            SetPhysicsProcess(false);
        }
    }
}
