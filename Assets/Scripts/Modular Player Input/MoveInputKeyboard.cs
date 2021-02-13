using UnityEngine;

public class MoveInputKeyboard : MonoBehaviour, IMoveInputHandler
{
    public Vector3 GetDirection()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        return new Vector3(horizontal, vertical);
    }
}
