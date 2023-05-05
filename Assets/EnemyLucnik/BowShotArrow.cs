using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowShotArrow : MonoBehaviour
{
    [SerializeField] private Transform _arrowSpawnPosition;
    [SerializeField] private ArrowArissa _arrowPrefab;
    [SerializeField] private Transform _handArrow;

    [SerializeField] private int _arrowSpeed = 100;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _attackCooldown = 10f;

    private Transform _player;
    private bool _isAttackReady = true;
    private float _range = 10f;
    private float _destroyTime = 1f;

    private void Start()
    {
        _player = EnemyController.Instance.GetPlayer()?.transform;
    }

    private void Update()
    {
        if (_player == null)
            return;

        float distance = Vector3.Distance(transform.position, _player.position);

        if (distance <= _range && _isAttackReady)
        {
            _isAttackReady = false;
            StartCoroutine(ResetAttackCooldown());
            if (_player.GetComponent<Player>() != null)
            {
                _player.GetComponent<Player>().TakeDamage(_damage);
            }
        }
    }


    private void Shoot()
    {
        _handArrow.gameObject.SetActive(false);

        RaycastHit[] hits = Physics.RaycastAll(transform.position, (_player.position - transform.position).normalized, _range);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.gameObject.TryGetComponent(out Player player))
            {
                // ѕровер€ем, находитс€ ли игрок на переднем плане от стены
                if (Vector3.Dot(hit.normal, (_player.position - hit.point).normalized) > 0)
                {
                    player.TakeDamage(_damage);
                }
            }
            else if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Wall"))
            {
                // ≈сли луч попал в стену, то прекращаем проверку
                break;
            }
        }

        ArrowArissa arrow = Instantiate(_arrowPrefab, _arrowSpawnPosition.transform.position, _arrowSpawnPosition.transform.rotation);
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();
        arrowRigidbody.velocity = (_player.position - transform.position).normalized * _arrowSpeed;

        StartCoroutine(DestroyArrow(arrow.gameObject));

        _handArrow.gameObject.SetActive(true);
    }


    //private void Shoot()
    //{
    //    _handArrow.gameObject.SetActive(false);

    //    RaycastHit hit;

    //    if (Physics.Raycast(transform.position, (_player.position - transform.position).normalized, out hit, _range))
    //    {
    //        if (hit.collider.gameObject.TryGetComponent(out Player player))
    //        {
    //            player.TakeDamage(_damage);
    //        }
    //    }

    //    ArrowArissa arrow = Instantiate(_arrowPrefab, _arrowSpawnPosition.transform.position, _arrowSpawnPosition.transform.rotation);
    //    Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();
    //    arrowRigidbody.velocity = (_player.position - transform.position).normalized * _arrowSpeed;

    //    StartCoroutine(DestroyArrow(arrow.gameObject));

    //    _handArrow.gameObject.SetActive(true);
    //}

    private IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(_attackCooldown);
        _isAttackReady = true;
    }

    private IEnumerator DestroyArrow(GameObject arrow)
    {
        yield return new WaitForSeconds(_destroyTime);
        Destroy(arrow);
    }
}