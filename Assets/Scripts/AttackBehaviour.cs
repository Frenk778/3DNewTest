using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    private Transform _player;    
    private int _attackDistance = 3;
    private int _chasingDistace = 15;       

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _player = EnemyCoordinator.Instance.GetPlayer().transform;        
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_player == null)
            return;

        animator.transform.LookAt(_player);
        float distance = Vector3.Distance(animator.transform.position, _player.position);
        if (distance > _attackDistance)
            animator.SetBool(Animator.StringToHash("IsAttack"), false);

        if (distance > _chasingDistace)
            animator.SetBool(Animator.StringToHash("IsChasing"), false);

        if (animator.transform != null)
        {
            Vector3 targetPosition = animator.transform.position;
        }
    }    
}