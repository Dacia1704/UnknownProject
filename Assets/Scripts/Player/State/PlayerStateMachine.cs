public class PlayerStateMachine: StateMachine {
    public Player player { get; private set; }
    public PlayerIdleState PlayerIdleState { get; private set; }
    public PlayerMoveState PlayerMoveState{ get; private set; }
    public PlayerDashState PlayerDashState{ get; private set; }

    public PlayerStateMachine(Player player) {
		this.player = player;

		PlayerIdleState = new PlayerIdleState(this);
		PlayerMoveState = new PlayerMoveState(this);
		PlayerDashState = new PlayerDashState(this);
		
    }
}