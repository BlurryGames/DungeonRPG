using Godot;

public partial class UIContainer : Container
{
    [Export] public ContainerType Container { get; private set; } = default;
    [Export] public Button ButtonNode { get; private set; } = null;
    [Export] public TextureRect TextureIcon { get; private set; } = null;
    [Export] public Label TextLabel { get; private set; } = null;
}