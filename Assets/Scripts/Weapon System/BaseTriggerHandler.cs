using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTriggerHandler : MonoBehaviour
{
    public delegate void OnTriggerAttack();
    public abstract event OnTriggerAttack OnTrigger;

    public abstract bool TriggerAttack();
}
