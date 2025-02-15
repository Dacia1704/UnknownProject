public class PlayerStateMachine: StateMachine
{
	public Player Player { get;private set; }
    public PlayerIdleState PlayerIdleState { get; private set; }
    public PlayerMoveState PlayerMoveState{ get; private set; }
    public PlayerDashState PlayerDashState{ get; private set; }
    public PlayerHitState PlayerHitState{ get; private set; }
    public PlayerDeathState PlayerDeathState{ get; private set; }

    public PlayerStateMachine(Player player) {
		this.Player = player;

		PlayerIdleState = new PlayerIdleState(this);
		PlayerMoveState = new PlayerMoveState(this);
		PlayerDashState = new PlayerDashState(this);
		PlayerHitState = new PlayerHitState(this);
		PlayerDeathState = new PlayerDeathState(this);

    }
}