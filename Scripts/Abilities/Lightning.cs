using Godot;

public partial class Lightning : Ability
{
    public override void _Ready()
    {
        animationPlayer.AnimationFinished += name => QueueFree();
    }
}