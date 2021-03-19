using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGroupAttack : MonoBehaviour
{
    public abstract void Execute(List<Enemy> enemies);
}
