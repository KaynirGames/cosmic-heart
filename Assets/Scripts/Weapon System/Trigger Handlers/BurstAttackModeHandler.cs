using System.Collections;
using UnityEngine;

public class BurstAttackModeHandler : BaseAttackModeHandler
{
    public override event OnAttackModeExecution OnExecution = delegate { };

    [SerializeField] private int _burstSize = 1;
    [SerializeField] private float _burstInterval = .5f;

    private bool _isBursting;
    private WaitForSeconds _waitForBurstInterval;

    private void Start()
    {
        _waitForBurstInterval = new WaitForSeconds(_burstInterval);
    }

    public override void Execute()
    {
        if (_isBursting)
        {
            return;
        }

        StartCoroutine(BurstAttackRoutine());
    }

    private IEnumerator BurstAttackRoutine()
    {
        _isBursting = true;

        for (int i = 0; i < _burstSize; i++)
        {
            OnExecution.Invoke();
            yield return _waitForBurstInterval;
        }

        _isBursting = false;
    }
}
