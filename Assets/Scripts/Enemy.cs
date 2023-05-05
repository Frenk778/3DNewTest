using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    private const int ZeroLive = 0;
    private const float DestroyDelay = 2f;

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
        Score scoreScript = EnemyController.Instance.GetScoreScript();
        if (scoreScript != null)
        {
            _scoreScript = scoreScript;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Arrow arrow))
        {
            TakeDamage(arrow.Damage);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.TakeDamage(Damage);
            _scoreScript.AddScore();
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if (_health <= ZeroLive)
        {
            Die();
            _healthBar.gameObject.SetActive(false);
        }
        else
        {
            _animator.SetBool(Animator.StringToHash("IsChasing"), true);
            FixedUpdate();
        }
    }

    public void Attack()
    {
        Collider[] hitPlayers = Physics.OverlapSphere(_weapon.position, _attackRadius, _playerLayer);

        foreach (Collider player in hitPlayers)
        {
            Player playerScript;

            if (player.TryGetComponent(out playerScript))
            {
                playerScript.TakeDamage(Damage);
            }
        }
    }

    private void FixedUpdate()
    {
        if (_healthBar.value != _health)
        {
            _healthBar.value = _health;
        }
    }


    private void Die()
    {
        _animator.SetTrigger(Animator.StringToHash("Death"));

        Collider enemyCollider;

        if (TryGetComponent(out enemyCollider))
        {
            enemyCollider.enabled = false;
        }

        Destroy(gameObject, DestroyDelay);
        EnemyController.Instance.GetScoreScript().AddScore();
    }
}