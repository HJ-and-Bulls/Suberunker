using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Item : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
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
        _rigidbody2D.gravityScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
