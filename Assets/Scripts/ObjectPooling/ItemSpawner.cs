using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemSpawner : MonoBehaviour
{
    private float _nextSpawnTime;

    private void Start()
    {
        _nextSpawnTime = NextSpawnTime();
    }
    
    void FixedUpdate()
    {
        ObjectPoolingManager manager = ObjectPoolingManager.SharedInstance;
        
        _nextSpawnTime -= Time.deltaTime;
        if (_nextSpawnTime < 0)
        {
            GameObject thisItem = manager.GetFromPool("Item");
            Spawn(thisItem);
            _nextSpawnTime = NextSpawnTime();
        }
    }

    private void Spawn(GameObject paramItem)
    {
        paramItem.SetActive(true);
        Item thisItem = paramItem.GetComponent<Item>();
        thisItem.SetPosition();
        thisItem.SetGravityScale();
    }

    private float NextSpawnTime()
    {
        return Random.Range(7.0f, 10.0f);
    }
}
