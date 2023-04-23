using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    public Transform[] patrolPoints;


    void Awake()
    {

        patrolPoints = GetComponentsInChildren<Transform>();
        //patrolPoints = GetComponentsInChildren<Transform>();
        //List<Transform> tempList = new List<Transform>();

        //foreach (Transform child in transform)
        //{
        //    tempList.Add(child);
        //}

        //patrolPoints = tempList.ToArray();
    }
}
