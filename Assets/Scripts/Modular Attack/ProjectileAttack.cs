using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour, IAttackHandler
{
    [SerializeField] private List<Transform> _firePoints = new List<Transform>();
    [SerializeField] private GameObject _projectilePrefab = null;

    public void Attack()
    {
        foreach (Transform point in _firePoints)
        {
            Instantiate(_projectilePrefab, point.position, point.rotation);
        }
    }
}
