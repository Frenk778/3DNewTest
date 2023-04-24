using System.Collections;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 10;
    [SerializeField] private float _damageInterval = 0.0f;

    private bool _canDamage = true;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null && _canDamage)
        {
            player.TakeDamage(_damageAmount);
            StartCoroutine(DamageCooldown());
        }
    }

    IEnumerator DamageCooldown()
    {
        _canDamage = false;
        yield return new WaitForSeconds(_damageInterval);
        _canDamage = true;
    }
}
