using UnityEngine;

public class Player : MonoBehaviour
{
    private IMoveHandler _moveHandler;
    private IMoveInputHandler _moveInputHandler;
    private IAttackHandler _attackHandler;

    private ActionInputBase _attackInput;

    private Timer _nextAttackTimer;

    private void Awake()
    {
        _moveHandler = GetComponent<IMoveHandler>();
        _moveInputHandler = GetComponent<IMoveInputHandler>();
        _attackHandler = GetComponent<IAttackHandler>();
        _attackInput = GetComponent<ActionInputBase>();
    }

    private void Start()
    {
        _nextAttackTimer = new Timer(1.5f);
    }

    private void Update()
    {
        HandleAttack();
        HandleMove();
    }

    private void HandleAttack()
    {
        //if (_attackInput.GetInputHold())
        //{
        //    _attackHandler.Attack();
        //    _nextAttackTimer.Reset();
        //}
        //else
        //{
        //    _nextAttackTimer.Tick(Time.deltaTime);
        //}

        if (_attackInput.GetInputHold())
        {
            _attackHandler.Attack();
        }
    }

    private void HandleMove()
    {
        _moveHandler.SetMoveDirection(_moveInputHandler.GetDirection());
    }
}