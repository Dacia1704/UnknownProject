using UnityEngine;

public class ThornySlimeIdleState:EnemyIdleState
{
    protected ThornySlimeStateMachine thornySlimeStateMachine => (ThornySlimeStateMachine)enemyStateMachine;
    public ThornySlimeIdleState(EnemyStateMachine enemyStateMachine) : base(enemyStateMachine)
    {
    }

    public override void Update()
    {
        base.Update();
        OnDefend();
    }


    public virtual void OnDefend()
    {
        if (thornySlimeStateMachine.ThornySlime.ThornySlimeAI.ShouldDefend)
        {
            thornySlimeStateMachine.ChangeState(thornySlimeStateMachine.ThornySlimeDefendState);
        }
    }
}