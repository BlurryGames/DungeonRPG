using Godot;
using System;

public partial class PlayerMoveState : Node
{
    public override void _Ready()
    {
        Player player = GetOwner<Player>();
        player.animationPlayer.Play(GameConstants.ANIM_MOVE);
    }
}