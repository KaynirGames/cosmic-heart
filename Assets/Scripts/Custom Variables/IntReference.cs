using System;

[Serializable]
public class IntReference : VariableReference<int, IntVariableSO>
{
    public IntReference() { }

    public IntReference(int value) : base(value) { }

    public IntReference(IntVariableSO variable) : base(variable) { }
}