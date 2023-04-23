using UnityEngine;

public class IdleBihaviour : StateMachineBehaviour
{
    private Transform _player;
    private float _startValue = 0f;
    private float _waitingTime = 2f;
    private float _chaseRange = 10f;
    private float _timer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer = _startValue;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _timer += Time.deltaTime;
        if (_timer > _waitingTime)
            animator.SetBool("IsPatrolling", true);

        float distance = Vector3.Distance(animator.transform.position, _player.position);
        if (distance < _chaseRange)
            animator.SetBool("IsChasing", true);
    }
}