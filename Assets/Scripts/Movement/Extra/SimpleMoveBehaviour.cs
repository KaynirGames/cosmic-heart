using UnityEngine;

public class SimpleMoveBehaviour : MonoBehaviour
{
    [SerializeField] private BaseMoveHandler _moveHandler = null;
    [SerializeField] private BaseMoveInput _moveInput = null;

    private void Update()
    {
        _moveHandler.SetDirection(_moveInput.GetMoveInput());
    }
}
