using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]private float _speed = 100;
    [SerializeField]public int _damage = 20;
    public Vector3 Target;

    private void Update()
    {
        float step = _speed * Time.deltaTime;
        if (Target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target, step);
        }
    }

    public void setTarget(Vector3 target)
    {
        Target = target;
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyContoler enemy = collision.gameObject.GetComponent<EnemyContoler>();
        if (enemy != null)
        {
            enemy.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}