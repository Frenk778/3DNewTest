using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatruleBihaviour : StateMachineBehaviour
{
    private List<Transform> points = new List<Transform>();
    private Transform player;
    private NavMeshAgent agent;
    private float _patrolTime = 10f;
    private float chaseRange = 10f;
    private int _nullIndex = 0;
    private float timer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = _nullIndex;
        Transform pointsObject = GameObject.FindGameObjectWithTag("Points1").transform;
        foreach (Transform t in pointsObject)
            points.Add(t);

        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(points[Random.Range(0, points.Count)].position);
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(points[Random.Range(0, points.Count)].position);

        timer += Time.deltaTime;
        if (timer > _patrolTime)
            animator.SetBool("IsPatrolling", false);

        if (player != null)
        {
            float distance = Vector3.Distance(animator.transform.position, player.position);
            if (distance < chaseRange)
                animator.SetBool("IsChasing", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
