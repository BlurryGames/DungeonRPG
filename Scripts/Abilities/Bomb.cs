using Godot;

public partial class Bomb : Ability
{
    public override void _Ready()
    {
        animationPlayer.AnimationFinished += HandleExpandAnimationFinished;
    }

    private void HandleExpandAnimationFinished(StringName animationName)
    {
        if (animationName == GameConstants.ANIM_EXPAND)
        {
            animationPlayer.Play(GameConstants.ANIM_EXPLOSION);
        }
        else
        {
            QueueFree();
        }
    }
}