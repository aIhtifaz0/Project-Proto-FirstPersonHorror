using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputReader : MonoBehaviour, Character.IPlayerActions{

    private Character characterInput;

    public Vector2 MovementValue { get; private set; }
    public Vector2 MouseValue { get; private set; }

    public event Action OnClick;
    public event Action OnJumping;

    private void Start(){

        characterInput = new Character();
        characterInput.Player.SetCallbacks(this); // Use SetCallback method to get Input reference
        characterInput.Player.Enable();
    }

    public void OnInteract(InputAction.CallbackContext context){

        if (!context.performed) { return; }
        OnClick?.Invoke();
    }

    public void OnJump(InputAction.CallbackContext context){

        if (context.performed) { return; }
        OnJumping?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context){

        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnPause(InputAction.CallbackContext context){
        
    }

    public void OnTask(InputAction.CallbackContext context){
        
    }

    public void OnMouse(InputAction.CallbackContext context){

        MouseValue = context.ReadValue<Vector2>();
    }

    private void OnDestroy() {

        characterInput.Player.Disable();
    }
}
