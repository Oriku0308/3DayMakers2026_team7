using System.Collections;

/// <summary>スコア計算クラス</summary>
public static class ScoreCalculator
{
    /// <summary>反射数に応じたスコアのテーブル</summary>
    static readonly ReflectionBonusRange[] _reflectionCountTable = new[]
    {
        new ReflectionBonusRange(((0, 1), 10))
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
        //素点を加算
        result += baseScore;
        foreach (var score in _reflectionCountTable)
        {
            //反射数に応じたボーナスを加算
            if (score.TryGetBonus(reflectionCount, out var bonus))
            {
                result += bonus;
                break;
            }
        }
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