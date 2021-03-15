using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterStats Stats { get; private set; }

    protected virtual void Awake()
    {
        Stats = GetComponent<CharacterStats>();
        Stats.OnCharacterDeath += Die;
    }

    protected virtual void Die()
    {
        gameObject.Dispose();
    }
}
