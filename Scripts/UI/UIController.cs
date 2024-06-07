using Godot;
using System.Collections.Generic;
using System.Linq;

public partial class UIController : Control
{
    private Dictionary<ContainerType, UIContainer> containers = null;

    public override void _Ready()
    {
        containers = GetChildren().Where(e => e is UIContainer).Cast<UIContainer>().ToDictionary(e => e.Container);

        containers[ContainerType.Start].Visible = true;

        containers[ContainerType.Start].ButtonNode.Pressed += HandleStartPressed;
    }

    private void HandleStartPressed()
    {
        GetTree().Paused = false;

        containers[ContainerType.Start].Visible = false;

        GameEvents.RaiseStartGame();
    }
}