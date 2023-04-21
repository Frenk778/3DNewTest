using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _score = 0;
    [SerializeField] private float _restoreHealthInterval = 1.5f;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private Slider _healthBar;

    private Animator _animator;
    private float _lastDamageTime;
    private int _currentHealth;
    private bool isAlive = true;
    private bool isTakingDamage = false;


    private void Start()
    {
        _currentHealth = _maxHealth;
        _animator = GetComponent<Animator>();
        isAlive = true;
    }

    private void Update()
    {
        _healthBar.value = _currentHealth;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyContoler enemy = other.GetComponent<EnemyContoler>();
            if (enemy != null)
            {
                TakeDamage(enemy.Damage);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        if (!isAlive)
        {
            return;
        }

        _currentHealth -= damage;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        _lastDamageTime = Time.time;

        if (!isTakingDamage)
        {
            isTakingDamage = true;
            StartCoroutine(RestoreHealthCoroutine());
        }

        if (_currentHealth == 0)
        {
            Die();
        }
    }


    private void Die()
    {
        _animator.SetBool("IsDead", true);

        if (gameObject != null)
        {
            _animator.SetTrigger("IsDead");
            Destroy(gameObject, 5);
        }

        AddScore(5);

        StartCoroutine(LoadMainMenuAfterDelay(2f));
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void AddScore(int points)
    {
        _score += points;
    }

    IEnumerator RestoreHealthCoroutine()
    {
        while (Time.time - _lastDamageTime < 5f)
        {
            yield return null;
        }

        float elapsedTime = 0f;

        while (_currentHealth < _maxHealth)
        {
            yield return null;
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= _restoreHealthInterval)
            {
                _currentHealth++;
                elapsedTime = 0f;
            }
        }

        isTakingDamage = false;
    }

    IEnumerator LoadMainMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}