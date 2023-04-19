using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform[] patrolPoints;
    public GameObject spawnPoint;
    public GameObject objetToSpawn;
    public float spawnDelay = 3.0f;
    //public float moveSpeed = 30.0f;
    //public float rotateSpeed = 30.0f;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            Instantiate(objetToSpawn, spawnPoint.transform.position, Quaternion.identity);
        }
    }
}
