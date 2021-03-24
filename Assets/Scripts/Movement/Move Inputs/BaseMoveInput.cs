using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMoveInput : MonoBehaviour, IDirectionHandler
{
    public abstract Vector3 GetDirection();
}
