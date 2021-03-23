using UnityEngine;

public class WeaponBase : MonoBehaviour, IIdentifiable
{
    [SerializeField] private float _attackDelay = .25f;
    [SerializeField] private string _weaponID = "DefaultWeapon";
    [SerializeField] private BaseTriggerHandler _triggerHandler = null;
    [SerializeField] private BaseAttackHandler _attackHandler = null;
    [SerializeField] private BaseAmmoHandler _ammoHandler = null;
    [SerializeField] private EffectSystem _weaponEffects = null;

    private Timer _nextAttackTimer;

    public string ID => _weaponID;

    private void Awake()
    {
        _triggerHandler.OnTrigger += _attackHandler.Attack;
        _triggerHandler.OnTrigger += _ammoHandler.ConsumeAmmo;
        _triggerHandler.OnTrigger += PlayWeaponEffects;
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
                _triggerHandler.TriggerAttack();
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
