using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private EnergyConsumer _energyConsumer = null;

    private void Awake()
    {
        _energyConsumer.OnEnergyDrained += Die;
    }

    private void Die()
    {
        Debug.Log("Player is dead!");
    }
}