using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class AnimationController : MonoBehaviour
{
    private Character2DController _controller;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Player _player;

    private void Awake()
    {
        _controller = GetComponent<Character2DController>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _player = GetComponent<Player>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _controller.OnMoveEvent += FilpX;
        _player.OnDead += SetAnimationDie;
    }
    
    private void SetAnimationDie()
    {
        _animator.SetBool("Die", true);
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
