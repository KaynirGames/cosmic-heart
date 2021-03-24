using UnityEngine;

public class Player : Character
{
    [SerializeField] private BaseMoveInput _moveInput = null;
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
        Vector3 direction = _moveInput.GetDirection();

        _baseMove.SetVelocity(direction.normalized
                              * _stats.MoveSpeed.GetValue()
                              * Time.deltaTime);
        
        Animator.SetFloat("Horizontal", direction.x);
    }
}