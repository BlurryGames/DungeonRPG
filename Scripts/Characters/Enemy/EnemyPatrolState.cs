using Godot;

public partial class EnemyPatrolState : EnemyState
{
    [Export] private Timer idleTimer = null;

    [Export(PropertyHint.Range, "0.0f, 20.0f, 0.01f")] private float maxIdleTime = 4.0f;

    private int pointIndex = 0;

    public override void _PhysicsProcess(double delta)
    {
        if (!idleTimer.IsStopped())
        {
            return;
        }

        Move();
    }

    protected override void EnterState()
    {
        character.AnimationPlayer.Play(GameConstants.ANIM_MOVE);

        pointIndex = 1;

        destination = GetPointGlobalPosition(pointIndex);
        character.Agent.TargetPosition = destination;

        character.Agent.NavigationFinished += HandleNavigationFinished;
        idleTimer.Timeout += HandleTimeout;
    }

    private void HandleNavigationFinished()
    {
        character.AnimationPlayer.Play(GameConstants.ANIM_IDLE);

        RandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();
        idleTimer.WaitTime = randomNumberGenerator.RandfRange(0.0f, maxIdleTime);

        idleTimer.Start();
    }

    private void HandleTimeout()
    {
        character.AnimationPlayer.Play(GameConstants.ANIM_MOVE);

        pointIndex = Mathf.Wrap(pointIndex + 1, 0, character.Path.Curve.PointCount - 1);

        destination = GetPointGlobalPosition(pointIndex);
        character.Agent.TargetPosition = destination;
    }
}