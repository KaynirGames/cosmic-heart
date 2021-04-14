using UnityEngine;

public class ProjectileAttackHandler : BaseAttackHandler
{
    [SerializeField] private GameObject _projectilePrefab = null;
    [SerializeField] private Transform[] _firePoints = null;
    [Header("Настройка снарядов:")]
    [SerializeField, Range(0f, 360f)] private float _spreadAngle = 0f;
    [SerializeField] private int _projectileAmount = 1;
    [SerializeField] private float _projectileSpeed = 1f;

    public override void Attack()
    {
        foreach (Transform point in _firePoints)
        {
            SpawnProjectiles(_projectileAmount, point);
        }
    }

    private void SpawnProjectiles(int amount, Transform point)
    {
        float angleStep = _spreadAngle / amount;
        float aimAngle = point.rotation.eulerAngles.z;
        float spreadOffset = (_spreadAngle - angleStep) * .5f;

        for (int i = 0; i < amount; i++)
        {
            float currentAngle = aimAngle + angleStep * i - spreadOffset;

            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, currentAngle));

            GameObject projectile = Instantiate(_projectilePrefab,
                                                point.position,
                                                rotation);

            projectile.SetActive(true);

            Vector3 projectileDirection = GetProjectileDirection(point.position,
                                                                 currentAngle);

            BaseMoveHandler projectileMove = projectile.GetComponent<BaseMoveHandler>();

            projectileMove.SetSpeed(_projectileSpeed);
            projectileMove.SetDirection(projectileDirection);
        }
    }

    private Vector3 GetProjectileDirection(Vector3 startPosition, float angle)
    {
        float projectilePosX = startPosition.x + Mathf.Cos(angle * Mathf.Deg2Rad);
        float projectilePosY = startPosition.y + Mathf.Sin(angle * Mathf.Deg2Rad);

        Vector3 projectileVector = new Vector3(projectilePosX, projectilePosY);

        return (projectileVector - startPosition).normalized;
    }
}
