using Godot;

public abstract partial class EnemyState : CharacterState
{
    protected Vector3 destination = Vector3.Zero;

    public override void _Ready()
    {
        base._Ready();

        character.GetStatResource(Stat.Health).OnZero += HandleZeroHealth;
    }

    protected Vector3 GetPointGlobalPosition(int index)
    {
        Vector3 localPosition = character.Path.Curve.GetPointPosition(index);
        Vector3 globalPosition = character.Path.GlobalPosition;
        return localPosition + globalPosition;
    }

    protected void Move()
    {
        character.Agent.GetNextPathPosition();
        character.Velocity = character.GlobalPosition.DirectionTo(destination);

        character.MoveAndSlide();
        character.Flip();
    }

    protected void HandleChaseAreaBodyEntered(Node3D body)
    {
        character.StateMachine.SwitchState<EnemyChaseState>();
    }

    private void HandleZeroHealth()
    {
        character.StateMachine.SwitchState<EnemyDeathState>();
    }
}