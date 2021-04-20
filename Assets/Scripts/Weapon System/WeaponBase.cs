using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    [SerializeField] private float _attackDelay = .25f;
    [SerializeField] private BaseAttackModeHandler _attackModeHandler = null;
    [SerializeField] private BaseAttackHandler _attackHandler = null;
    [SerializeField] private BaseAmmoHandler _ammoHandler = null;
    [SerializeField] private BaseEventHandler _weaponEvents = null;

    private Timer _nextAttackTimer;

    private void Awake()
    {
        _attackModeHandler.OnExecution += _attackHandler.Attack;
        _attackModeHandler.OnExecution += _ammoHandler.ConsumeAmmo;
        _attackModeHandler.OnExecution += InvokeWeaponEvents;
    }

    private void Start()
    {
        _nextAttackTimer = new Timer(_attackDelay);
    }

    private void Update()
    {
        _nextAttackTimer.Tick();
    }

    public void UseWeapon()
    {
        if (_ammoHandler.CheckAmmo())
        {
            if (_nextAttackTimer.Elapsed)
            {
                _attackModeHandler.Execute();
                _nextAttackTimer.Reset();
            }
        }
    }

    public void ReloadWeapon()
    {
        _ammoHandler.Reload();
    }

    private void InvokeWeaponEvents()
    {
        _weaponEvents.InvokeEvents(gameObject);
    }
}
