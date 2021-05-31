using UnityEngine;

public interface IDirectionHandler
{
    Vector3 GetDirection();

    void SetDirection(Vector3 direction);
}