using Godot;

public partial class TreasureChest : StaticBody3D
{
    [Export] private Area3D area = null;
    [Export] private Sprite3D sprite = null;
    [Export] private RewardResource reward = null;

    public override void _Ready()
    {
        area.BodyEntered += b => sprite.Visible = true;
        area.BodyExited += b => sprite.Visible = false;
    }

    public override void _Input(InputEvent @event)
    {
        if (!area.Monitoring ||
            !area.HasOverlappingBodies() ||
            !Input.IsActionJustPressed(GameConstants.INPUT_INTERACT))
        {
            return;
        }

        area.Monitoring = false;

        GameEvents.RaiseReward(reward);
    }
}