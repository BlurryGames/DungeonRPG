using Godot;

public abstract partial class Ability : Node3D
{
    [Export] public float Damage { get; private set; } = 10.0f;
    [Export] protected AnimationPlayer animationPlayer = null;
}