using UnityEngine;

public class CollisionReplacement : MonoBehaviour
{
    [SerializeField] private GameObject _replacementPrefab = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SpawnReplacement();
        gameObject.Dispose();
    }

    private void SpawnReplacement()
    {
        if (_replacementPrefab != null)
        {
            Instantiate(_replacementPrefab,
                        transform.position,
                        Quaternion.identity);
        }
    }
}
