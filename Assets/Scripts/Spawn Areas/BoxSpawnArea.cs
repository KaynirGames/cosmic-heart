using UnityEngine;

public class BoxSpawnArea : BaseSpawnArea
{
    [SerializeField] private Vector3 _boxSize = Vector3.zero;
    [SerializeField] private bool _showSpawnBox = true;
    [SerializeField] private Color _spawnBoxColor = Color.blue;

    private Vector3 _minPoint;
    private Vector3 _maxPoint;

    private void Awake()
    {
        _minPoint = transform.position - _boxSize * .5f;
        _maxPoint = transform.position + _boxSize * .5f;
    }

    public override Vector3 GetSpawnPosition()
    {
        float randomX = Random.Range(_minPoint.x, _maxPoint.x);
        float randomY = Random.Range(_minPoint.y, _maxPoint.y);

        return new Vector3(randomX, randomY);
    }

    private void OnDrawGizmos()
    {
        if (_showSpawnBox)
        {
            Gizmos.color = _spawnBoxColor;
            Gizmos.DrawWireCube(transform.position, _boxSize);
        }
    }
}
