using UnityEngine;

public class Weapon : MonoBehaviour, IIdentifiable
{
    [SerializeField] private float _attackDelay = .5f;
    [SerializeField] private string _weaponID = string.Empty;
    [SerializeField] private EffectSystem _weaponEffects = null;

    private IAttackHandler _attackHandler;
    private IReloadHandler _reloadHandler;

    private Timer _attackTimer;

    public string ID => _weaponID;

    private void Awake()
    {
        _attackHandler = GetComponent<IAttackHandler>();
        _reloadHandler = GetComponent<IReloadHandler>();

        if (_reloadHandler == null)
        {
            _reloadHandler = new DefaultReload();
        }
    }

    private void Start()
    {
        _attackTimer = new Timer(_attackDelay);
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
            _weaponEffects.ActivateEffects(gameObject);
            _attackTimer.Reset();
        }
    }

    public void Reload()
    {
        _reloadHandler.Reload();
    }
}
