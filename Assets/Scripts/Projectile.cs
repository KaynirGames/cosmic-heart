using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;

    private IMoveHandler _moveHandler;

    private void Awake()
    {
        _moveHandler = GetComponent<IMoveHandler>();
    }

    private void Start()
    {
        _moveHandler.SetMoveSpeed(_speed);
        //_moveHandler.SetMoveDirection(Vector3.up);
    }
}
