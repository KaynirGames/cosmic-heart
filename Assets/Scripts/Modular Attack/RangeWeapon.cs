using System.Collections.Generic;
using UnityEngine;

public class RangeWeapon : MonoBehaviour, IAttackHandler
{
    [SerializeField] private GameObject _bulletPrefab = null;
    [SerializeField] private List<Transform> _firePoints = null;

    [SerializeField] private float _fireRate = 1f;
    [SerializeField, Range(0f, 360f)] private float _fireAngle = 0f;
    [SerializeField] private int _bulletAmount = 1;
    [SerializeField] private float _bulletSpeed = 1f;

    private Timer _nextFireTime;

    private void Start()
    {
        _nextFireTime = new Timer(_fireRate);
    }

    private void Update()
    {
        if (!_nextFireTime.Elapsed)
        {
            _nextFireTime.Tick(Time.deltaTime);
        }
    }

    public void Attack()
    {
        if (_nextFireTime.Elapsed)
        {
            foreach (Transform point in _firePoints)
            {
                SpawnBullets(_bulletAmount, point.position);
            }

            _nextFireTime.Reset();
        }
    }

    private void SpawnBullets(int amount, Vector3 position)
    {
        float angleStep = _fireAngle / (amount - 1);
        float angle = 360 - _fireAngle * .5f;

        for (int i = 0; i < amount; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab,
                                            position,
                                            Quaternion.identity);

            bullet.GetComponent<Rigidbody2D>().velocity = GetBulletDirection(position,
                                                                             angle);

            angle += angleStep;
        }
    }

    private Vector3 GetBulletDirection(Vector3 startPosition, float angle)
    {
        float bulletPosX = startPosition.x + Mathf.Sin(angle * Mathf.PI / 180f);
        float bulletPosY = startPosition.y + Mathf.Cos(angle * Mathf.PI / 180f);

        Vector3 bulletVector = new Vector3(bulletPosX, bulletPosY);

        return (bulletVector - startPosition).normalized * _bulletSpeed;
    }
}
