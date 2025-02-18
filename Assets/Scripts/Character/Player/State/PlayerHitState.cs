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
        playerStateMachine.Player.IsNomalAttacking = false;
        playerStateMachine.Player.playerAnimationManager.SetFloatValueAnimation(playerPropertiesSO.NomalAttackValueTrigger,-1);
        playerStateMachine.Player.Damable.GetDamage(ref playerStateMachine.Player.PlayerStats.Health,playerStateMachine.Player.Damable.AttackableStats.Attack);
        playerStateMachine.Player.OnHealthDamaged?.Invoke(playerStateMachine.Player.PlayerStats.Health);
        if (playerStateMachine.Player.PlayerStats.Health <= 0)
        {
            playerStateMachine.ChangeState(playerStateMachine.PlayerDeathState);
        }
        else
        {
            playerStateMachine.Player.playerAnimationManager.SetBoolValueAnimation(playerPropertiesSO.HitTrigger,true);
        }
        playerStateMachine.Player.Damable.ResetAttackableStats();
    }

    public override void Update()
    {
        if (playerStateMachine.Player.playerAnimationManager.IsAnimationEnded(playerPropertiesSO.HitAnimationName, 1))
        {
            Debug.Log("Can leave hit State");
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