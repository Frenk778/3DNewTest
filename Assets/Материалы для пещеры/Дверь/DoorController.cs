using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class DoorController : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int enemiesToKill = 15;
    private Animator doorAnimator;

    public void Start()
    {
        doorAnimator = door.GetComponent<Animator>();
    }

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
        doorAnimator.SetBool("isOpen", true);
        doorAnimator.enabled = true;
    }
}
