using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Character2DController _controller;
    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _controller = GetComponent<Character2DController>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
        
    }
    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }

    private void Move(Vector2 direction)
    {
        _movementDirection = direction;        
    }
    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5;
        _rigidbody.velocity = direction;
    }
}
