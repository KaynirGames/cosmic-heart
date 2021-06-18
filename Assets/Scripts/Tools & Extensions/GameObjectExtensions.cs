using UnityEngine;

public static class GameObjectExtensions
{
    //public static void Dispose(this GameObject gameObject)
    //{
    //    IDisposable disposable = gameObject.GetComponent<IDisposable>();

    //    if (disposable == null)
    //    {
    //        disposable = new DefaultDisposable();
    //    }

    //    disposable.Dispose(gameObject);
    //}

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

    public static bool InLayers(this GameObject gameObject, int layers)
    {
        return layers == (layers | 1 << gameObject.layer);
    }
}