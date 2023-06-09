using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _doorAnimator;
    [SerializeField] private Transform[] _enemies;
    [SerializeField] private int _enemiesToKill;

    private void Update()
    {
        int enemiesLeft = 0;

        for (int i = 0; i < _enemies.Length; i++)
        {
            if (_enemies[i] == null)
            {
                enemiesLeft++;
            }
        }

        if (enemiesLeft == _enemiesToKill)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        _doorAnimator.SetBool(Animator.StringToHash("isOpen"), true);
        _doorAnimator.enabled = true;
    }
}