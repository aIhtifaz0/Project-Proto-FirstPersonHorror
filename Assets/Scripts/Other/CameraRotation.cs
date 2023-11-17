using UnityEngine;

public class CameraRotation : MonoBehaviour {

    [field: SerializeField] public PlayerStateMachine StateMachine { get; private set; }

    private float yRotation;
    private float xRotation;

    private void Start() {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; // Disabling Cursor visibility
    }

    private void LateUpdate() {

        var xRotationValue = CalculateYRotation();
        yRotation = CalculateXRotation();

        StateMachine.transform.Rotate(Vector3.up * yRotation); // Rotating transform x rotation based on mouse
        StateMachine.CameraTransform.localRotation = Quaternion.Euler(xRotationValue, 0f, 0f);// Rotating transform y rotation based on mouse
    }

    private float CalculateXRotation() {

        var xMouseInput = StateMachine.InputReader.MouseValue.x * StateMachine.MouseSensitivity * Time.deltaTime;
        return xMouseInput;
    }

    private float CalculateYRotation() {

        var YRotation = StateMachine.InputReader.MouseValue.y * StateMachine.MouseSensitivity * Time.deltaTime;

        xRotation -= YRotation;
        xRotation = Mathf.Clamp(xRotation, -75f, 75f); // Clamping x rotation

        return xRotation;
    }
}