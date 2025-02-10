using UnityEngine;

public class ThornySlimeStateMachine:EnemyStateMachine
{
        public  ThornySlime ThornySlime => (ThornySlime)Enemy;


        public ThornySlimeIdleState ThornySlimeIdleState;
        public ThornySlimeMoveState ThornySlimeMoveState ;
        public ThornySlimeDefendState ThornySlimeDefendState { get; private set; }
        public ThornySlimeHitDefendState ThornySlimeHitDefendState { get; private set; }
        
        public ThornySlimeStateMachine(ThornySlime enemy) : base(enemy)
        {
                ThornySlimeDefendState = new(this);
                ThornySlimeHitDefendState = new(this);

                EnemyIdleState = new ThornySlimeIdleState(this);
                EnemyMoveState = new ThornySlimeMoveState(this);
                ThornySlimeIdleState = (ThornySlimeIdleState)EnemyIdleState;
                ThornySlimeMoveState = (ThornySlimeMoveState)EnemyMoveState;
        }
        
        
        
}