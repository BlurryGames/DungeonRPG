using Godot;
using System.Linq;

public partial class EnemyChaseState : EnemyState
{
    [Export] private Timer timer = null;

    private CharacterBody3D target = null;

    public override void _PhysicsProcess(double delta)
    {
        Move();
    }

    protected override void EnterState()
    {
        character.AnimationPlayer.Play(GameConstants.ANIM_MOVE);
        target = character.chaseArea.GetOverlappingBodies().First() as CharacterBody3D;

        timer.Timeout += HandleTimeout;
        character.attackArea.BodyEntered += HandleAttackAreaBodyEntered;
        character.chaseArea.BodyExited += HandleChaseAreaBodyExited;
    }

    protected override void ExitState()
    {
        timer.Timeout -= HandleTimeout;
        character.attackArea.BodyEntered -= HandleAttackAreaBodyEntered;
        character.chaseArea.BodyExited -= HandleChaseAreaBodyExited;
    }

    private void HandleAttackAreaBodyEntered(Node3D body)
    {
        character.StateMachine.SwitchState<EnemyAttackState>();
    }

    private void HandleChaseAreaBodyExited(Node3D body)
    {
        character.StateMachine.SwitchState<EnemyReturnState>();
    }

    private void HandleTimeout()
    {
        destination = target.GlobalPosition;
        character.Agent.TargetPosition = destination;
    }
}