using UnityEngine;

public class PlayerDashState: PlayerState
{
    private bool isDashing;
    private Vector2 dashDirection;
    private float dashTime;
    public PlayerDashState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        isDashing = true;
        dashTime = 0;
        dashDirection = PlayerReusableData.MovementInput;
        if(PlayerStateMachine.player.PlayerInputSystem.BackwardInput) {
            PlayerStateMachine.player.PlayerAnimationController.SetFloatValueAnimation(playerPropertiesSO.MoveTrigger,1);
        } else {
            PlayerStateMachine.player.PlayerAnimationController.SetFloatValueAnimation(playerPropertiesSO.MoveTrigger,0);
        }
    }

    public override void Update()
    {
        base.Update();

        if (!isDashing)
        {
            OnIdle();
            OnMove();
        }
    }

    public override void PhysicsUpdate()
    {
        
        base.PhysicsUpdate();
        Dash(PlayerStateMachine.player.PlayerPropertiesSO.BaseDashSpeed);
        dashTime += Time.fixedDeltaTime;
        if (dashTime > PlayerStateMachine.player.PlayerPropertiesSO.BaseDashTime)
        {
            isDashing = false;
            ResetVelocity();
        }

    }
    
    protected virtual void Dash(float speed)
    {
        Vector3 dir = new Vector3();
        if (dashDirection != Vector2.zero)
        {
            float newAngle = - Camera.main.transform.eulerAngles.y;
            float angleRadians = Mathf.Deg2Rad * newAngle;
            float newX = dashDirection.x * Mathf.Cos(angleRadians) - dashDirection.y * Mathf.Sin(angleRadians);
            float newY = dashDirection.x * Mathf.Sin(angleRadians) + dashDirection.y * Mathf.Cos(angleRadians);
            dir = new Vector3(newX, 0, newY);
        }
        else
        {
            dir = PlayerStateMachine.player.transform.forward;
        }
        PlayerStateMachine.player.transform.rotation = Quaternion.RotateTowards(PlayerStateMachine.player.transform.rotation, Quaternion.LookRotation(dir), 1000 * Time.deltaTime);
        PlayerStateMachine.player.playerRigidbody.velocity = new Vector3(dir.x *speed,0,dir.z * speed);
    }

    public override void Exit()
    {
        PlayerStateMachine.player.PlayerAnimationController.SetFloatValueAnimation(playerPropertiesSO.MoveTrigger,-1);
        base.Exit();
    }
}