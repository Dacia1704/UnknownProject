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
        AudioManager.Instance.PlayPlayerHitAudio(playerStateMachine.Player.PlayerAudioSource);
        playerStateMachine.Player.IsNomalAttacking = false;
        playerStateMachine.Player.playerAnimationManager.SetFloatValueAnimation(playerPropertiesSO.NomalAttackValueTrigger,-1);
        playerStateMachine.Player.Damable.GetDamage(ref playerStateMachine.Player.PlayerStats.Health,playerStateMachine.Player.Damable.AttackableStats.Attack);
        playerStateMachine.Player.InvokeOnDebuffEffect(playerStateMachine.Player.Damable.RandomDebuffEffect());
        PLayHitEffect();
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
        ResetVelocity();
    }

    public override void Update()
    {
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
        playerStateMachine.HitCounter = playerPropertiesSO.BaseStats.HitCooldown;
    }

    private void PLayHitEffect()
    {
        CinemachineEffect.Instance.ShakeCamera(2f,0.1f);
        GameManager.Instance.TriggerSlowMotion(0.2f,0.1f);
        OverlayScreen.Instance.ShowLowHealthOverlayScreenByTime(0.1f);
    }
}