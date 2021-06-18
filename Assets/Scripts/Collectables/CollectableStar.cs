using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableStar : Collectable
{
    public override void Collect()
    {
        Debug.Log("Star collected!");

        _onCollect.Invoke();
    }
}