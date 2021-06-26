using UnityEngine;

public class ColorOverDistance : MonoBehaviour
{
    [SerializeField] private Gradient _gradient = null;
    [SerializeField] private GameObjectReference _targetObject = null;

    public Color LerpColor(float maxDistance)
    {
        float distance = Vector2.Distance(transform.position,
                                          _targetObject.Value.transform.position);

        return _gradient.Evaluate(distance / maxDistance);
    }
}