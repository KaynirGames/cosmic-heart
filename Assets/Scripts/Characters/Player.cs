using UnityEngine;

public class Player : Character
{
    [SerializeField] private BaseMovement _movement = null;

    private IMoveInputHandler _moveInputHandler;
    private IActionInputHandler _attackInputHandler;

    private WeaponSystem _weaponSelector;

    protected override void Awake()
    {
        base.Awake();

        _moveInputHandler = GetComponent<IMoveInputHandler>();
        _weaponSelector = GetComponent<WeaponSystem>();
        _attackInputHandler = GetComponent<IActionInputHandler>();
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

        _movement.Move(direction.normalized
                       * _stats.MoveSpeed.GetValue()
                       * Time.deltaTime);
        
        Animator.SetFloat("Horizontal", direction.x);
    }
}