using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{ 
    [SerializeField] private int score = 0;
    [SerializeField] private float restoreHealthInterval = 1.5f;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private Slider _healthBar;

    private bool isTakingDamage = false;
    private float _lastDamageTime;
    private bool isAlive = true;
    private int currentHealth;
    private Animator _animator;

    private void Start()
    {
        currentHealth = maxHealth;
        _animator = GetComponent<Animator>();
        isAlive = true;
    }

    private void Update()
    {
        _healthBar.value = currentHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyContoler enemy = other.GetComponent<EnemyContoler>();
            if (enemy != null)
            {
                TakeDamage(enemy.damage);
            }
        }
    }

    IEnumerator RestoreHealthCoroutine()
    {
        while (Time.time - _lastDamageTime < 5f)
        {
            yield return null;
        }

        float elapsedTime = 0f;

        while (currentHealth < maxHealth)
        {
            yield return null;
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= restoreHealthInterval)
            {
                currentHealth++;
                elapsedTime = 0f;
            }
        }

        isTakingDamage = false;
    }

    public void TakeDamage(int damage)
    {
        if (!isAlive)
        {
            return;
        }

        currentHealth -= damage;

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        _lastDamageTime = Time.time;

        if (!isTakingDamage)
        {
            isTakingDamage = true;
            StartCoroutine(RestoreHealthCoroutine());
        }

        if (currentHealth == 0)
        {
            Die();
        }
    }

    void Die()
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

    IEnumerator LoadMainMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void AddScore(int points)
    {
        score += points;
    }
}