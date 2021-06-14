using UnityEngine;

public class IntVariableGameObjectDisplay : IntVariableBaseDisplay
{
    [SerializeField] private GameObject[] _displayedObjects = null;
    [SerializeField] private IntReference _maxObjectAmount = null;

    protected override void UpdateDisplayValue(int value)
    {
        int objectAmount = Mathf.Clamp(value, 0, _maxObjectAmount.Value);

        for (int i = 0; i < _displayedObjects.Length; i++)
        {
            _displayedObjects[i].SetActive(i < objectAmount);
        }
    }
}
