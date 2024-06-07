using Godot;
using System;

[GlobalClass]
public partial class StatResource : Resource
{
    public event Action OnZero = null;
    public event Action OnUpdate = null;

    private float _statValue = 0.0f;

    [Export] public float StatValue
    {
        get => _statValue;
        set
        {
            _statValue = Mathf.Clamp(value, 0.0f, Mathf.Inf);

            OnUpdate?.Invoke();

            if (_statValue == 0.0f)
            {
                OnZero?.Invoke();
            }
        }
    }
    [Export] public Stat StatType { get; private set; } = default;
}