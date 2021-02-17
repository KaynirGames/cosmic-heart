using UnityEngine;

public interface IShooter : IAttackHandler
{
    float FireRate { get; set; }
    float FireAngle { get; set; }

    int ProjectileAmount { get; set; }
    float ProjectileSpeed { get; set; }

    void SetFirePoints(Transform[] firePoints);
}