using UnityEngine;

public class Player : Character
{
    [SerializeField] private BaseMovement _movement = null;
    [SerializeField] private BaseMovementInput _movementInput = null;
    [SerializeField] private BaseActionInput _attackInput = null;

    private WeaponSystem _weaponSelector;

    protected override void Awake()
    {
        base.Awake();

        _weaponSelector = GetComponent<WeaponSystem>();
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
            _weaponSelector.UseCurrentWeapon();
        }
    }

    private void HandleMove()
    {
        Vector3 direction = _movementInput.GetDirection();

        _movement.Move(direction.normalized
                       * _stats.MoveSpeed.GetValue()
                       * Time.deltaTime);
        
        Animator.SetFloat("Horizontal", direction.x);
    }
}