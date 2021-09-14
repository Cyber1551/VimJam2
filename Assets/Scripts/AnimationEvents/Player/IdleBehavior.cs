using Player.Control;
using UnityEngine;

namespace AnimationEvents.Player
{
    public class IdleBehavior : StateMachineBehaviour
    {        
        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            PlayerController.Instance.canReceiveInput = true;
        
            if (PlayerController.Instance.inputReceived)
            {
                //PlayerController.Instance.BlockRotation(true);
                animator.SetTrigger("Attack1");
                //PlayerController.Instance.canKnockback = false;
                //PlayerController.Instance.HandleComboInput();
                PlayerController.Instance.inputReceived = false;
            }
           
        }
    }
}
