using UnityEngine;

public abstract class StateMachine
{
    protected IState currentState;

    public void ChangeState(IState newState)
    {
        if(currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        newState.Enter();
    }

    public void Update()
    {
        currentState?.Update();
    }
    public void PhysicsUpdate()
    {
        currentState?.PhysicsUpdate();
    }
}
