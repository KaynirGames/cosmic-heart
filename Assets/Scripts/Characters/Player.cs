using UnityEngine;

public class Player : Character
{
    private IMoveHandler _moveHandler;
    private IMoveInputHandler _moveInputHandler;
    private IActionInputHandler _attackInputHandler;

    private Animator _animator;

    private WeaponSelector _weaponSelector;

    protected override void Awake()
    {
        base.Awake();

        _moveHandler = GetComponent<IMoveHandler>();
        _moveInputHandler = GetComponent<IMoveInputHandler>();
        _weaponSelector = GetComponent<WeaponSelector>();
        _attackInputHandler = GetComponent<IActionInputHandler>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        _moveHandler.SetMoveSpeed(Stats.MoveSpeed);
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