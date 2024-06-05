using Godot;

public partial class EnemyPatrolState : EnemyState
{
    private int pointIndex = 0;

    public override void _PhysicsProcess(double delta)
    {
        Move();
    }

    protected override void EnterState()
    {
        character.AnimationPlayer.Play(GameConstants.ANIM_MOVE);

        pointIndex = 1;

        destination = GetPointGlobalPosition(pointIndex);
        character.Agent.TargetPosition = destination;

        character.Agent.NavigationFinished += HandleNavigationFinished;
    }

    private void HandleNavigationFinished()
    {
        pointIndex = Mathf.Wrap(pointIndex + 1, 0, character.Path.Curve.PointCount - 1);

        destination = GetPointGlobalPosition(pointIndex);
        character.Agent.TargetPosition = destination;
    }
}