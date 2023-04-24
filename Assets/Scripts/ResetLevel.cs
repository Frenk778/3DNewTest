using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    [SerializeField] private Transform[] _enemies; 
    [SerializeField] private int _enemiesToKill = 15;          


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
            StartCoroutine(ResetLevelCoroutine());
        }
    }

    IEnumerator ResetLevelCoroutine()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }    
}
