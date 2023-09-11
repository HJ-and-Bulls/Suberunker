using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class AnimationController : MonoBehaviour
{
    private CharacterController _controller;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }
    // Die 애니메이션 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("poop"))
        {
            _animator.SetBool("Die", true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _controller.OnMoveEvent += FilpX;
    }
    // 좌우 반전 
    private void FilpX(Vector2 direction)
    {
        if (direction.x != 0)
        {
            _spriteRenderer.flipX = direction.x < 0;
            _animator.SetBool("IsMove", true);// 달리는 애니메이션
        }
        else
        {
            _animator.SetBool("IsMove", false);
        }

    }
}
