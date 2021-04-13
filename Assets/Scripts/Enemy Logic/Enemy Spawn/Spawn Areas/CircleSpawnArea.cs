using UnityEngine;

public class CircleSpawnArea : BaseSpawnArea
{
    [SerializeField] private float _spawnRadius = 1f;
    [SerializeField] private bool _showSpawnRadius = true;
    [SerializeField] private Color _spawnCircleColor = Color.blue;

    public override Vector3 GetSpawnPosition()
    {
        return (Vector2)transform.position
               + (Random.insideUnitCircle * _spawnRadius);
    }

    private void OnDrawGizmos()
    {
        if (_showSpawnRadius)
        {
            Gizmos.color = _spawnCircleColor;
            Gizmos.DrawWireSphere(transform.position, _spawnRadius);
        }
    }
}
