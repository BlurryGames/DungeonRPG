using Godot;
using System.Linq;

public abstract partial class Character : CharacterBody3D
{
    [Export] private StatResource[] stats = null;

    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimationPlayer { get; private set; } = null;
    [Export] public Sprite3D Sprite3D { get; private set; } = null;
    [Export] public StateMachine StateMachine { get; private set; } = null;
    [Export] public Area3D Hurtbox { get; private set; } = null;

    [ExportGroup("AI Nodes")]
    [Export] public Path3D Path { get; private set; } = null;
    [Export] public NavigationAgent3D Agent { get; private set; } = null;
    [Export] public Area3D chaseArea { get; private set; } = null;
    [Export] public Area3D attackArea { get; private set; } = null;

    public Vector2 Direction { get; protected set; } = Vector2.Zero;

    public override void _Ready()
    {
        Hurtbox.AreaEntered += HandleHurtboxEntered;
    }

    public StatResource GetStatResource(Stat stat)
    {
        StatResource result = stats.FirstOrDefault(s => s.StatType == stat);

        return result;
    }

    public void Flip()
    {
        bool isNotMovingHorizontally = Velocity.X == 0.0f;
        if (isNotMovingHorizontally)
        {
            return;
        }

        bool isMovingLeft = Velocity.X < 0.0f;
        Sprite3D.FlipH = isMovingLeft;
    }

    private void HandleHurtboxEntered(Area3D area)
    {
        StatResource health = GetStatResource(Stat.Health);

        Character player = area.GetOwner<Character>();
        health.StatValue -= player.GetStatResource(Stat.Strength).StatValue;

        GD.Print(health.StatValue);
    }
}