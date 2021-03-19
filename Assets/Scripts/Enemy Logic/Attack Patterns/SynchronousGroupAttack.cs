using System.Collections.Generic;

public class SynchronousGroupAttack : BaseGroupAttack
{
    public override void Execute(List<Enemy> enemies)
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.Attack();
        }
    }
}
