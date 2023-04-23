using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrulBihaviourZombie : StateMachineBehaviour
{
    private float _timer;
    private List<Transform> _points = new List<Transform>();
    private Transform _player;
    private float _chaseRange = 10;
    private NavMeshAgent _agent;
    private int _nullIndex = 0;
    private float _patrolTime = 10f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = _nullIndex;
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points3").transform;
        foreach (Transform t in pointsObject)
            _points.Add(t);

        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.SetDestination(_points[Random.Range(0, _points.Count)].position);
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
            _agent.SetDestination(_points[Random.Range(0, _points.Count)].position);

        _timer += Time.deltaTime;
        if (_timer > _patrolTime)
            animator.SetBool("IsPatrolling", false);

        if (_player != null)
        {
            float distance = Vector3.Distance(animator.transform.position, _player.position);
            if (distance < _chaseRange)
                animator.SetBool("IsChasing", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
    }
}