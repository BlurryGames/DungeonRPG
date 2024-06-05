using Godot;

public partial class EnemyChaseState : EnemyState
{
    protected override void EnterState()
    {
        character.AnimationPlayer.Play(GameConstants.ANIM_MOVE);
        GD.Print("Chase state");
    }
}