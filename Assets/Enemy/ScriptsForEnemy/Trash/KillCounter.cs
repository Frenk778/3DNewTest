//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class KillCounter : MonoBehaviour
//{
//    [SerializeField] private Animator _doorAnimator;

//    private int killCount = 0;
//    private int requiredKills = 15;


//    public void OnEnemyKilled()
//    {
//        killCount++;
//        if (killCount >= requiredKills)
//        {
//            OpenDoor();
//        }
//    }


//    private void OpenDoor()
//    {
//        _doorAnimator.SetBool(Animator.StringToHash("isOpen"), true);
//        _doorAnimator.enabled = true;
//    }
//}
