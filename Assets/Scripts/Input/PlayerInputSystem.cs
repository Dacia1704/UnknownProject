using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputSystem {
	private PlayerInputActions playerInputActions;
	public Vector2 MovementInput { get; private set; }
	public bool NomalAttackInput { get; private set; }
	public bool DashInput { get; private set; }
	public bool BackwardInput { get; private set; }
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
		playerInputActions.Player.Backward.started += onPlayerInputBackwardStarted;
		playerInputActions.Player.Backward.performed += onPlayerInputBackwardPerformed;
		playerInputActions.Player.Backward.canceled += onPlayerInputBackwardCanceled;

    }

    private void onPlayerInputBackwardCanceled(InputAction.CallbackContext context)
    {
		BackwardInput = false;
    }

    private void onPlayerInputBackwardPerformed(InputAction.CallbackContext context)
    {
		BackwardInput = true;
    }

    private void onPlayerInputBackwardStarted(InputAction.CallbackContext context)
    {
		BackwardInput = true;
    }

    public void Update() {
    }

    private void onPlayerInputNomalAttackCanceled(InputAction.CallbackContext context)
    {
		NomalAttackInput = false;
    }
    private void onPlayerInputNomalAttackStarted(InputAction.CallbackContext context)
    {
	    if (context.control.name == "leftButton" && UIManager.Instance.IsPointerOverUIElement()) return;
		NomalAttackInput = true;
    }
    private void onPlayerInputMovementCanceled(InputAction.CallbackContext context)
    {
        MovementInput = playerInputActions.Player.Movement.ReadValue<Vector2>();
    }
	private void onPlayerInputMovementPerformed(InputAction.CallbackContext context)
    {
	    if (context.control.name == "leftButton" && UIManager.Instance.IsPointerOverUIElement()) return;
		MovementInput = playerInputActions.Player.Movement.ReadValue<Vector2>();
    }

    private void onPlayerInputMovementStarted(InputAction.CallbackContext context)
	{
		if (context.control.name == "leftButton" && UIManager.Instance.IsPointerOverUIElement()) return;
		MovementInput = playerInputActions.Player.Movement.ReadValue<Vector2>();
	}
	private void onPlayerInputDashStarted(InputAction.CallbackContext context)
	{
		if (context.control.name == "leftButton" && UIManager.Instance.IsPointerOverUIElement()) return;
		DashInput = true;
	}
	private void onPlayerInputDashCanceled(InputAction.CallbackContext context)
	{
		DashInput = false;
	}

	public void EnablePlayerInput() {
		playerInputActions.Player.Enable();
	}
	public void DisablePlayerInput() {
		playerInputActions.Player.Disable();
	}




}