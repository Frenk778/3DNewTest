using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private Slider _healthBar;

    private Animator _animator;
    private static Player _instance;
    private bool _isTakingDamage = false;
    private float _lastDamageTime;
    private bool _isAlive = true;
    private int _currentHealth;
    private int _score = 0;
    private int _minCurrentHealth = 0;
    private int _destroyPlayerTime = 5;
    private float _loadMainMenuTime = 2f;
    private float _initialElapsedTime = 0f;
    private float _timeSinceLastDamage = 5f;
    private float _restoreHealthInterval = 1.5f;

    public static Player Instance => _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    private void Start()
    {    
        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
        _isAlive = true;
    }

    private void Update()
    {
        _healthBar.value = _currentHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            TakeDamage(enemy.Damage);
        }
    }

    public void TakeDamage(int damage)
    {
        if (!_isAlive)
        {
            return;
        }

        _currentHealth -= damage;

        if (_currentHealth < _minCurrentHealth)
        {
            _currentHealth = _minCurrentHealth;
        }

        _lastDamageTime = Time.time;

        if (!_isTakingDamage)
        {
            _isTakingDamage = true;
            StartCoroutine(RestoreHealthCoroutine());
        }

        if (_currentHealth == _minCurrentHealth)
        {
            Die();
        }
    }

    public void AddScore(int points)
    {
        _score += points;
    }

    private void Die()
    {
        _animator.SetBool(Animator.StringToHash("IsDead"), true);

        if (gameObject != null)
        {
            _animator.SetTrigger("IsDead");
            Destroy(gameObject, _destroyPlayerTime);
        }

        StartCoroutine(LoadMainMenuAfterDelay(_loadMainMenuTime));
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private IEnumerator RestoreHealthCoroutine()
    {
        while (Time.time - _lastDamageTime < _timeSinceLastDamage)
        {
            yield return null;
        }

        float elapsedTime = _initialElapsedTime;

        while (_currentHealth < _maxHealth)
        {
            yield return null;
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= _restoreHealthInterval)
            {
                _currentHealth++;
                elapsedTime = _initialElapsedTime;
            }
        }

        _isTakingDamage = false;
    }

    private IEnumerator LoadMainMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}