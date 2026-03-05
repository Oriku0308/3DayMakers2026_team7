using System.Collections;

/// <summary>スコア計算クラス</summary>
public static class ScoreCalculator
{
    /// <summary>反射数に応じたスコアのテーブル</summary>
    static readonly ReflectionBonusRange[] _reflectionCountTable = new[]
    {
        new ReflectionBonusRange(((1,1),50)),
        new ReflectionBonusRange(((2,2),100)),
        new ReflectionBonusRange(((3,3),150)),
        new ReflectionBonusRange(((4,4),200)),
        new ReflectionBonusRange(((5,5),250)),
    };

    /// <summary>
    /// ボーナスも含めたスコア計算関数
    /// </summary>
    /// <param name="baseScore">ベースのスコア</param>
    /// <param name="reflectionCount">反射数</param>
    /// <returns>最終スコア</returns>
    public static int CalculateScore(int baseScore, int reflectionCount)
    {
        var result = 0;
        var bonus = 0;
        //素点を加算
        result += baseScore;
        foreach (var score in _reflectionCountTable)
        {
            //反射数に応じたボーナスを加算
            if (score.TryGetBonus(reflectionCount, out bonus))
            {
                result += bonus;
                break;
            }
        }
        //反射数が一定数を超えたらボーナスの上限値
        if (reflectionCount > 0 && bonus == 0) result += 500;
        return result;
    }

}

/// <summary>反射数に応じたスコアを保持するクラス</summary>
readonly struct ReflectionBonusRange
{
    readonly ((int minCount, int maxCount) range, int bonus) _table;

    public ReflectionBonusRange(((int minCount, int maxCount) range, int bonus) table)
    {
        _table = table;
    }

    /// <summary>
    /// 反射数に応じたボーナスを取得する関数
    /// </summary>
    /// <param name="reflectionCount">反射数</param>
    /// <param name="bonus">ボーナス</param>
    /// <returns>スコアが獲得できるか</returns>
    public bool TryGetBonus(int reflectionCount, out int bonus)
    {
        bonus = 0;
        //反射数の指定範囲に入っていたらボーナスを獲得
        if (_table.range.minCount <= reflectionCount && reflectionCount <= _table.range.maxCount)
            bonus = _table.bonus;
        return bonus > 0;
    }
}