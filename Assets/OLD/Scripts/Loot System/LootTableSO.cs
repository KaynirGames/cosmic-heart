using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Loot System/Loot Table")]
public class LootTableSO : ScriptableObject
{
    [SerializeField] private DropType _dropType = DropType.Single;
    [SerializeField] private List<LootObject> _lootObjects = null;

    public List<GameObject> GetLoot()
    {
        List<GameObject> lootList = new List<GameObject>();

        switch (_dropType)
        {
            case DropType.Single:
                HandleSingleLoot(lootList);
                break;
            case DropType.Multiple:
                HandleMultipleLoot(lootList);
                break;
        }

        return lootList;
    }

    private void HandleMultipleLoot(List<GameObject> lootList)
    {
        foreach (LootObject lootObject in _lootObjects)
        {
            int roll = Random.Range(1, 101);

            if (lootObject.TryDrop(roll, out GameObject loot))
            {
                lootList.Add(loot);
            }
        }
    }

    private void HandleSingleLoot(List<GameObject> lootList)
    {
        int total = 0;

        _lootObjects.ForEach(x => total += x.DropChance);

        int roll = Random.Range(0, total);

        foreach (LootObject lootObject in _lootObjects)
        {
            if (lootObject.TryDrop(roll, out GameObject loot))
            {
                lootList.Add(loot);
                return;
            }

            roll -= lootObject.DropChance;
        }
    }

    private enum DropType
    {
        Single,
        Multiple
    }
}