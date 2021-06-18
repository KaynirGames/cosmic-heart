using System;
using UnityEngine;

[Serializable]
public class GameObjectReference : VariableReference<GameObject, GameObjectVariableSO>
{
    public GameObjectReference() { }

    public GameObjectReference(GameObject value) : base(value) { }

    public GameObjectReference(GameObjectVariableSO variable) : base(variable) { }
}