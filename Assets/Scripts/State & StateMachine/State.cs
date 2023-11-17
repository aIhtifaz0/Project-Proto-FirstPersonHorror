using UnityEngine;

public abstract class State{
    
    public abstract void Enter(); // Call once when script run
    public abstract void Tick(float deltatime); // Call every frame
    public abstract void Exit(); // Call when script end


    //Getting Normalize time for combo animation system
    /*
    protected float GetNormalizedTime(Animator animator){

        AnimatorStateInfo CurrentInfo = animator.GetCurrentAnimatorStateInfo(0);
        AnimatorStateInfo NextInfo = animator.GetNextAnimatorStateInfo(0);

        //if trasitioning to an attack and then checking how far trought is the animation
        if(animator.IsInTransition(0) && NextInfo.IsTag("Attack")){

            return NextInfo.normalizedTime;
        }
        //if not trasitioning to an attack and then checking how far trought is the animation
        else if(!animator.IsInTransition(0) && CurrentInfo.IsTag("Attack")){

            return CurrentInfo.normalizedTime;
        }
        else{

            return 0f;
        }
    }
    */
}
