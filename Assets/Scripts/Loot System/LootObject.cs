using UnityEngine;

[System.Serializable]
public class LootObject
{
    [SerializeField] private GameObject _loot = null;
    [SerializeField, Range(1, 100)] private int _dropChance = 25;

    public bool TryDropLoot(out GameObject loot)
    {
        loot = null;

        if (Random.Range(1, 101) <= _dropChance)
        {
            loot = _loot;
        }

        return loot != null;
    }
}