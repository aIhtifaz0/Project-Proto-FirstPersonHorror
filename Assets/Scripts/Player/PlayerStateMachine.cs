using UnityEngine;

public class PlayerStateMachine : StateMachine{

    [field: SerializeField] public InputReader InputReader { get; private set; } // Input
    [field: SerializeField] public ForceReceiver ForceReceiver{ get; private set; } // Force & Gravity
    [field: SerializeField] public CharacterController Controller { get; private set; } // CharacterContoller
    [field: SerializeField] public CameraRotation Camera { get; private set; } // Camera Script
    [field: SerializeField] public LayerMask CounterLayerMask { get; set; } // Counter Layermask
    [field: SerializeField] public Transform CameraTransform { get; set; } // Camera Transform
    [field: SerializeField] public float MovementSpeed { get; private set; } // Move Speed
    [field: SerializeField] public float MouseSensitivity { get; private set; } // Mouse Sensitivity
    [field: SerializeField] public float JumpForce { get; private set; } // Jump Force
    [field: SerializeField] public float RaycastDistance { get; private set; } // Raycast Distance
    public bool IsJumping { get; set; } // Jump Boolean

    private void Start(){

        SwitchState(new MainState(this));
    }
}
