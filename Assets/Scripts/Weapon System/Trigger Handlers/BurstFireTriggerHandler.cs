using System.Collections;
using UnityEngine;

public class BurstFireTriggerHandler : BaseTriggerHandler
{
    public override event OnTriggerAttack OnTrigger = delegate { };

    [SerializeField] private int _burstSize = 1;
    [SerializeField] private float _burstInterval = .5f;

    private bool _isBursting;
    private WaitForSeconds _waitForBurstInterval;

    private void Start()
    {
        _waitForBurstInterval = new WaitForSeconds(_burstInterval);
    }

    public override bool TriggerAttack()
    {
        if (_isBursting)
        {
            return false;
        }

        StartCoroutine(BurstFireRoutine());

        return true;
    }

    private IEnumerator BurstFireRoutine()
    {
        _isBursting = true;

        for (int i = 0; i < _burstSize; i++)
        {
            OnTrigger.Invoke();
            yield return _waitForBurstInterval;
        }

        _isBursting = false;
    }
}
