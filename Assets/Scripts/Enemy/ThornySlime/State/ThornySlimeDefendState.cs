using UnityEngine;

public class ThornySlimeDefendState:ThornySlimeState
{
    public ThornySlimeDefendState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemyStateMachine.Enemy.EnemyAnimationController.PlayAnimation(thornySlimeStateMachine.ThornySlime.ThornySlimePropertiesSO.DefendAnimationName);
        
        
    }

    public override void Update()
    {
        base.Update();
        OnHitDefend();
        if (thornySlimeStateMachine.ThornySlime.ThornySlimeAI.ShouldDefend == false 
            && enemyStateMachine.Enemy.EnemyAnimationController.IsAnimationEnded(thornySlimeStateMachine.ThornySlime.ThornySlimePropertiesSO.DefendAnimationName,0))
        {
            OnIdle();
        }
    }

    private void OnHitDefend()
    {
        if (enemyStateMachine.Enemy.Damable.IsGetAttack != 0)
        {
            enemyStateMachine.ChangeState(thornySlimeStateMachine.ThornySlimeHitDefendState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        thornySlimeStateMachine.ThornySlime.ThornySlimeAI.ShouldDefend = false;
        thornySlimeStateMachine.ThornySlime.ThornySlimeAI.ResetDefendCounter();
    }
}