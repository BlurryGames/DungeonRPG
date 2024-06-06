using Godot;

public partial class PlayerAttackState : PlayerState
{
    [Export] private Timer comboTimer = null;

    private int comboCounter = 1;
    private int maxComboCount = 2;

    public override void _Ready()
    {
        base._Ready();

        comboTimer.Timeout += () => comboCounter = 1;
    }

    protected override void EnterState()
    {
        character.AnimationPlayer.Play(GameConstants.ANIM_ATTACK + comboCounter.ToString(), -1.0, 1.5f);

        character.AnimationPlayer.AnimationFinished += HandleAnimationFinished;
    }

    protected override void ExitState()
    {
        character.AnimationPlayer.AnimationFinished -= HandleAnimationFinished;

        comboTimer.Start();
    }

    private void HandleAnimationFinished(StringName animationName)
    {
        comboCounter = Mathf.Wrap(comboCounter + 1, 1, maxComboCount + 1);

        character.StateMachine.SwitchState<PlayerIdleState>();
    }

    private void PerformHit()
    {
        GD.Print("Perform hit!");
    }
}