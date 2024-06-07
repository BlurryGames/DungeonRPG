using Godot;

public partial class PlayerDeathState : PlayerState
{
    protected override void EnterState()
    {
        character.AnimationPlayer.Play(GameConstants.ANIM_DEATH);

        character.AnimationPlayer.AnimationFinished += HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animationName)
    {
        GameEvents.RaiseEndGame();

        character.QueueFree();
    }
}