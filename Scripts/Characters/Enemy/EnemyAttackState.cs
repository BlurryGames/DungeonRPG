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
    }

    private void PerformHit()
    {
        character.ToggleHitbox(false);
        character.Hitbox.GlobalPosition = targetPosition;
    }
}