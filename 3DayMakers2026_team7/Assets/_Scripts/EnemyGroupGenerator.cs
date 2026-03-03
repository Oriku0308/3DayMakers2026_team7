using UnityEngine;

/// <summary>エネミー群を生成するクラス</summary>
public class EnemyGroupGenerator : MonoBehaviour
{
    [SerializeField, Tooltip("エネミー群\n戦闘要素がステージの初め")] EnemyGroup[] _enemyGroups;

    private void OnEnable()
    {
        EventHub.GameStartEvent += Initialize;
        EventHub.OnAllKidGoodEvent += EnemyGroupGenerate;
    }

    private void OnDisable()
    {
        EventHub.GameStartEvent -= Initialize;
        EventHub.OnAllKidGoodEvent -= EnemyGroupGenerate;
    }

    /// <summary>
    /// 初期化関数
    /// </summary>
    [ContextMenu("Initialize")]
    void Initialize()
    {
        //初めにすべて非アクティブ
        foreach (var enemyGroup in _enemyGroups)
        {
            enemyGroup.gameObject.SetActive(false);
        }
        //配列の先頭をアクティブ
        _enemyGroups[0].gameObject.SetActive(true);
    }

    /// <summary>
    /// エネミー群を生成する関数
    /// </summary>
    [ContextMenu("EnemyGroupGenerate")]
    void EnemyGroupGenerate()
    {
        //現在アクティブなエネミー群を非アクティブ
        _enemyGroups[0].gameObject.SetActive(false);
        Debug.Log($"No.{1} : Inactive");
        //アクティブだったオブジェクト以外から抽選
        var rand = Random.Range(1, _enemyGroups.Length);
        //新旧の要素を入れ替え
        (_enemyGroups[0], _enemyGroups[rand]) = (_enemyGroups[rand], _enemyGroups[0]);
        //新しくオブジェクトをアクティブ
        _enemyGroups[0].gameObject.SetActive(true);
        Debug.Log($"No.{rand + 1} : Active");
    }
}
