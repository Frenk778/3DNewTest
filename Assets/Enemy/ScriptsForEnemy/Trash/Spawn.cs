//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Spawn : MonoBehaviour
//{
//    [SerializeField] private Transform[] _patrolPoints;
//    [SerializeField] private GameObject _spawnPoint;
//    [SerializeField] private GameObject _objetToSpawn;

//    private int[] _enemiesSpawnedPerSpawnPoint;
//    private int _enemiesToSpawn = 3;
//    private int _enemiesSpawned = 0;
//    private int _enemiesKilled = 0;
//    private float _spawnDelay = 3.0f;


//    IEnumerator Start()
//    {
//        while (_enemiesSpawned < _enemiesToSpawn)
//        {
//            yield return new WaitForSeconds(_spawnDelay);

//            if (_objetToSpawn != null)
//            {
//                Instantiate(_objetToSpawn, _spawnPoint.transform.position, Quaternion.identity);
//                _enemiesSpawned++;
//            }
//            else
//            {
//                Debug.LogError("Object to spawn is not set!");
//            }
//        }
//    }

//    public void AllEnemiesKilled()
//    {
//        GameObject door = GameObject.Find("Door");
//        door.GetComponent<Door>().OpenDoor();
//    }


//    public void EnemyKilled(Transform spawnPoint)
//    {
//        _enemiesKilled++;

//        for (int i = 0; i < _patrolPoints.Length; i++)
//        {
//            if (_patrolPoints[i] == spawnPoint)
//            {
//                _enemiesSpawnedPerSpawnPoint[i]--;
//                break;
//            }
//        }

//        if (_enemiesKilled >= _enemiesToSpawn)
//        {
//            GameObject door = GameObject.Find("Door");
//            door.GetComponent<Door>().OpenDoor();
//        }
//    }
//}
