using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Runtime Collections/GameObject Queue")]
public class GameObjectQueueSO : ScriptableObject
{
    private Queue<GameObject> _objects = new Queue<GameObject>();

    public Queue<GameObject> GetQueue()
    {
        return _objects;
    }
}
