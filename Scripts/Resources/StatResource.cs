using Godot;

[GlobalClass]
public partial class StatResource : Resource
{
    [Export] public Stat StatType { get; private set; } = default;
    [Export] public float StatValue { get; private set; } = 0.0f;
}