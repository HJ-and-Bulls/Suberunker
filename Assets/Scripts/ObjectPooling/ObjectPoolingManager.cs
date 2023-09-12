using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class PoolInfo
{
    public GameObject pooledObject; // Dictionary의 Key(Name) 역할
    public int capacity;
}

public class ObjectPoolingManager : MonoBehaviour
{
    public static ObjectPoolingManager SharedInstance; // 싱글톤
    public Dictionary<string, List<GameObject>> Pools;
    [SerializeField] List<PoolInfo> poolInfoList;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        this.Pools = new Dictionary<string, List<GameObject>>();
        
        PoolInfo poolInfo;
        for (int i = 0; i < poolInfoList.Count; i++)
        {
            poolInfo = poolInfoList[i];
            Pools.Add(poolInfo.pooledObject.name, new List<GameObject>());
            FillPool(poolInfo.pooledObject, poolInfo.capacity);
        }
    }

    private void FillPool(GameObject gameObject, int capacity)
    {
        List<GameObject> pool = Pools[gameObject.name];

        for (int i = 0; i < capacity; i++)
        {
            GameObject newObject = Instantiate(gameObject);
            newObject.SetActive(false);
            pool.Add(newObject);
        }
    }
    
    public GameObject GetFromPool(string name)
    {
        List<GameObject> pool;
        PoolInfo poolInfo;
        
        if (Pools.TryGetValue(name, out pool))
        {
            poolInfo = poolInfoList.Find(info => info.pooledObject.name == name);
            for (int i = 0; i < poolInfo.capacity; i++)
            {
                if (pool[i].activeInHierarchy == false)
                {
                    return pool[i];
                }
            }
        }

        return null;
    }
}
