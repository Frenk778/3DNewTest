using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyContoler : MonoBehaviour
{
    //что исправить(публичные методы с большой буквы,должны быть —ериалазфилд(12 строка)сделать весь блок переменных приватными)

    public int health = 100;    //текущее здоровье врага.
    public int damage = 10;   //урон, который может наносить враг.
    private Animator _animator;   //компонент аниматора, который управл€ет анимацией персонажа.
    public float attackRadius = 5f;   //радиус атаки врага.
    public Transform weapon;   //объект, который используетс€ дл€ атаки.
    public LayerMask playerLayer;   //слой, на котором наход€тс€ игроки.
    public Slider healthBar;   //полоска здоровь€ врага.    
    private Score scoreScript; // ссылка на скрипт очков


    void Start()
    {
        _animator = GetComponent<Animator>();
        scoreScript = FindObjectOfType<Score>();
    }

    private void Update()
    {
        healthBar.value = health;
    }

    public void TakeDamage(int damage)  //прин€ти€ урона
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
            healthBar.gameObject.SetActive(false);            
        }
        else
        {
            // ѕри получении урона начинаем преследование геро€
            _animator.SetBool("IsChasing", true);
        }
    }


    void Die()   //смерть врага
    {
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            player.AddScore(5);
        }

        Debug.Log("Enemy died!");
        _animator.SetTrigger("Death");

        Collider enemyCollider = GetComponent<Collider>();
        if (enemyCollider != null)
        {
            enemyCollider.enabled = false;
        }

        Destroy(gameObject, 2); //найти другой метод дл€ удалени€ врага что бы не загружать систему(пул объектов(поискать))
        scoreScript.AddScore();
    }

    void OnTriggerEnter(Collider other)   //прин€ти€ урона от стрелы
    {
        if (other.CompareTag("Arrow"))
        {
            Arrow arrow = other.GetComponent<Arrow>();
            if (arrow != null)
            {
                TakeDamage(arrow.Damage);
                Destroy(other.gameObject);   //найти другой способ (отключить и обратно вернуть в пул)
            }
        }
    }

    public void Attack()
    {
        Collider[] hitPlayers = Physics.OverlapSphere(weapon.position, attackRadius, playerLayer);

        foreach (Collider player in hitPlayers)
        {
            Player playerScript = player.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.TakeDamage(damage);
            }
        }
    } 


    private void OnCollisionEnter(Collision collision)
    {
        // ѕровер€ем, €вл€етс€ ли объект героем
        if (collision.gameObject.CompareTag("Player"))
        {
            // ¬ызываем метод нанесени€ урона герою
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            scoreScript.AddScore();
        }
    }
}
