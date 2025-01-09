using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem {
	private PlayerInputActions playerInputActions;
	public Vector2 movementInput;
	public bool nomalAttackInput;
	public bool dashInput;
    public void Start() {
		playerInputActions = new PlayerInputActions();
		EnablePlayerInput();
		playerInputActions.Player.Movement.started += onPlayerInputMovementStarted;
		playerInputActions.Player.Movement.performed += onPlayerInputMovementPerformed;
		playerInputActions.Player.Movement.canceled += onPlayerInputMovementCanceled;
		playerInputActions.Player.NomalAttack.started += onPlayerInputNomalAttackStarted;
		playerInputActions.Player.NomalAttack.canceled += onPlayerInputNomalAttackCanceled;
		playerInputActions.Player.Dash.started += onPlayerInputDashStarted;
		playerInputActions.Player.Dash.canceled += onPlayerInputDashCanceled;

    }

    public void Update() {
    }

    private void onPlayerInputNomalAttackCanceled(InputAction.CallbackContext context)
    {
		nomalAttackInput = false;
    }
    private void onPlayerInputNomalAttackStarted(InputAction.CallbackContext context)
    {
	    if (context.control.name == "leftButton" && UIManager.Instance.IsPointerOverUIElement()) return;
		nomalAttackInput = true;
    }
    private void onPlayerInputMovementCanceled(InputAction.CallbackContext context)
    {
        movementInput = playerInputActions.Player.Movement.ReadValue<Vector2>();
    }
	private void onPlayerInputMovementPerformed(InputAction.CallbackContext context)
    {
	    if (context.control.name == "leftButton" && UIManager.Instance.IsPointerOverUIElement()) return;
		movementInput = playerInputActions.Player.Movement.ReadValue<Vector2>();
    }

    private void onPlayerInputMovementStarted(InputAction.CallbackContext context)
	{
		if (context.control.name == "leftButton" && UIManager.Instance.IsPointerOverUIElement()) return;
		movementInput = playerInputActions.Player.Movement.ReadValue<Vector2>();
	}
	private void onPlayerInputDashStarted(InputAction.CallbackContext context)
	{
		if (context.control.name == "leftButton" && UIManager.Instance.IsPointerOverUIElement()) return;
		dashInput = true;
	}
	private void onPlayerInputDashCanceled(InputAction.CallbackContext context)
	{
		dashInput = false;
	}

	public void EnablePlayerInput() {
		playerInputActions.Player.Enable();
	}
	public void DisablePlayerInput() {
		playerInputActions.Player.Disable();
	}




}