using System;

public interface IVariable<T>
{
    event Action<T> OnValueChanged;

    T Value { get; }

    void ApplyChange(T amount);

    void SetValue(T value);
}
