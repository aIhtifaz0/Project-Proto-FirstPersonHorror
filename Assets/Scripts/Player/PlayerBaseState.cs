using UnityEngine;

public abstract class PlayerBaseState : State{

    //only class inherit can access it
    protected PlayerStateMachine stateMachine;

    // Getting Statemachine
    public PlayerBaseState(PlayerStateMachine stateMachine){

        this.stateMachine = stateMachine; 
    }

    protected void Move(Vector3 motion, float deltaTime){

        stateMachine.Controller.Move((motion + stateMachine.ForceReceiver.Movement) * deltaTime);
    }

    protected void Move(float deltaTime) {

        Move(Vector3.zero, deltaTime);
    }
}
