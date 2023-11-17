using UnityEngine;

public abstract class StateMachine : MonoBehaviour{

    private State currentState; // Current running state

    private void Update(){
        
        currentState?.Tick(Time.deltaTime);
    }

    public void SwitchState(State newState){ // Changing state
        
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}
