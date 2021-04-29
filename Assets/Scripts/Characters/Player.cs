using UnityEngine;

public class Player : Character
{
    [SerializeField] private BaseActionInput _attackInput = null;
    [SerializeField] private InvincibilityFrames _invincibilityFrames = null;

    private WeaponSystem _weaponSystem;
    private IDirectionHandler _directionHandler;

    protected override void Awake()
    {
        base.Awake();

        _directionHandler = GetComponent<IDirectionHandler>();
        _weaponSystem = GetComponent<WeaponSystem>();

        _stats.OnDamageTaken += HandleInvincibilityFrames;
    }

    private void Update()
    {
        HandleAttack();
        HandleMoveAnimation();
    }

    protected void HandleMoveAnimation()
    {
        Animator.SetFloat("Horizontal",
                          _directionHandler.GetDirection().x);
    }

    private void HandleAttack()
    {
        if (_attackInput.GetInputHold())
        {
            _weaponSystem.UseCurrentWeapon();
        }
    }

    private void HandleInvincibilityFrames()
    {
        _invincibilityFrames.Activate();
    }

    protected override void Die()
    {
        Debug.Log("Player is dead!");
        _stats.OnDamageTaken -= HandleInvincibilityFrames;
        base.Die();
    }
}