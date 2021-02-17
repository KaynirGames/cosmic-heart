using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform[] _firePoints = null;
    [SerializeField] private int _selectedWeapon = 0;

    private IMoveHandler _moveHandler;
    private IMoveInputHandler _moveInputHandler;

    private ActionInputBase _attackInput;
    private CharacterStats _playerStats;

    private IShooter[] _weapons;

    private void Awake()
    {
        _moveHandler = GetComponent<IMoveHandler>();
        _moveInputHandler = GetComponent<IMoveInputHandler>();
        _weapons = GetComponentsInChildren<IShooter>();
        _attackInput = GetComponent<ActionInputBase>();
        _playerStats = GetComponent<CharacterStats>();
    }

    private void Start()
    {
        _moveHandler.SetMoveSpeed(_playerStats.MoveSpeed);
    }

    private void Update()
    {
        HandleAttack();
        HandleMove();
    }

    private void HandleAttack()
    {
        if (_attackInput.GetInputHold())
        {
            _weapons[_selectedWeapon].Attack();
        }
    }

    private void HandleMove()
    {
        _moveHandler.SetMoveDirection(_moveInputHandler.GetDirection());
    }
}