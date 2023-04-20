using UnityEngine;
using UnityEngine.UI;

public class EnemyContoler : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private float attackRadius = 5f;   
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Slider healthBar;   
    public int Damage = 10;   
    private Animator _animator;
    public Transform weapon;
    private Score scoreScript;


    void Start()
    {
        _animator = GetComponent<Animator>();
        scoreScript = FindObjectOfType<Score>();
    }

    private void Update()
    {
        healthBar.value = health;
    }

    public void TakeDamage(int damage)  
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
            healthBar.gameObject.SetActive(false);
        }
        else
        {            
            _animator.SetBool("IsChasing", true);
        }
    }


    void Die()
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

        Destroy(gameObject, 2);
        scoreScript.AddScore();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            Arrow arrow = other.GetComponent<Arrow>();
            if (arrow != null)
            {
                TakeDamage(arrow._damage);
                Destroy(other.gameObject);  
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
                playerScript.TakeDamage(Damage);
            }
        }
    } 


    private void OnCollisionEnter(Collision collision)
    {        
        if (collision.gameObject.CompareTag("Player"))
        {            
            collision.gameObject.GetComponent<Player>().TakeDamage(Damage);
            scoreScript.AddScore();
        }
    }
}
