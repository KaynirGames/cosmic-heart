using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMoveInput : MonoBehaviour, IMoveInput
{
    public abstract Vector3 GetMoveInput();
}
