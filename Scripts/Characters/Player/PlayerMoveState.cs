using Godot;
using System;
using static Godot.TextServer;

public partial class PlayerMoveState : PlayerState
{
    [Export(PropertyHint.Range, "0.0f, 20.0f, 0.1f")] private float speed = 5.0f;

    public override void _PhysicsProcess(double delta)
    {
        if (character.Direction == Vector2.Zero)
        {
            character.StateMachine.SwitchState<PlayerIdleState>();
            return;
        }

        character.Velocity = new Vector3(character.Direction.X, 0.0f, character.Direction.Y);
        character.Velocity *= speed;

        character.MoveAndSlide();

        character.Flip();
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_DASH))
        {
            character.StateMachine.SwitchState<PlayerDashState>();
        }
    }

    protected override void EnterState()
    {
        base.EnterState();

        character.AnimationPlayer.Play(GameConstants.ANIM_MOVE);
    }
}