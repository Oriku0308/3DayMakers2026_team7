using UnityEngine;

public sealed class ClearFlag
{
    readonly IEnemyGroupGenerate _enemyGroupGenerate;
    public ClearFlag(IEnemyGroupGenerate enemyGroupGenerate)
    {
        _enemyGroupGenerate = enemyGroupGenerate;
        _enemyGroupGenerate.Initialize();
    }

    /// <summary>
    /// すべての悪い子を更生させられたか
    /// </summary>
    public void ChangedAllBadChild()
    {

    }
}
