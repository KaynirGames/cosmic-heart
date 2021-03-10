using UnityEngine;

public static class MyExtensions
{
    public static void ClampPosition2D(this Transform transform, Vector3 minPosition, Vector3 maxPosition)
    {
        Vector3 newPosition = transform.position;

        newPosition.x = Mathf.Clamp(newPosition.x, minPosition.x, maxPosition.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minPosition.y, maxPosition.y);

        transform.position = newPosition;
    }

    public static void Dispose(this GameObject gameObject)
    {
        IDisposer disposer = new DefaultDisposer();

        if (gameObject.TryGetComponent(out IDisposer goDisposer))
        {
            disposer = goDisposer;
        }

        disposer.Dispose(gameObject);
    }
}
