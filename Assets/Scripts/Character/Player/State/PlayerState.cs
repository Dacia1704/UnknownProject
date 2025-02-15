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
	protected float hitCounter = 0;
	public  PlayerState (PlayerStateMachine playerStateMachine) {
		this.playerStateMachine = playerStateMachine;
		this.playerPropertiesSO = playerStateMachine.Player.PlayerPropertiesSO;
		
	}
    public virtual void Enter()
    {
		// Debug.Log("State: " + GetType().Name);
		nomalAttackCounter = Time.time;
		hitCounter = playerPropertiesSO.BaseStats.HitCooldown;

    }

    public virtual void Exit()
    {
    }

    public virtual void PhysicsUpdate()
    {
	    if (hitCounter > 0)
	    {
		    hitCounter -= Time.fixedDeltaTime;
	    }
    }

    public virtual void Update()
    {
		Attack();
    }

	//logic
    protected virtual void Move(Vector2 direction, float speed,bool backward= false) {
		if (playerStateMachine.Player.PlayerInputSystem.MovementInput == Vector2.zero) return;
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
		if (playerStateMachine.Player.PlayerInputSystem.NomalAttackInput && playerStateMachine.Player.IsNomalAttacking == false)
		{
			playerStateMachine.Player.IsNomalAttacking = true;
			playerStateMachine.Player.playerAnimationManager.SetFloatValueAnimation(playerPropertiesSO.NomalAttackValueTrigger,currentAttack);

			if (playerStateMachine.Player.PlayerInputSystem.MovementInput == new Vector2(0, 0))
			{
				TurnPlayerToMousePosition();
			}
		}
		else if (playerStateMachine.Player.IsNomalAttacking)
		{
			if (playerStateMachine.Player.playerAnimationManager.IsAnimationEnded(
				    "SwordNomalAttack", 1) )
			{
				playerStateMachine.Player.IsNomalAttacking = false;
				playerStateMachine.Player.playerAnimationManager.SetFloatValueAnimation(playerPropertiesSO.NomalAttackValueTrigger,-1);
				nomalAttackCounter = Time.time;
				if (currentAttack == 0)
				{
					currentAttack = 1;
				}
				else
				{
					currentAttack = 0;
				}
			} else if (playerStateMachine.Player.playerAnimationManager.IsAnimationEnded(
				           "StaffNomalAttack", 1))
			{
				playerStateMachine.Player.IsNomalAttacking = false;
				playerStateMachine.Player.playerAnimationManager.SetFloatValueAnimation(playerPropertiesSO.NomalAttackValueTrigger,-1);
			} else if (playerStateMachine.Player.playerAnimationManager.IsAnimationEnded(
				           "BowNomalAttack", 1))
			{
				playerStateMachine.Player.IsNomalAttacking = false;
				playerStateMachine.Player.playerAnimationManager.SetFloatValueAnimation(playerPropertiesSO.NomalAttackValueTrigger,-1);
			} else if (playerStateMachine.Player.playerAnimationManager.IsAnimationEnded(
				           "FighterNomalAttack", 1))
			{
				playerStateMachine.Player.IsNomalAttacking = false;
				playerStateMachine.Player.playerAnimationManager.SetFloatValueAnimation(playerPropertiesSO.NomalAttackValueTrigger,-1);
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
		} else if (playerStateMachine.Player.IsNomalAttacking == false)
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

	protected void TurnPlayerToMousePosition()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Ground")))
		{
			Vector3 worldPosition = hit.point;
			// Debug.Log("Mouse World Position: " + worldPosition);
			TurnPlayer(worldPosition);
		}
	}
	protected void TurnPlayer(Vector3 target)
	{
		playerStateMachine.Player.transform.LookAt(new Vector3(target.x, playerStateMachine.Player.transform.position.y, target.z));
	}

	protected Enemy GetNearestEnemy()
	{
		float min = Mathf.Infinity;
		Enemy nearest = null;

		foreach (Enemy enemy in GameManager.instance.EnemyManager.EnemiesList)
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
		if(playerStateMachine.Player.PlayerInputSystem.MovementInput == new Vector2(0, 0)) {
			
			playerStateMachine.ChangeState(playerStateMachine.PlayerIdleState);
		}
	}
	protected virtual void OnMove() {
		if(playerStateMachine.Player.PlayerInputSystem.MovementInput != new Vector2(0, 0)) {
			playerStateMachine.ChangeState(playerStateMachine.PlayerMoveState);
		}
	}

	protected virtual void OnDash()
	{
		if (playerStateMachine.Player.PlayerInputSystem.DashInput)
		{
			playerStateMachine.ChangeState(playerStateMachine.PlayerDashState);
		}
	}

	protected virtual void OnHit()
	{
		if (playerStateMachine.Player.Damable.IsGetAttack > 0 && hitCounter <=0f)
		{
			playerStateMachine.ChangeState(playerStateMachine.PlayerHitState);
		}
	}




}