using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<Transform> SpawnPos = new List<Transform>();

    public float SpawnCoolTime = 10f;
    private float currentCoolTime;

    public Transform SpawnPosition;

    private void Start()
    {
        currentCoolTime = SpawnCoolTime;
    }

    private void Update()
    {
        currentCoolTime -= Time.deltaTime;
        if(currentCoolTime < 0)
        {
            int i = Random.Range(0, SpawnPos.Count);
            var enemy = PoolManager.Instance.Pop("Enemy");
            enemy.transform.position = SpawnPos[i].position;
            currentCoolTime = SpawnCoolTime;
        }
    }
}
