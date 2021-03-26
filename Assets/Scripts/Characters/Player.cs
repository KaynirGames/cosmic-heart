using UnityEngine;

public class Player : Character
{
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

        HandleMove(_moveInput.GetDirection());
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
            _weaponSelector.UseCurrentWeapon();
        }
    }
}