using UnityEngine;

public class Player : Character
{
    private IMoveHandler _moveHandler;
    private IMoveInputHandler _moveInputHandler;
    private IActionInputHandler _attackInputHandler;

    private WeaponSystem _weaponSelector;

    protected override void Awake()
    {
        base.Awake();

        _moveHandler = GetComponent<IMoveHandler>();
        _moveInputHandler = GetComponent<IMoveInputHandler>();
        _weaponSelector = GetComponent<WeaponSystem>();
        _attackInputHandler = GetComponent<IActionInputHandler>();
    }

    private void Start()
    {
        _moveHandler.SetMoveSpeed(Stats.MoveSpeed.GetValue());
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
        Animator.SetFloat("Horizontal", direction.x);
    }
}