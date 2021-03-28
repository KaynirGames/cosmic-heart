using UnityEngine;

public class WeaponBase : MonoBehaviour, IIdentifiable
{
    [SerializeField] private float _attackDelay = .25f;
    [SerializeField] private string _weaponID = "DefaultWeapon";
    [SerializeField] private BaseAttackModeHandler _attackModeHandler = null;
    [SerializeField] private BaseAttackHandler _attackHandler = null;
    [SerializeField] private BaseAmmoHandler _ammoHandler = null;
    [SerializeField] private EffectSystem _weaponEffects = null;

    private Timer _nextAttackTimer;

    public string ID => _weaponID;

    private void Awake()
    {
        _attackModeHandler.OnExecution += _attackHandler.Attack;
        _attackModeHandler.OnExecution += _ammoHandler.ConsumeAmmo;
        _attackModeHandler.OnExecution += PlayWeaponEffects;
    }

    private void Start()
    {
        _nextAttackTimer = new Timer(_attackDelay);
    }

    private void Update()
    {
        _nextAttackTimer.Tick();
    }

    public void ActivateWeapon()
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

    private void PlayWeaponEffects()
    {
        _weaponEffects.ActivateEffects(gameObject);
    }
}
