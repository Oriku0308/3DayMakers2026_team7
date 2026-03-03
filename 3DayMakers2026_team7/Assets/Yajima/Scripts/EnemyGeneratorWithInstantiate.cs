using UnityEngine;

/// <summary>プレハブ生成に対応したエネミー群生成クラス</summary>
public class EnemyGeneratorWithInstantiate : MonoBehaviour
{
    [SerializeField, Tooltip("エネミー群\n戦闘要素がステージの初め")] EnemyGroup[] _enemyGroups;
    [SerializeField] Vector3 _generatePosition;
    EnemyGroup[] _enemyInstantiateGroups;

    /// <summary>
    /// 初期化関数
    /// </summary>
    [ContextMenu("Initialize")]
    public void Initialize()
    {
        _enemyInstantiateGroups = new EnemyGroup[_enemyGroups.Length];
        //初めにすべて非アクティブ
        for (int i = 0; i < _enemyGroups.Length; i++)
        {
            _enemyInstantiateGroups[i] = Instantiate(_enemyGroups[i], _generatePosition, Quaternion.identity);
            _enemyInstantiateGroups[i].gameObject.SetActive(false);
        }
        //配列の先頭をアクティブ
        _enemyInstantiateGroups[0].gameObject.SetActive(true);
    }

    /// <summary>
    /// エネミー群を生成する関数
    /// </summary>
    [ContextMenu("EnemyGroupGenerate")]
    public void EnemyGroupGenerate()
    {
        //現在アクティブなエネミー群を非アクティブ
        _enemyInstantiateGroups[0].gameObject.SetActive(false);
        Debug.Log($"No.{1} : Inactive");
        //アクティブだったオブジェクト以外から抽選
        var rand = Random.Range(1, _enemyInstantiateGroups.Length);
        //新旧の要素を入れ替え
        (_enemyInstantiateGroups[0], _enemyInstantiateGroups[rand]) = (_enemyInstantiateGroups[rand], _enemyInstantiateGroups[0]);
        //新しくオブジェクトをアクティブ
        _enemyInstantiateGroups[0].gameObject.SetActive(true);
        Debug.Log($"No.{rand + 1} : Active");
    }
}
