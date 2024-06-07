using Godot;

public partial class Camera : Camera3D
{
    [Export] private Node target = null;

    [Export] private Vector3 positionFromTarget = Vector3.Zero;

    public override void _Ready()
    {
        GameEvents.OnStartGame += HandleStartGame;
        GameEvents.OnEndGame += HandleEndGame;
    }

    private void HandleStartGame()
    {
        Reparent(target);

        Position = positionFromTarget;
    }

    private void HandleEndGame()
    {
        Reparent(GetTree().CurrentScene);
    }
}