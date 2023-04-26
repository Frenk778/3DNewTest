using UnityEngine;
using UnityEngine.AI;

public class RunBihaviour : StateMachineBehaviour
{
    private NavMeshAgent _agent;
    private Transform _player;
    private float _runSpeed = 5f;
    private float _walkSpeed = 2f;
    private float _attackRange = 2f;
    private float _chaseRange = 10f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.speed = _runSpeed;
        _player = FindObjectOfType<Player>().transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_player.position);
        float distance = Vector3.Distance(animator.transform.position, _player.position);
        if (distance < _attackRange)
            animator.SetBool(Animator.StringToHash("IsAttack"), true);

        if (distance > _chaseRange)
            animator.SetBool(Animator.StringToHash("IsChasing"), false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
        _agent.speed = _walkSpeed;
    }
}