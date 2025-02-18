using UnityEngine;

public class PlayerDeathState: PlayerState
{
    public PlayerDeathState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        
        playerStateMachine.Player.playerAnimationManager.SetBoolValueAnimation(playerPropertiesSO.DeathTrigger,true);
    }
}