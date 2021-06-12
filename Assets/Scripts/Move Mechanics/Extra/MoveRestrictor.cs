using UnityEngine;

public class MoveRestrictor : MonoBehaviour
{
    [SerializeField] private Vector3 _minMoveBound = Vector3.zero;
    [SerializeField] private Vector3 _maxMoveBound = Vector3.zero;

    private void LateUpdate()
    {
        transform.ClampPosition2D(_minMoveBound,
                                  _maxMoveBound);
    }
}
