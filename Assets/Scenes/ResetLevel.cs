using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    public GameObject[] enemies; 
    private int enemiesToKill = 15;

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
            ResetLevel1();
        }
    }

    void ResetLevel1()
    {
        SceneManager.LoadScene(1);
    }
}
