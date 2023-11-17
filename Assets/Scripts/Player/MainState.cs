using System;
using UnityEngine;

public class MainState : PlayerBaseState{

    public MainState(PlayerStateMachine stateMachine) : base(stateMachine) {}

    //Event for Calling Interact every counter
    public event EventHandler<OnSelectedCounterChangeEventArgs> OnSelectedCounterChange;
    public class OnSelectedCounterChangeEventArgs : EventArgs {
        public ClearCounter selectedCounter;
    }

    private ClearCounter selectedCounter;

    // Subscribing InputReader Event
    public override void Enter(){

        stateMachine.InputReader.OnClick += OnInteract;
        stateMachine.InputReader.OnJumping += Jump;
    }

    public override void Tick(float deltatime) {

        var MoveDirection = CalculateMove();
        Move(MoveDirection * stateMachine.MovementSpeed, deltatime);
    }

    // Unsubscribing InputReader Event
    public override void Exit(){

        stateMachine.InputReader.OnClick -= OnInteract;
        stateMachine.InputReader.OnJumping -= Jump;
    }

    // Raycasting for object detection
    private void Raycast() {

        if(Physics.Raycast(stateMachine.Camera.transform.position, stateMachine.Camera.transform.forward,
            out RaycastHit raycastHit, stateMachine.RaycastDistance, stateMachine.CounterLayerMask)) {

            if (raycastHit.transform.TryGetComponent(out ClearCounter clearCounter)) {
                if (clearCounter != selectedCounter) {
                    Debug.Log("Interact");
                    SetSelectedCounter(clearCounter);
                }
            }
            else {
                SetSelectedCounter(null);
            }
        }
        else {
            SetSelectedCounter(null);
        }
    }

    private void OnInteract() {

        Raycast();
    }

    //Calculating Movement Input with camera relative transform and InputValue
    private Vector3 CalculateMove() {

        Vector3 x = stateMachine.Camera.transform.right;
        Vector3 z = stateMachine.Camera.transform.forward;

        x.y = 0f;
        z.y = 0f;
        x.Normalize();
        z.Normalize();

        return z * stateMachine.InputReader.MovementValue.y +
        x * stateMachine.InputReader.MovementValue.x;
    }

    //Geting selected counter with event
    private void SetSelectedCounter(ClearCounter selectedCounter) {

        this.selectedCounter = selectedCounter;

        OnSelectedCounterChange?.Invoke(this, new OnSelectedCounterChangeEventArgs {
            selectedCounter = selectedCounter
        });
    }

    private void Jump() {

        if (stateMachine.IsJumping != true) {
            stateMachine.SwitchState(new JumpingState(stateMachine));
        }
    }
}
