using UnityEngine;

public class ThornySlimeHitDefendState:ThornySlimeState
{
    public ThornySlimeHitDefendState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemyStateMachine.Enemy.EnemyAnimationManager.PlayAnimation(thornySlimeStateMachine.ThornySlime.ThornySlimePropertiesSO.HitDefendAnimationName);
        thornySlimeStateMachine.ThornySlime.Damable.ResetAttackableStats();
    }

    public override void Update()
    {
        base.Update();
        if(enemyStateMachine.Enemy.EnemyAnimationManager.IsAnimationEnded(thornySlimeStateMachine.ThornySlime.ThornySlimePropertiesSO.HitDefendAnimationName,0))
        {
            OnDefend();
        }
    }
    
    public override void OnDefend()
    {
        thornySlimeStateMachine.ChangeState(thornySlimeStateMachine.ThornySlimeDefendState);
    }
}