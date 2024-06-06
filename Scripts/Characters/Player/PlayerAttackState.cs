using Godot;

public partial class PlayerAttackState : PlayerState
{
    private int comboCounter = 1;
    private int maxComboCount = 2;

    protected override void EnterState()
    {
        character.AnimationPlayer.Play(GameConstants.ANIM_ATTACK + comboCounter.ToString());

        character.AnimationPlayer.AnimationFinished += HandleAnimationFinished;
    }

    protected override void ExitState()
    {
        character.AnimationPlayer.AnimationFinished -= HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animationName)
    {
        comboCounter = Mathf.Wrap(comboCounter + 1, 1, maxComboCount + 1);

        character.StateMachine.SwitchState<PlayerIdleState>();
    }
}