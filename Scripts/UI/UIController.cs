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

        GameEvents.OnEndGame += HandleEndGame;
        GameEvents.OnVictory += HandleVictory;
    }

    private void HandleStartPressed()
    {
        GetTree().Paused = false;

        containers[ContainerType.Start].Visible = false;
        containers[ContainerType.Stats].Visible = true;

        GameEvents.RaiseStartGame();
    }

    private void HandleEndGame()
    {
        containers[ContainerType.Stats].Visible = false;
        containers[ContainerType.Defeat].Visible = true;
    }

    private void HandleVictory()
    {
        containers[ContainerType.Stats].Visible = false;
        containers[ContainerType.Victory].Visible = true;

        GetTree().Paused = true;
    }
}