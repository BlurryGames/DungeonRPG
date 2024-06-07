using Godot;

public partial class StatsLabel : Label
{
    [Export] private StatResource statResource = null;

    public override void _Ready()
    {
        statResource.OnUpdate += HandleUpdate;

        Text = statResource.StatValue.ToString();
    }

    private void HandleUpdate()
    {
        Text = statResource.StatValue.ToString();
    }
}