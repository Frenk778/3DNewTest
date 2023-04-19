using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetLevel : MonoBehaviour
{
    public GameObject[] enemies; // Массив врагов
    private int enemiesToKill = 15; // Количество врагов, которых нужно убить для открытия двери

    void Update()
    {
        // Проверяем, сколько врагов осталось на уровне
        int enemiesLeft = 0;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null)
            {
                enemiesLeft++;
            }
        }

        // Если нет оставшихся врагов, открываем дверь
        if (enemiesLeft == enemiesToKill)
        {
            ResetLevel1(); // Если нужное количество врагов мертво, вызываем метод открытия двери
        }
    }

    void ResetLevel1()
    {
        SceneManager.LoadScene(1);
    }
}
