using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableColliderAxe : StateMachineBehaviour
{
   
    private Collider possibleCollider;
    void Start(){
        possibleCollider =  GameObject.FindGameObjectsWithTag("Hand")[0].transform.GetChild(0).gameObject.GetComponent<Collider>();
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(possibleCollider == null){
            possibleCollider =  GameObject.FindGameObjectsWithTag("Hand")[0].transform.GetChild(0).gameObject.GetComponent<Collider>();
        }
         possibleCollider.enabled = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         possibleCollider.enabled = false;
    }
}
