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

        character.ToggleHitbox(true);

        character.StateMachine.SwitchState<PlayerIdleState>();
    }

    private void PerformHit()
    {
        Vector3 newPosition = character.Sprite3D.FlipH ? Vector3.Left : Vector3.Right;

        float distanceMultiplier = 0.75f;
        newPosition *= distanceMultiplier;

        character.Hitbox.Position = newPosition;

        character.ToggleHitbox(false);
    }
}