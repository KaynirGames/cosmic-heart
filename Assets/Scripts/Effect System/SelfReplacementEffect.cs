using UnityEngine;

public class SelfReplacementEffect : BaseEffect
{
    [SerializeField] private GameObject _replacementPrefab = null;

    public override void Activate(GameObject target)
    {
        if (_replacementPrefab != null)
        {
            Instantiate(_replacementPrefab,
                        transform.position,
                        Quaternion.identity);
        }

        gameObject.Dispose();
    }
}
