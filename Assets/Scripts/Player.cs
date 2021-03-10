using UnityEngine;

public class Player : MonoBehaviour
{
    private IMoveHandler _moveHandler;
    private IMoveInputHandler _moveInputHandler;
    private IActionInputHandler _attackInputHandler;

    private CharacterStats _playerStats;
    private Animator _animator;

    private WeaponSelector _weaponSelector;

    private void Awake()
    {
        _moveHandler = GetComponent<IMoveHandler>();
        _moveInputHandler = GetComponent<IMoveInputHandler>();
        _weaponSelector = GetComponent<WeaponSelector>();
        _attackInputHandler = GetComponent<IActionInputHandler>();
        _playerStats = GetComponent<CharacterStats>();
        _animator = GetComponentInChildren<Animator>();
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
        if (_attackInputHandler.GetInputHold())
        {
            _weaponSelector.CurrentWeapon.Attack();
        }
    }

    private void HandleMove()
    {
        Vector3 direction = _moveInputHandler.GetDirection();
        _moveHandler.Move(direction.normalized);
        _animator.SetFloat("Horizontal", direction.x);
    }
}