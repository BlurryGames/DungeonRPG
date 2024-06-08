using Godot;

public partial class Enemy : Character
{
    public override void _Ready()
    {
        base._Ready();

        Hurtbox.AreaEntered += HandleAreaEntered;
    }

    private void HandleAreaEntered(Area3D area)
    {
        if (area is not IHitbox h)
        {
            return;
        }

        if (h.CanStun() && GetStatResource(Stat.Health).StatValue != 0.0f)
        {
            StateMachine.SwitchState<EnemyStunState>();
        }
    }
}