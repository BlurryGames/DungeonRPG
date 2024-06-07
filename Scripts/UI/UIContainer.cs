using Godot;

public partial class UIContainer : VBoxContainer
{
    [Export] public ContainerType Container { get; private set; } = default;
    [Export] public Button ButtonNode { get; private set; } = null;
}