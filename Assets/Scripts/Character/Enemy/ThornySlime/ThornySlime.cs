using UnityEngine;

public class ThornySlime : Enemy
{
    public ThornySlimePropertiesSO ThornySlimePropertiesSO => (ThornySlimePropertiesSO)EnemyPropertiesSO;

    public ThornySlimeAI ThornySlimeAI => (ThornySlimeAI)EnemyAI;

    private ThornySlimeStateMachine thornySlimeStateMachine;

    protected override void Awake()
    {
        enemyStateMachine = new ThornySlimeStateMachine(this);
        thornySlimeStateMachine = (ThornySlimeStateMachine)enemyStateMachine;
    }

    protected override void SetUpState()
    {
        thornySlimeStateMachine.ChangeState(thornySlimeStateMachine.ThornySlimeIdleState);
    }
}