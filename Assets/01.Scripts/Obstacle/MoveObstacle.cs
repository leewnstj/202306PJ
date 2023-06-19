using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ObstacleType
{ 
    MoveObstacle
}

public class MoveObstacle : MonoBehaviour
{
    [SerializeField] private ObstacleType obstacleType;
    [SerializeField] private Vector3 dir;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _waitTime;

    private void Start()
    {
        StartCoroutine(UpandDown());
    }

    private void Update()
    {
        if(obstacleType == ObstacleType.MoveObstacle)
        {
            StateMove();
        }
    }

    private void StateMove()
    {
        transform.position += dir * Time.deltaTime * _moveSpeed;
    }

    IEnumerator UpandDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(_waitTime);
            dir = -dir;
            yield return new WaitForSeconds(_waitTime);
        }
    }
}
