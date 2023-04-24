using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Score _scoreScript;
    [SerializeField] private Transform _weapon;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _health = 100;
    [SerializeField] private int _damage = 10;

    private float _attackRadius = 5f;

    public int Damage => _damage;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _scoreScript = FindObjectOfType<Score>();
    }

    private void Update()
    {
        _healthBar.value = _health;
    }

    private void OnTriggerEnter(Collider other)
    {
        Arrow arrow = other.GetComponent<Arrow>();
        if (arrow != null)
        {
            TakeDamage(arrow.Damage);
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
        {
            Die();
            _healthBar.gameObject.SetActive(false);
        }
        else
        {
            _animator.SetBool("IsChasing", true);
        }
    }  


    public void Attack()
    {
        Collider[] hitPlayers = Physics.OverlapSphere(_weapon.position, _attackRadius, _playerLayer);

        foreach (Collider player in hitPlayers)
        {
            Player playerScript = player.GetComponent<Player>();
            if (playerScript != null)
            {
                playerScript.TakeDamage(Damage);
            }
        }
    }

    private void Die()
    {
        Player player = FindObjectOfType<Player>();

        if (player != null)
        {
            player.AddScore(5);
        }

        _animator.SetTrigger("Death");

        Collider enemyCollider = GetComponent<Collider>();

        if (enemyCollider != null)
        {
            enemyCollider.enabled = false;
        }

        Destroy(gameObject, 2);
        _scoreScript.AddScore();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(Damage);
            _scoreScript.AddScore();
        }
    }
}
