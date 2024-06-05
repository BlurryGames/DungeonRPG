using Godot;

public abstract partial class Character : CharacterBody3D
{
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimationPlayer { get; private set; } = null;
    [Export] public Sprite3D Sprite3D { get; private set; } = null;
    [Export] public StateMachine StateMachine { get; private set; } = null;

    [ExportGroup("AI Nodes")]
    [Export] public Path3D path { get; private set; } = null;

    public Vector2 Direction { get; protected set; } = Vector2.Zero;

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
}