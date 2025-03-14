﻿using UnityEngine;

public class PlayerDashState: PlayerState
{
    private bool _isDashing;
    private Vector2 _dashDirection;
    private float _dashTime;
    public PlayerDashState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _isDashing = true;
        _dashTime = 0;
        _dashDirection = playerStateMachine.Player.PlayerInputManager.MovementInput;
        if(playerStateMachine.Player.PlayerInputManager.BackwardInput) {
            playerStateMachine.Player.playerAnimationManager.SetFloatValueAnimation(playerPropertiesSO.MoveTrigger,1);
        } else {
            playerStateMachine.Player.playerAnimationManager.SetFloatValueAnimation(playerPropertiesSO.MoveTrigger,0);
        }
    }

    public override void Update()
    {
        base.Update();
        
        if (!_isDashing)
        {
            OnHit();
            OnIdle();
            OnMove();
        }
    }

    public override void PhysicsUpdate()
    {
        
        base.PhysicsUpdate();
        Dash(((float)playerStateMachine.Player.PlayerStats.Speed/10f) * playerStateMachine.Player.PlayerPropertiesSO.BaseStats.BaseDashModifier);
        _dashTime += Time.fixedDeltaTime;
        if (_dashTime > playerStateMachine.Player.PlayerPropertiesSO.BaseStats.BaseDashTime)
        {
            _isDashing = false;
            ResetVelocity();
        }

    }
    
    protected virtual void Dash(float speed)
    {
        Vector3 dir = new Vector3();
        if (_dashDirection != Vector2.zero)
        {
            float newAngle = - Camera.main.transform.eulerAngles.y;
            float angleRadians = Mathf.Deg2Rad * newAngle;
            float newX = _dashDirection.x * Mathf.Cos(angleRadians) - _dashDirection.y * Mathf.Sin(angleRadians);
            float newY = _dashDirection.x * Mathf.Sin(angleRadians) + _dashDirection.y * Mathf.Cos(angleRadians);
            dir = new Vector3(newX, 0, newY);
        }
        else
        {
            dir = playerStateMachine.Player.transform.forward;
        }
        playerStateMachine.Player.transform.rotation = Quaternion.RotateTowards(playerStateMachine.Player.transform.rotation, Quaternion.LookRotation(dir), 1000 * Time.deltaTime);
        playerStateMachine.Player.Rigidbody.velocity = new Vector3(dir.x *speed,0,dir.z * speed);
    }

    public override void Exit()
    {
        playerStateMachine.Player.playerAnimationManager.SetFloatValueAnimation(playerPropertiesSO.MoveTrigger,-1);
        base.Exit();
    }
}