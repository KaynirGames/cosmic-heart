using System.Collections.Generic;
using UnityEngine;

public class SpawnLootEvent : BaseEvent
{
    [SerializeField] private LootTableSO _lootTable = null;
    [SerializeField] private BaseSpawnArea _spawnArea = null;

    public override void TryInvoke(GameObject target)
    {
        List<GameObject> lootList = _lootTable.GetLoot();

        foreach (GameObject loot in lootList)
        {
            Instantiate(loot,
                        _spawnArea.GetSpawnPosition(),
                        Quaternion.identity);
        }
    }
}