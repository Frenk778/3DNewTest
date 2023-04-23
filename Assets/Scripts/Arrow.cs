using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speed = 100f;
    [SerializeField] private int _damage = 50;
    [SerializeField] private Vector3 _target;

    public int Damage => _damage;

    private void Update()
    {
        float step = _speed * Time.deltaTime;

        if (_target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, step);
        }
    }

    public void SetTarget(Vector3 target)
    {
        _target = target;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}