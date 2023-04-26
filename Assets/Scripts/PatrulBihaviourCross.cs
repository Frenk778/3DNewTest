using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrulBihaviourCross : StateMachineBehaviour
{
    private List<Transform> _points = new List<Transform>();
    private Transform _player;
    private NavMeshAgent _agent;
    private float _chaseRange = 10f;
    private float _patrolTime = 10f;
    private int _nullIndex = 0;
    private float _timer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = _nullIndex;
        _points.AddRange(EnemyController.Instance.PointsObjectTwo.GetComponentsInChildren<Transform>());
        _points.Remove(EnemyController.Instance.PointsObjectTwo);

        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.SetDestination(_points[Random.Range(_nullIndex, _points.Count)].position);       
        _player = EnemyController.Instance.GetPlayer().transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
            _agent.SetDestination(_points[Random.Range(_nullIndex, _points.Count)].position);

        _timer += Time.deltaTime;
        if (_timer > _patrolTime)
            animator.SetBool(Animator.StringToHash("IsPatrolling"), false);

        if (_player != null)
        {
            float distance = Vector3.Distance(animator.transform.position, _player.position);
            if (distance < _chaseRange)
                animator.SetBool(Animator.StringToHash("IsChasing"), true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
    }
}
