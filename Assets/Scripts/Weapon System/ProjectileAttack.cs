using UnityEngine;

public class ProjectileAttack : MonoBehaviour, IAttackHandler
{
    [SerializeField] private GameObject _projectilePrefab = null;
    [SerializeField] private Transform[] _firePoints = null;
    [Header("Настройка снарядов:")]
    [SerializeField, Range(0f, 360f)] private float _fireAngle = 0f;
    [SerializeField] private int _projectileAmount = 1;
    [SerializeField] private float _projectileSpeed = 1f;

    public void Attack()
    {
        foreach (Transform point in _firePoints)
        {
            SpawnProjectiles(_projectileAmount, point);
        }
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

            Vector3 projectileDirection = GetProjectileDirection(point.position, angle);

            IMoveHandler projectileMoveHandler = projectile.GetComponent<IMoveHandler>();

            projectileMoveHandler.SetMoveSpeed(_projectileSpeed);
            projectileMoveHandler.Move(projectileDirection);

            angle -= angleStep;
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