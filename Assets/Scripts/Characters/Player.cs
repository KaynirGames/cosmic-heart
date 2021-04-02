using UnityEngine;

public class Player : Character
{
    [SerializeField] private BaseActionInput _attackInput = null;

    private WeaponSystem _weaponSystem;

    protected override void Awake()
    {
        base.Awake();

        _weaponSystem = GetComponent<WeaponSystem>();
    }

    private void Update()
    {
        HandleAttack();

        HandleMove(_moveInput.GetMoveInput());
    }

    protected override void HandleMove(Vector3 direction)
    {
        base.HandleMove(direction);

        Animator.SetFloat("Horizontal", direction.x);
    }

    private void HandleAttack()
    {
        if (_attackInput.GetInputHold())
        {
            _weaponSystem.UseCurrentWeapon();
        }
    }
}