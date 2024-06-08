using Godot;

public partial class EnemyStunState : EnemyState
{
    protected override void EnterState()
    {
        base.EnterState();

        character.AnimationPlayer.Play(GameConstants.ANIM_STUN);
        character.AnimationPlayer.AnimationFinished += HandleAnimationFinished;
    }

    protected override void ExitState()
    {
        character.AnimationPlayer.AnimationFinished -= HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animationName)
    {
        if (character.attackArea.HasOverlappingBodies())
        {
            character.StateMachine.SwitchState<EnemyAttackState>();
        }
        else if (character.chaseArea.HasOverlappingBodies())
        {
            character.StateMachine.SwitchState<EnemyChaseState>();
        }
        else
        {
            character.StateMachine.SwitchState<EnemyIdleState>();
        }
    }
}