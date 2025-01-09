using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public abstract class PlayerState : IState
{
	protected PlayerStateMachine PlayerStateMachine;
	protected PlayerPropertiesSO playerPropertiesSO;
	
	protected float currentAttack = 0;
	protected float nomalAttackCounter = 0;
	public  PlayerState (PlayerStateMachine playerStateMachine) {
		this.PlayerStateMachine = playerStateMachine;
		this.playerPropertiesSO = playerStateMachine.player.PlayerPropertiesSO;
		
	}
    public virtual void Enter()
    {
		// Debug.Log("State: " + GetType().Name);
		nomalAttackCounter = Time.time;

    }

    public virtual void Exit()
    {
    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void Update()
    {
		Attack();
    }

	//logic
    protected virtual void Move(Vector2 direction, float speed) {
		if (PlayerReusableData.MovementInput == Vector2.zero) return;
		float newAngle = - Camera.main.transform.eulerAngles.y;
		float angleRadians = Mathf.Deg2Rad * newAngle;
        float newX = direction.x * Mathf.Cos(angleRadians) - direction.y * Mathf.Sin(angleRadians);
        float newY = direction.x * Mathf.Sin(angleRadians) + direction.y * Mathf.Cos(angleRadians);
		Vector3 dir = new Vector3(newX, 0, newY);
		PlayerStateMachine.player.transform.rotation = Quaternion.RotateTowards(PlayerStateMachine.player.transform.rotation, Quaternion.LookRotation(dir), 1000 * Time.deltaTime);
		PlayerStateMachine.player.playerRigidbody.velocity = new Vector3(dir.x *speed,PlayerStateMachine.player.playerRigidbody.velocity.y,dir.z * speed);
    }
	protected void ResetVelocity()
	{
		PlayerStateMachine.player.playerRigidbody.velocity = new Vector3(0, 0, 0);
	}
	
	protected void Jump(float force) {
		PlayerStateMachine.player.playerRigidbody.AddForce(PlayerStateMachine.player.transform.up * force, ForceMode.Impulse);
	}

	protected virtual void Attack()
	{
		if (PlayerStateMachine.player.PlayerInputSystem.nomalAttackInput && PlayerReusableData.IsNomalAttacking == false)
		{
			PlayerReusableData.IsNomalAttacking = true;
			PlayerStateMachine.player.PlayerAnimationController.SetFloatValueAnimation(playerPropertiesSO.NomalAttackValueTrigger,currentAttack);
		}
		else if (PlayerReusableData.IsNomalAttacking)
		{
			if (PlayerStateMachine.player.PlayerAnimationController.IsAnimationEnded(
				    "SwordNomalAttack", 1) )
			{
				PlayerReusableData.IsNomalAttacking = false;
				PlayerStateMachine.player.PlayerAnimationController.SetFloatValueAnimation(playerPropertiesSO.NomalAttackValueTrigger,-1);
				nomalAttackCounter = Time.time;
				if (currentAttack == 0)
				{
					currentAttack = 1;
				}
				else
				{
					currentAttack = 0;
				}
			} else if (PlayerStateMachine.player.PlayerAnimationController.IsAnimationEnded(
				           "StaffNomalAttack", 1))
			{
				PlayerReusableData.IsNomalAttacking = false;
				PlayerStateMachine.player.PlayerAnimationController.SetFloatValueAnimation(playerPropertiesSO.NomalAttackValueTrigger,-1);
			} else if (PlayerStateMachine.player.PlayerAnimationController.IsAnimationEnded(
				           "BowNomalAttackEnd", 1))
			{
				PlayerReusableData.IsNomalAttacking = false;
				PlayerStateMachine.player.PlayerAnimationController.SetFloatValueAnimation(playerPropertiesSO.NomalAttackValueTrigger,-1);
			}
		} else if (PlayerReusableData.IsNomalAttacking == false)
		{
			if (Time.time - nomalAttackCounter >= playerPropertiesSO.ResetNomalAttackTime)
			{
				currentAttack = 0;
			}
		}
	}
		
	
	

	//check state
	protected virtual void OnIdle() {
		if(PlayerReusableData.MovementInput == new Vector2(0, 0) && PlayerReusableData.IsGround) {
			
			PlayerStateMachine.ChangeState(PlayerStateMachine.PlayerIdleState);
		}
	}
	protected virtual void OnMove() {
		if(PlayerReusableData.MovementInput != new Vector2(0, 0) && PlayerReusableData.IsGround) {
			PlayerStateMachine.ChangeState(PlayerStateMachine.PlayerMoveState);
		}
	}

	protected virtual void OnDash()
	{
		if (PlayerReusableData.IsGround && PlayerStateMachine.player.PlayerInputSystem.dashInput)
		{
			PlayerStateMachine.ChangeState(PlayerStateMachine.PlayerDashState);
		}
	}




}