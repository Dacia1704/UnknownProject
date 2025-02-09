public class ThornySlimeStateMachine:EnemyStateMachine
{
        public ThornySlimeDefendState ThornySlimeDefendState { get; private set; }
        public ThornySlimeHitDefendState ThornySlimeHitDefendState { get; private set; }
        
        public ThornySlimeStateMachine(Enemy enemy) : base(enemy)
        {
                ThornySlimeDefendState = new(this);
                ThornySlimeHitDefendState = new(this);
        }
        
}