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
        IDisposable disposable = gameObject.GetComponent<IDisposable>();

        if (disposable == null)
        {
            disposable = new DefaultDisposable();
        }

        disposable.Dispose(gameObject);
    }

    public static bool InLayers(this GameObject gameObject, int layers)
    {
        return layers == (layers | 1 << gameObject.layer);
    }

    public static bool InRange(this float value, float min, float max)
    {
        return value >= min && value <= max;
    }

    public static bool InRange(this int value, int min, int max)
    {
        return value >= min && value <= max;
    }

    public static GameObject FindClosestObject(this GameObject gameObject, GameObject[] searchObjects)
    {
        float distance = Mathf.Infinity;
        GameObject closestObject = null;

        foreach (GameObject go in searchObjects)
        {
            float currentDistance = (go.transform.position
                                     - gameObject.transform.position).sqrMagnitude;

            if (currentDistance < distance)
            {
                distance = currentDistance;
                closestObject = go;
            }
        }

        return closestObject;
    }
}
