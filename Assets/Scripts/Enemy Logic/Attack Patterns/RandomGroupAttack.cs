using System.Collections.Generic;
using UnityEngine;

public class RandomGroupAttack : BaseGroupAttack
{
    public override void Execute(List<Enemy> enemies)
    {
        if (enemies.Count > 0)
        {
            int random = Random.Range(0, enemies.Count);
            enemies[random].Attack();
        }
    }
}
