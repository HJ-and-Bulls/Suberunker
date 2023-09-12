using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Media;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInput _playerInput;
    private BoxCollider2D _boxCollider;
    
    public event Action<bool> OnShieldChange;
    public event Action OnHit;
    public event Action OnDead;

    private bool _isShieldOn = false;
    public bool IsShieldOn
    {
        get { return _isShieldOn; }
        set
        {
            _isShieldOn = value;
            OnShieldChange?.Invoke(value);
        }
    }

    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    void Start()
    {
        OnHit += HitCallback;
        OnDead += DeadCallback;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Poop"))
        {
            OnHit?.Invoke();
        }
    }

    private void HitCallback()
    {
        if (IsShieldOn) IsShieldOn = false;
        else OnDead?.Invoke();
    }

    private void DeadCallback()
    {
        _boxCollider.enabled = false;
        _playerInput.enabled = false;
    }
    //메롱
}
