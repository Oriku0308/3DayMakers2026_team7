using UnityEngine;

/// <summary>エネミー群のクラス</summary>
public class EnemyGroup : MonoBehaviour
{
    [SerializeField] int _badKidsMaxCount;
    int _badKidsCount;

    private void OnEnable()
    {
        EventHub.BadKidHitEvent += ChangedBadKids;
    }

    private void OnDisable()
    {
        EventHub.BadKidHitEvent -= ChangedBadKids;
    }

    /// <summary>
    /// わるい子が更生したときに呼び出される
    /// </summary>
    [ContextMenu("ChangedBadKids")]
    void ChangedBadKids()
    {
        _badKidsCount++;
        //わるい子を更生した数が一定数に達したらステージ更新
        if (_badKidsCount >= _badKidsMaxCount)
        {
            _badKidsCount = 0;
            EventHub.OnAllKidGoodAct();
        }
    }
}
