using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 10; 
    [SerializeField] private float _damageInterval = 0.0f;
    private bool canDamage = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null && canDamage)
            {
                player.TakeDamage(_damageAmount);
                StartCoroutine(DamageCooldown());
            }
        }
    }

    IEnumerator DamageCooldown()
    {
        canDamage = false;
        yield return new WaitForSeconds(_damageInterval);
        canDamage = true;
    }
}
