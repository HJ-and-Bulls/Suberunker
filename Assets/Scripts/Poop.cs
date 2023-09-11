using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Poop : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    // private int _level;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        // _level = 1; // 1~9 라는 가정 하에! 나중에 그 이상도 핸들링?
    }

    void Start()
    {
        SetPosition();
    }

    public void SetPosition()
    {
        float halfX = Constants.UnitWidth / 2;
        float halfY = Constants.UnitHeight / 2;
        float poopPositionY = Constants.PoopHeight / 2;

        Vector2 defaultPosition = new Vector2(Random.Range(-halfX, halfX), halfY + poopPositionY);
        this.transform.position = defaultPosition;
    }

    public void SetGravityScale()
    {
        _rigidbody2D.gravityScale = Random.Range(1.0f, 1.5f);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            this.gameObject.SetActive(false); // 1. 옵젝풀로 반환해야 함
            // 2. 점수 오름
        }
    }
}