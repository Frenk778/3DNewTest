using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector3 Target;
    public float Speed = 100;
    public int Damage = 20;

    private void Update()
    {
        float step = Speed * Time.deltaTime;
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
            enemy.TakeDamage(Damage);
        }

        Destroy(gameObject);
    }
}