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

    protected override void Start()
    {
        Player = GameManager.instance.Player;
        
        Rigidbody= GetComponent<Rigidbody>();
        Attackable = GetComponentInChildren<Attackable>();
        Damable = GetComponentInChildren<Damable>();
        EnemyAI = GetComponentInChildren<EnemyAI>();
        EnemyAnimationController = GetComponentInChildren<EnemyAnimationController>();
        EnemyCollisionManager = GetComponentInChildren<EnemyCollisionManager>();
        
        thornySlimeStateMachine.ChangeState(thornySlimeStateMachine.ThornySlimeIdleState);
        enemyStateMachine.Enemy.Damable.transform.gameObject.SetActive(true);
        enemyStateMachine.Enemy.Attackable.transform.gameObject.SetActive(true);
        
        Damable.SetDamableLayer(EnemyPropertiesSO.DamableLayers);

        EnemyStats = new EnemyStats(EnemyPropertiesSO.BaseStats);
        Damable.DamableStats = new EnemyStats(EnemyStats);
        Attackable.SetAttackStats(EnemyStats);
    }
}