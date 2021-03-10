using UnityEngine;

public class DefaultDisposer : IDisposer
{
    public void Dispose(GameObject gameObject)
    {
        Object.Destroy(gameObject);
    }
}
