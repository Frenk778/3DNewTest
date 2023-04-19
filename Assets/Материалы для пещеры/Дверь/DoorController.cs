using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class DoorController : MonoBehaviour
{
    public GameObject door; // Ссылка на игровой объект двери
    private Animator doorAnimator; // Ссылка на компонент аниматора двери

    public GameObject[] enemies; // Массив врагов
    private int enemiesToKill = 15; // Количество врагов, которых нужно убить для открытия двери

    void Start()
    {
        doorAnimator = door.GetComponent<Animator>(); // Получаем компонент аниматора двери        
    }

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
            OpenDoor(); // Если нужное количество врагов мертво, вызываем метод открытия двери
        }
    }

    void OpenDoor()
    {
        doorAnimator.SetBool("isOpen", true); // Устанавливаем булевую переменную isOpen в true, чтобы проиграть анимацию открытия двери
        doorAnimator.enabled = true; // Включаем компонент аниматора двери, если он отключен        
    }
}
