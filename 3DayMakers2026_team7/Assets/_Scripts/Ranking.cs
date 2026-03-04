using System.Collections.Generic;

public static class Ranking
{
    static int MaxRankCount = 5;
    readonly static List<int> _ranks = new() { 0, 0, 0, 0, 0 };
    public static IReadOnlyList<int> Ranks => _ranks;
    static int _preScore = 0;
    public static int PreScore => _preScore;

    public static void SetPreScore(int preScore)
    {
        _preScore = preScore;
    }

    public static void Add(int score)
    {
        _ranks.Add(score);
        SortAndRemove();
    }

    /// <summary>
    /// ランキングのソートと保持できるランキングの数から溢れたものを削除する関数
    /// </summary>
    static void SortAndRemove()
    {
        //新たに追加された値がどの位置になるのかを確定させる
        //新たに追加された値が現在確定している順位と一つ上の順位にある値を比較する
        for (int i = MaxRankCount - 1; 0 <= i; i--)
        {
            var oldRank = _ranks[i];
            var newRank = _ranks[i + 1];
            //順位が逆なら入れ替え、そうでなければ確定
            if (oldRank < newRank)
            {
                _ranks[i] = newRank;
                _ranks[i + 1] = oldRank;
            }
            else
            {
                break;
            }
        }
        //ランキングから溢れたものを削除
        _ranks.RemoveAt(MaxRankCount);
    }

    public static void Clear()
    {
        _ranks.Clear();
    }
}