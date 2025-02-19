using UnityEngine;

public class ThornySlimeDefendState:ThornySlimeState
{
    public ThornySlimeDefendState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemyStateMachine.Enemy.EnemyAnimationManager.PlayAnimation(thornySlimeStateMachine.ThornySlime.ThornySlimePropertiesSO.DefendAnimationName);
        
        
    }

    public override void Update()
    {
        base.Update();
        OnHitDefend();
        if (enemyStateMachine.Enemy.EnemyAnimationManager.IsAnimationEnded(thornySlimeStateMachine.ThornySlime.ThornySlimePropertiesSO.DefendAnimationName,0))
        {
            thornySlimeStateMachine.ThornySlime.ThornySlimeAI.ShouldDefend = false;
            OnIdle();
        }
    }

    private void OnHitDefend()
    {
        if (enemyStateMachine.Enemy.Damable.AttackableStats.Attack != 0)
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