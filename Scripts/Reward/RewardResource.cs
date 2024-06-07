using Godot;

[GlobalClass]
public partial class RewardResource : Resource
{
    [Export] public Texture2D SpriteTexture { get; private set; } = null;

    [Export] public string Description { get; private set; } = null;

    [Export(PropertyHint.Range, "1.0f, 100.0f, 1.0f")] public float Amount { get; private set; } = 0.0f;

    [Export] public Stat targetStat { get; private set; } = default;
}