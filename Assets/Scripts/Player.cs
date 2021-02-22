using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform[] _firePoints = null;
    [SerializeField] private int _selectedWeapon = 0;

    private IMoveHandler _moveHandler;
    private IMoveInputHandler _moveInputHandler;

    private ActionInputBase _attackInput;
    private CharacterStats _playerStats;
    private Animator _animator;

    private IShooter[] _weapons;

    private void Awake()
    {
        _moveHandler = GetComponent<IMoveHandler>();
        _moveInputHandler = GetComponent<IMoveInputHandler>();
        _weapons = GetComponentsInChildren<IShooter>();
        _attackInput = GetComponent<ActionInputBase>();
        _playerStats = GetComponent<CharacterStats>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        _moveHandler.SetMoveSpeed(_playerStats.MoveSpeed);
        SetWeapon(0);
    }

    private void Update()
    {
        HandleAttack();
        HandleMove();
    }

    public void SetWeapon(int weaponID)
    {
        _selectedWeapon = weaponID;
        _weapons[weaponID].SetFirePoints(_firePoints);
    }

    private void HandleAttack()
    {
        if (_attackInput.GetInputHold())
        {
            _weapons[_selectedWeapon].Attack();
        }
    }

    private void HandleMove()
    {
        Vector3 direction = _moveInputHandler.GetDirection();
        _moveHandler.SetMoveDirection(direction);
        _animator.SetFloat("Horizontal", direction.x);
    }
}