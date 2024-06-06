using Godot;

public partial class EnemyDeathState : EnemyState
{
    protected override void EnterState()
    {
        character.AnimationPlayer.Play(GameConstants.ANIM_DEATH);

        character.AnimationPlayer.AnimationFinished += HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animationName)
    {
        character.QueueFree();
    }
}