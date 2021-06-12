﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MoveThruster2D : BaseMoveHandler
{
    [SerializeField] private float _rotationSpeed = 100f;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody2D.AddForce(GetVelocity());

        Rotate();
    }

    private void Rotate()
    {
        float cross = Vector3.Cross(_direction, transform.up).z;
        float rotation = cross * _rotationSpeed * Time.deltaTime;

        _rigidbody2D.AddTorque(-rotation);
    }
}