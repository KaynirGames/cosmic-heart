using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Loot System/Loot Table")]
public class LootTableSO : ScriptableObject
{
    [SerializeField] private List<LootObject> _lootObjects = null;

    public List<GameObject> GetLoot()
    {
        List<GameObject> lootList = new List<GameObject>();

        foreach (LootObject lootObject in _lootObjects)
        {
            if (lootObject.TryDropLoot(out GameObject loot))
            {
                lootList.Add(loot);
            }
        }

        return lootList;
    }
}
