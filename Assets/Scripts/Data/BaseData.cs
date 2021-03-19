using UnityEngine;

public abstract class BaseData<T> : MonoBehaviour
{
    public delegate void OnDataValueChanged(T value);

    [SerializeField] protected T _value = default;

    public abstract T GetValue();

    public abstract void SetValue(T value);

    public abstract void ChangeValue(T amount);
}