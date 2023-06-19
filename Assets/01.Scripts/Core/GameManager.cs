using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private PoolingListSO _poolingList;
    public List<Transform> _spawnPointList = new List<Transform>();

    private void Awake()
    {
        if (Instance != null) Debug.LogError("Multiple GameManager is running!");
        
        Instance = this;

        MakePool();
    }

    private void MakePool()
    {
        PoolManager.Instance = new PoolManager(transform);

        _poolingList.PoolList.ForEach(p => PoolManager.Instance.CreatePool(p.Prefab, p.Count));

        _spawnPointList = new List<Transform>();
    }
}
