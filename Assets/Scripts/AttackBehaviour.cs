using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    Transform player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player == null)
            return;

        animator.transform.LookAt(player);
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if (distance > 3)
            animator.SetBool("IsAttack", false);

        if (distance > 15)
            animator.SetBool("IsChasing", false);

        if (animator.transform != null)
        {
            Vector3 targetPosition = animator.transform.position;
        }
    }    


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
