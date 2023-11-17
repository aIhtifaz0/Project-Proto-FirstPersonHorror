using UnityEngine;

public class JumpingState : PlayerBaseState{

    public JumpingState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    private Vector3 momentum;

    public override void Enter() {

        stateMachine.IsJumping = true;
        stateMachine.ForceReceiver.Jump(stateMachine.JumpForce);// Calling Jump method

        momentum = stateMachine.Controller.velocity;
        momentum.y = 0f; // Resetting current y velocity for smooth jump
    }

    public override void Tick(float deltatime) {

        Move(momentum, deltatime);

        if (stateMachine.Controller.isGrounded) {
            stateMachine.SwitchState(new MainState(stateMachine));
        }
    }

    public override void Exit() {
        stateMachine.IsJumping = false;
    }
}
