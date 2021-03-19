using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected CharacterStats _stats = null;
    [SerializeField] protected Animator _animator = null;

    public CharacterStats Stats => _stats;
    public Animator Animator => _animator;

    protected virtual void Awake()
    {
        _stats.OnCharacterDeath += Die;
    }

    protected virtual void Die()
    {
        gameObject.Dispose();
    }
}
