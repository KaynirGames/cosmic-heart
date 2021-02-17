using UnityEngine;

public class ProjectileAttack : MonoBehaviour, IShooter
{
    [SerializeField] private GameObject _projectilePrefab = null;
    [SerializeField] private Transform[] _firePoints = null;
    [Header("Настройки снаряда:")]
    [SerializeField] private float _fireRate = 1f;
    [SerializeField, Range(0f, 360f)] private float _fireAngle = 0f;
    [SerializeField] private int _projectileAmount = 1;
    [SerializeField] private float _projectileSpeed = 1f;

    public float FireRate { get => _fireRate; set => _fireRate = value; }
    public float FireAngle { get => _fireAngle; set => _fireAngle = value; }

    public int ProjectileAmount { get => _projectileAmount; set => _projectileAmount = value; }
    public float ProjectileSpeed { get => _projectileSpeed; set => _projectileSpeed = value; }

    private Timer _nextFireTimer;

    private void Start()
    {
        _nextFireTimer = new Timer(_fireRate);
    }

    private void Update()
    {
        if (!_nextFireTimer.Elapsed)
        {
            _nextFireTimer.Tick(Time.deltaTime);
        }
    }

    public void Attack()
    {
        if (_nextFireTimer.Elapsed)
        {
            foreach (Transform point in _firePoints)
            {
                SpawnProjectiles(_projectileAmount, point);
            }

            _nextFireTimer.Reset();
        }
    }

    public void SetFirePoints(Transform[] firePoints)
    {
        _firePoints = firePoints;
    }

    private void SpawnProjectiles(int amount, Transform point)
    {
        float angleStep = _fireAngle / Mathf.Max(1, amount - 1);
        float angle = point.rotation.eulerAngles.z + _fireAngle * .5f;

        for (int i = 0; i < amount; i++)
        {
            GameObject projectile = Instantiate(_projectilePrefab,
                                                point.position,
                                                Quaternion.AngleAxis(angle, Vector3.forward));

            Vector3 projectileVelocity = GetProjectileDirection(point.position, angle);
            projectile.GetComponent<Rigidbody2D>().velocity = projectileVelocity;

            angle -= angleStep;
        }
    }

    private Vector3 GetProjectileDirection(Vector3 startPosition, float angle)
    {
        float projectilePosX = startPosition.x + Mathf.Cos(angle * Mathf.Deg2Rad);
        float projectilePosY = startPosition.y + Mathf.Sin(angle * Mathf.Deg2Rad);

        Vector3 projectileVector = new Vector3(projectilePosX, projectilePosY);

        return (projectileVector - startPosition).normalized * _projectileSpeed;
    }
}