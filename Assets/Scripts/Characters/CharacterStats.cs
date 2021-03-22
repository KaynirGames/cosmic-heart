using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public event System.Action OnCharacterDeath = delegate { };

    [SerializeField] private IntData _health = null;
    [SerializeField] private FloatData _moveSpeed = null;

    public IntData Health => _health;
    public FloatData MoveSpeed => _moveSpeed;
}