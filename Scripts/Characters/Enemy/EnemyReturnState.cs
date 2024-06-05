using Godot;

public partial class EnemyReturnState : EnemyState
{
    private Vector3 destination = Vector3.Zero;

    public override void _Ready()
    {
        base._Ready();

        Vector3 localPosition = character.path.Curve.GetPointPosition(0);
        Vector3 globalPosition = character.path.GlobalPosition;
        destination = localPosition + globalPosition;
    }

    protected override void EnterState()
    {
        character.AnimationPlayer.Play(GameConstants.ANIM_MOVE);

        character.GlobalPosition = destination;
    }
}