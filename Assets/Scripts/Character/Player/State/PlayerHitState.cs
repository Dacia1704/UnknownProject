using Unity.VisualScripting;
using UnityEngine;

public class PlayerHitState: PlayerState
{
    public PlayerHitState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        playerStateMachine.Player.Damable.GetDamage(ref playerStateMachine.Player.PlayerStats.Health,playerStateMachine.Player.Damable.IsGetAttack);
        playerStateMachine.Player.OnHealthDamaged?.Invoke(playerStateMachine.Player.PlayerStats.Health);

        // Debug.Log(playerStateMachine.Player.PlayerStats.Health+" " + playerStateMachine.Player.Damable.IsGetAttack);
        
        if (playerStateMachine.Player.PlayerStats.Health <= 0)
        {
            playerStateMachine.ChangeState(playerStateMachine.PlayerDeathState);
        }
        else
        {
            playerStateMachine.Player.playerAnimationManager.SetBoolValueAnimation(playerPropertiesSO.HitTrigger,true);
        }
        playerStateMachine.Player.Damable.ResetIsGetAttack();
    }

    public override void Update()
    {
        base.Update();
        if (playerStateMachine.Player.playerAnimationManager.IsAnimationEnded(playerPropertiesSO.HitAnimationName, 1))
        {
            OnDash();
            OnMove();
            OnIdle();
        }
    }

    public override void Exit()
    {
        base.Exit();
        playerStateMachine.Player.playerAnimationManager.SetBoolValueAnimation(playerPropertiesSO.HitTrigger,false);
        hitCounter = playerPropertiesSO.BaseStats.HitCooldown;
    }
}