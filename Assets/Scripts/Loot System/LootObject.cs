using UnityEngine;

[System.Serializable]
public class LootObject
{
    [SerializeField] private GameObject _loot = null;
    [SerializeField, Range(1, 100)] private int _dropChance = 25;

    public GameObject Loot => _loot;
    public int DropChance => _dropChance;

    public bool TryDrop(int roll, out GameObject loot)
    {
        loot = null;

        if (roll <= _dropChance)
        {
            loot = _loot;
        }

        return loot != null;
    }
}