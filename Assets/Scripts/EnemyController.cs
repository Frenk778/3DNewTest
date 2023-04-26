using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Score _scoreScript;   
    [SerializeField] private Transform _pointsObject;
    [SerializeField] private Transform _pointsObjectOne;
    [SerializeField] private Transform _pointsObjectTwo;
    [SerializeField] private Transform _pointsObjectThree;

    private Player _player;
    private static EnemyController _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        _player = Player.Instance;
    }

    public static EnemyController Instance => _instance;

    public Score GetScoreScript() => _scoreScript;

    public Player GetPlayer() => _player;    

    public Transform GetPlayerTransform() => _player.transform;

    public Transform PointsObject => _pointsObject;    

    public Transform PointsObjectOne => _pointsObjectOne;    

    public Transform PointsObjectTwo => _pointsObjectTwo;    
        
    public Transform PointsObjectThree => _pointsObjectThree;
}