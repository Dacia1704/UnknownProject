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
        GameManager.instance.FloatingTextUIObjectPooling.ShowFloatingHP(enemyStateMachine.Enemy.transform,"- " + enemyStateMachine.Enemy.Damable.AttackableStats.Attack.ToString()
            ,enemyStateMachine.Enemy.transform.position,Color.red);
        
        enemyStateMachine.Enemy.InvokeOnDebuffEffect(enemyStateMachine.Enemy.Damable.RandomDebuffEffect());
        enemyStateMachine.Enemy.OnHealthDamaged.Invoke(enemyStateMachine.Enemy.EnemyStats.Health);

        if (enemyStateMachine.Enemy.EnemyStats.Health <= 0)
        {
            enemyStateMachine.ChangeState(enemyStateMachine.EnemyDeathState);
        }
        else
        {
            enemyStateMachine.Enemy.EnemyAnimationManager.PlayAnimation(enemyStateMachine.Enemy.EnemyPropertiesSO.HitAnimationName);
        }
        
        enemyStateMachine.Enemy.Damable.ResetAttackableStats();
        
    }
    
    public override void Update()
    {
        base.Update();

        if (enemyStateMachine.Enemy.Damable.AttackableStats.Attack == 0 && enemyStateMachine.Enemy.EnemyAnimationManager.IsAnimationEnded(enemyStateMachine.Enemy.EnemyPropertiesSO.HitAnimationName,0))
        {
            OnAttack();
            OnMove();
            OnIdle();
        }
    }

}