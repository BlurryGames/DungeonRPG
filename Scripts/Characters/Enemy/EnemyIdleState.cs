using Godot;
using System;

public partial class EnemyIdleState : EnemyState
{
    public override void _PhysicsProcess(double delta)
    {
        character.StateMachine.SwitchState<EnemyReturnState>();
    }

    protected override void EnterState()
    {
        character.AnimationPlayer.Play(GameConstants.ANIM_IDLE);
    }
}