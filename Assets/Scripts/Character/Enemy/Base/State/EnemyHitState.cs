using UnityEngine;

public class EnemyHitState: EnemyState
{
    public EnemyHitState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemyStateMachine.Enemy.Damable.GetDamage(ref enemyStateMachine.Enemy.EnemyStats.Health,enemyStateMachine.Enemy.Damable.AttackableStats.Attack);
        enemyStateMachine.Enemy.InvokeOnDebuffEffect(enemyStateMachine.Enemy.Damable.RandomDebuffEffect());
        PlayHitEffect();
        GameManager.Instance.FloatingTextUIObjectPooling.ShowFloatingHP(enemyStateMachine.Enemy.transform,"- " + enemyStateMachine.Enemy.Damable.AttackableStats.Attack.ToString()
            ,enemyStateMachine.Enemy.transform.position,Color.red);
        enemyStateMachine.Enemy.Damable.ResetAttackableStats();
        
        enemyStateMachine.Enemy.OnHealthDamaged.Invoke(enemyStateMachine.Enemy.EnemyStats.Health);

        if (enemyStateMachine.Enemy.EnemyStats.Health <= 0)
        {
            enemyStateMachine.ChangeState(enemyStateMachine.EnemyDeathState);
        }
        else
        {
            enemyStateMachine.Enemy.EnemyAnimationManager.PlayAnimation(enemyStateMachine.Enemy.EnemyPropertiesSO.HitAnimationName);
        }
        
        
    }
    
    public override void Update()
    {
        base.Update();
        OnHit();
        OnAttack();
        OnMove();
        OnIdle();
    }


    private void PlayHitEffect()
    {
        CinemachineEffect.Instance.ShakeCamera(1.5f,0.1f);
        GameManager.Instance.TriggerSlowMotion(0.2f,0.05f);
    }

}