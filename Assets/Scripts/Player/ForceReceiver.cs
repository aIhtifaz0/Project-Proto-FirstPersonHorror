using UnityEngine;

public class ForceReceiver : MonoBehaviour{

    [SerializeField] private CharacterController controller;
    [SerializeField] private float drag = 0.3f;

    private float verticalVelocity;
    private Vector3 impact;
    private Vector3 dampingVelocity;

    public Vector3 Movement => impact + Vector3.up * verticalVelocity;

    private void Update(){

        //Adding gravity on CharacterController object
        if(verticalVelocity <= 0f && controller.isGrounded){
            verticalVelocity = Physics.gravity.y * Time.deltaTime;
        }
        else{
            verticalVelocity += Physics.gravity.y * Time.deltaTime;
        }

        //decreasing impact value after time pass
        impact = Vector3.SmoothDamp(impact, Vector3.zero, ref dampingVelocity, drag);
    }

    public void AddForce(Vector3 force){
        
        impact += force;
    }

    public void Jump(float jumpForce){

        verticalVelocity += jumpForce;
    }
}
