using UnityEngine;

public class ReplaceObjectEffect : MonoBehaviour, ISpecialEffect
{
    [SerializeField] private GameObject _replacementPrefab = null;

    public void Play(GameObject target)
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
