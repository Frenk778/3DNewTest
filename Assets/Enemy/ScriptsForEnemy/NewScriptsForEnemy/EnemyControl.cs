//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemyControl : MonoBehaviour
//{   
//    public int health = 100;
//    public int damage = 10;
//    private Animator animator;
//    public float attackRadius = 5f;
//    public Transform weapon;
//    public LayerMask playerLayer;    


//    void Start()
//    {
//        animator = GetComponent<Animator>();
//    }
//    public void TakeDamage(int damage)
//    {
//        health -= damage;
//        if (health <= 0)
//        {
//            Die();
//        }
//    }

//    void Die()
//    {
//        animator.SetTrigger("Death");
//        Destroy(gameObject, 3);        
//    }

//    //private void OnTriggerEnter(Collider other)
//    //{
//    //    // Проверяем, является ли объект героем
//    //    if (other.CompareTag("Player"))
//    //    {
//    //        // Вызываем метод нанесения урона герою
//    //        Player player = other.GetComponent<Player>();
//    //        if (player != null)
//    //        {
//    //            player.TakeDamage(damage);
//    //        }
//    //    }
//    //}

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Arrow"))
//        {
//            Arrow arrow = other.GetComponent<Arrow>();
//            if (arrow != null)
//            {
//                TakeDamage(arrow.Damage);
//                Destroy(other.gameObject);
//            }
//        }
//    }

//    public void Attack()
//    {
//        Collider[] hitPlayers = Physics.OverlapSphere(weapon.position, attackRadius, playerLayer);
//        foreach (Collider player in hitPlayers)
//        {
//            Player playerScript = player.GetComponent<Player>();
//            if (playerScript != null)
//            {
//                playerScript.TakeDamage(damage);
//            }            
//        }
//    }

//    void OnTriggerStay(Collider other)
//    {
//        if (other.CompareTag("Player"))
//        {
//            Player player = other.GetComponent<Player>();
//            if (player != null)
//            {
//                player.TakeDamage(damage);
//            }
//        }
//    }

//    public void MeleeAttack()
//    {
//        Collider[] hitPlayers = Physics.OverlapSphere(weapon.position, attackRadius, playerLayer);
//        foreach (Collider player in hitPlayers)
//        {
//            Player playerScript = player.GetComponent<Player>();
//            if (playerScript != null)
//            {
//                playerScript.TakeDamage(damage);
//            }
//        }
//    }


//    private void OnCollisionEnter(Collision collision)
//    {
//        // Проверяем, является ли объект героем
//        if (collision.gameObject.CompareTag("Player"))
//        {
//            // Вызываем метод нанесения урона герою
//            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
//        }
//    }

//}
