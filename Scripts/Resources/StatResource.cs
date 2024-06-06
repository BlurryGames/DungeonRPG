using Godot;

[GlobalClass]
public partial class StatResource : Resource
{
    private float _statValue = 0.0f;

    [Export] public float StatValue
    {
        get => _statValue;
        set
        {
            _statValue = Mathf.Clamp(value, 0.0f, Mathf.Inf);
        }
    }
    [Export] public Stat StatType { get; private set; } = default;
}