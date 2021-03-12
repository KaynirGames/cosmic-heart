using UnityEngine;

[RequireComponent(typeof(SpecialEffectMaster))]
public class Weapon : MonoBehaviour, IIdentifiable
{
    [SerializeField] private float _attackCooldown = 0f;
    [SerializeField] private string _weaponID = string.Empty;

    private IAttackHandler _attackHandler;
    private IReloadHandler _reloadHandler;

    private SpecialEffectMaster _effectMaster;
    private Timer _attackTimer;

    public string ID => _weaponID;

    private void Awake()
    {
        _attackHandler = GetComponent<IAttackHandler>();
        _reloadHandler = GetComponent<IReloadHandler>();
        _effectMaster = GetComponent<SpecialEffectMaster>();

        if (_reloadHandler == null)
        {
            _reloadHandler = new DefaultReload();
        }
    }

    private void Start()
    {
        _attackTimer = new Timer(_attackCooldown);
    }

    private void Update()
    {
        _attackTimer.Tick();
    }

    public void Attack()
    {
        if (_attackTimer.Elapsed && _reloadHandler.CheckAmmo())
        {
            _attackHandler.Attack();
            _effectMaster.CreateEffects(gameObject);
            _attackTimer.Reset();
        }
    }

    public void Reload()
    {
        _reloadHandler.Reload();
    }
}
