using Godot;
using System.Linq;

public partial class EnemyAttackState : EnemyState
{
    private Vector3 targetPosition = Vector3.Zero;

    protected override void EnterState()
    {
        character.AnimationPlayer.Play(GameConstants.ANIM_ATTACK);

        Node3D target = character.attackArea.GetOverlappingBodies().First();

        targetPosition = target.GlobalPosition;

        character.AnimationPlayer.AnimationFinished += HandleAnimationFinished;
    }

    protected override void ExitState()
    {
        character.AnimationPlayer.AnimationFinished -= HandleAnimationFinished;
    }

    private void PerformHit()
    {
        character.ToggleHitbox(false);
        character.Hitbox.GlobalPosition = targetPosition;
    }

    private void HandleAnimationFinished(StringName animationName)
    {
        character.ToggleHitbox(true);

        Node3D target = character.attackArea.GetOverlappingBodies().FirstOrDefault();
        if (target == null)
        {
            Node3D chaseTarget = character.chaseArea.GetOverlappingBodies().FirstOrDefault();
            if (chaseTarget == null)
            {
                character.StateMachine.SwitchState<EnemyReturnState>();
                return;
            }

            character.StateMachine.SwitchState<EnemyChaseState>();
            return;
        }

        character.AnimationPlayer.Play(GameConstants.ANIM_ATTACK);
        targetPosition = target.GlobalPosition;

        Vector3 direction = character.GlobalPosition.DirectionTo(targetPosition);
        character.Sprite3D.FlipH = direction.X < 0.0f;
    }
}