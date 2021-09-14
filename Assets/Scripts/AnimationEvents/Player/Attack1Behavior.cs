using Player.Control;
using UnityEngine;

namespace AnimationEvents.Player
{
    public class Attack1Behavior : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.ResetTrigger("Attack1");
            //PlayerController.Instance.BlockRotation(false);
            PlayerController.Instance.canReceiveInput = true;
            //PlayerController.Instance.SetCanDodge(true);
            
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (PlayerController.Instance.inputReceived)
            {
                //Debug.Log(stateInfo.normalizedTime >= 0.5);

                if (stateInfo.normalizedTime <= 0.5)
                {
                    animator.SetTrigger("Attack2");
                    //PlayerController.Instance.canKnockback = false;
                }
                //PlayerController.Instance.ResetStanceTimer();
                //PlayerController.Instance.BlockRotation(true);
                //PlayerController.Instance.HandleComboInput();
                PlayerController.Instance.inputReceived = false;


            }
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            PlayerController.Instance.canReceiveInput = true;
        }
    }
}
