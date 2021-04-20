using UnityEngine;

public class DefaultDisposable : IDisposable
{
    public void Dispose(GameObject gameObject)
    {
        Object.Destroy(gameObject);
    }
}
