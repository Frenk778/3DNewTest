using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController2 : MonoBehaviour
{
    [SerializeField] public GameObject door; 
    [SerializeField] public GameObject[] enemies;
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
