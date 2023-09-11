using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Poop : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private int _level;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _level = 1; // 1~9 라는 가정 하에! 나중에 그 이상도 핸들링?
    }

    void Start()
    {
        SetPosition();
    }

    public void SetPosition()
    {
        Vector2 defaultPosition = new Vector2(Random.Range(-2.6f, 2.6f), 5.5f);
        this.transform.position = defaultPosition;
    }

    public void SetGravityScale()
    {
        _rigidbody2D.gravityScale = Random.Range(1.0f + (0.1f * _level), 1.0f + (0.2f * _level));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            // 바닥 충돌 이벤트 호출
            // 1. 옵젝풀로 반환해야 함
            this.gameObject.SetActive(false);
            // 2. 점수 오름
        }
        else if (other.gameObject.tag == "Player")
        {
            // 플레이어 충돌 이벤트 호출
            // 1. 게임 시간 정지
            // 2. 게임 오버
        }
    }
}