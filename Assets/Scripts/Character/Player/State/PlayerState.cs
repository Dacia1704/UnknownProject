using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public abstract class PlayerState : IState
{
	protected PlayerStateMachine playerStateMachine;
	protected PlayerPropertiesSO playerPropertiesSO;
	
	protected float currentAttack = 0;
	protected float nomalAttackCounter = 0;
	public  PlayerState (PlayerStateMachine playerStateMachine) {
		this.playerStateMachine = playerStateMachine;
		this.playerPropertiesSO = playerStateMachine.Player.PlayerPropertiesSO;
		
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
    protected virtual void Move(Vector2 direction, float speed,bool backward= false) {
		if (PlayerReusableData.MovementInput == Vector2.zero) return;
		float newAngle = - Camera.main.transform.eulerAngles.y;
		float angleRadians = Mathf.Deg2Rad * newAngle;
        float newX = direction.x * Mathf.Cos(angleRadians) - direction.y * Mathf.Sin(angleRadians);
        float newY = direction.x * Mathf.Sin(angleRadians) + direction.y * Mathf.Cos(angleRadians);
		Vector3 dir = new Vector3(newX, 0, newY);
		playerStateMachine.Player.transform.rotation = Quaternion.RotateTowards(playerStateMachine.Player.transform.rotation, Quaternion.LookRotation(dir), 1000 * Time.deltaTime);
		if (backward) {
			playerStateMachine.Player.Rigidbody.velocity = new Vector3(-1 *dir.x *speed,playerStateMachine.Player.Rigidbody.velocity.y,-1*dir.z * speed);
		} else {
			playerStateMachine.Player.Rigidbody.velocity = new Vector3(dir.x *speed,playerStateMachine.Player.Rigidbody.velocity.y,dir.z * speed);
		}
    }
	protected void ResetVelocity()
	{
		playerStateMachine.Player.Rigidbody.velocity = new Vector3(0, 0, 0);
	}

	protected virtual void Attack()
	{
		if (playerStateMachine.Player.PlayerInputSystem.NomalAttackInput && PlayerReusableData.IsNomalAttacking == false)
		{
			PlayerReusableData.IsNomalAttacking = true;
			playerStateMachine.Player.PlayerAnimationController.SetFloatValueAnimation(playerPropertiesSO.NomalAttackValueTrigger,currentAttack);

			if (PlayerReusableData.MovementInput == new Vector2(0, 0))
			{
				TurnPlayerToNearestEnemy();
			}
		}
		else if (PlayerReusableData.IsNomalAttacking)
		{
			if (playerStateMachine.Player.PlayerAnimationController.IsAnimationEnded(
				    "SwordNomalAttack", 1) )
			{
				PlayerReusableData.IsNomalAttacking = false;
				playerStateMachine.Player.PlayerAnimationController.SetFloatValueAnimation(playerPropertiesSO.NomalAttackValueTrigger,-1);
				nomalAttackCounter = Time.time;
				if (currentAttack == 0)
				{
					currentAttack = 1;
				}
				else
				{
					currentAttack = 0;
				}
			} else if (playerStateMachine.Player.PlayerAnimationController.IsAnimationEnded(
				           "StaffNomalAttack", 1))
			{
				PlayerReusableData.IsNomalAttacking = false;
				playerStateMachine.Player.PlayerAnimationController.SetFloatValueAnimation(playerPropertiesSO.NomalAttackValueTrigger,-1);
			} else if (playerStateMachine.Player.PlayerAnimationController.IsAnimationEnded(
				           "BowNomalAttack", 1))
			{
				PlayerReusableData.IsNomalAttacking = false;
				playerStateMachine.Player.PlayerAnimationController.SetFloatValueAnimation(playerPropertiesSO.NomalAttackValueTrigger,-1);
			} else if (playerStateMachine.Player.PlayerAnimationController.IsAnimationEnded(
				           "FighterNomalAttack", 1))
			{
				PlayerReusableData.IsNomalAttacking = false;
				playerStateMachine.Player.PlayerAnimationController.SetFloatValueAnimation(playerPropertiesSO.NomalAttackValueTrigger,-1);
				nomalAttackCounter = Time.time;
				if (currentAttack == 0)
				{
					currentAttack = 1;
				}
				else
				{
					currentAttack = 0;
				}
			} 
		} else if (PlayerReusableData.IsNomalAttacking == false)
		{
			if (Time.time - nomalAttackCounter >= playerPropertiesSO.BaseStats.ResetNomalAttackTime)
			{
				currentAttack = 0;
			}
		}
	}


	protected void TurnPlayerToNearestEnemy()
	{
		Enemy nearestEnemy = GetNearestEnemy();
		TurnPlayer(nearestEnemy.transform.position);
	}
	protected void TurnPlayer(Vector3 target)
	{
		playerStateMachine.Player.transform.LookAt(new Vector3(target.x, playerStateMachine.Player.transform.position.y, target.z));
	}

	protected Enemy GetNearestEnemy()
	{
		float min = Mathf.Infinity;
		Enemy nearest = null;

		foreach (Enemy enemy in GameManager.instance.EnemiesList)
		{
			float distance = Vector3.Distance(playerStateMachine.Player.transform.position, enemy.transform.position);
			if (min > distance)
			{
				nearest = enemy;
				min = distance;
			}
		}
		
		return nearest;
	}
		
	
	

	//check state
	protected virtual void OnIdle() {
		if(PlayerReusableData.MovementInput == new Vector2(0, 0)) {
			
			playerStateMachine.ChangeState(playerStateMachine.PlayerIdleState);
		}
	}
	protected virtual void OnMove() {
		if(PlayerReusableData.MovementInput != new Vector2(0, 0) && PlayerReusableData.IsGround) {
			playerStateMachine.ChangeState(playerStateMachine.PlayerMoveState);
		}
	}

	protected virtual void OnDash()
	{
		if (PlayerReusableData.IsGround && playerStateMachine.Player.PlayerInputSystem.DashInput)
		{
			playerStateMachine.ChangeState(playerStateMachine.PlayerDashState);
		}
	}




}