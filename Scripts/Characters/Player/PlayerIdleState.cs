using Godot;
using System;

public partial class PlayerIdleState : Node
{
    public override void _Ready()
    {
        
    }

    public override void _Notification(int what)
    {
        base._Notification(what);
        if (what == 5001)
        {
            Player player = GetOwner<Player>();
            player.animationPlayer.Play(GameConstants.ANIM_IDLE);
        }
    }
}