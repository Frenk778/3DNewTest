using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController2 : MonoBehaviour
{
    public GameObject door; 
    private Animator doorAnimator; 

    public GameObject[] enemies; 
    private int enemiesToKill = 15; 

    void Start()
    {
        doorAnimator = door.GetComponent<Animator>();     
    }

    void Update()
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

    void OpenDoor()
    {
        doorAnimator.SetBool("isOpen", true); 
        doorAnimator.enabled = true; 
    }
}
