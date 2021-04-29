using System.Collections.Generic;
using UnityEngine;

public class SpawnLootEvent : BaseEvent
{
    [SerializeField] private LootTableSO _lootTable = null;
    [SerializeField] private BaseSpawnArea _spawnArea = null;

    protected override void Invoke(GameObject target)
    {
        List<GameObject> lootList = _lootTable.GetLoot();

        foreach (GameObject loot in lootList)
        {
            SpawnLoot(loot);
        }
    }

    private void SpawnLoot(GameObject loot)
    {
        Instantiate(loot,
                    _spawnArea.GetSpawnPosition(),
                    Quaternion.identity);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        _eventMode = EventMode.None;
    }
#endif
}
