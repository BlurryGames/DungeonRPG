using Godot;

public partial class EnemyPatrolState : EnemyState
{
    public override void _PhysicsProcess(double delta)
    {
        Move();
    }

    protected override void EnterState()
    {
        character.AnimationPlayer.Play(GameConstants.ANIM_MOVE);

        destination = GetPointGlobalPosition(1);
        character.Agent.TargetPosition = destination;
    }
}