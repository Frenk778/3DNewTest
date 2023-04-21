using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController3 : MonoBehaviour
{
    [SerializeField] private Animator _doorAnimator;
    [SerializeField] public GameObject[] enemies;
    [SerializeField] private int enemiesToKill = 15;

    private void Update()
    {
        int enemiesLeft = 0;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null)
            {
                enemiesLeft++;
            }
        }

        if (enemiesLeft == enemiesToKill)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        _doorAnimator.SetBool("isOpen", true);
        _doorAnimator.enabled = true;
    }
}
