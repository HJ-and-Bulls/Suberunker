using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoopSpawner : MonoBehaviour
{
    private float _nextSpawnTime;
    private float _difficulty;
    
    void Start()
    {
        _difficulty = StartManager.Instance.IsHard ? 2f : 1f;
        _nextSpawnTime = NextSpawnTime();
    }

    void FixedUpdate()
    {
        ObjectPoolingManager manager = ObjectPoolingManager.SharedInstance;
        
        _nextSpawnTime -= Time.deltaTime;
        if (_nextSpawnTime < 0)
        {
            GameObject thisPoop = manager.GetFromPool("Poop");
            Spawn(thisPoop);
            _nextSpawnTime = NextSpawnTime();
        }
    }

    private void Spawn(GameObject thisPoop)
    {
        thisPoop.SetActive(true);
        Poop param = thisPoop.GetComponent<Poop>();
        param.SetPosition();
        param.SetGravityScale();
    }
    private float NextSpawnTime()
    {
        float time = GameManager.Instance.GameTime;
        return Random.Range(0.5f, 1.0f) * (1f / (1f + (time / 60f))) / _difficulty;
    }
}