using Godot;

public partial class EnemyReturnState : EnemyState
{
    public override void _Ready()
    {
        base._Ready();

        destination = GetPointGlobalPosition(0);
    }

    public override void _PhysicsProcess(double delta)
    {
        if (character.Agent.IsNavigationFinished())
        {
            character.StateMachine.SwitchState<EnemyPatrolState>();
            return;
        }

        Move();
    }

    protected override void EnterState()
    {
        character.AnimationPlayer.Play(GameConstants.ANIM_MOVE);

        character.Agent.TargetPosition = destination;
    }
}