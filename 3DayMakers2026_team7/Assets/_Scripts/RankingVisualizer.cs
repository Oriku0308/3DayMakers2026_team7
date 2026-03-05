using UnityEngine;

public class RankingVisualizer : MonoBehaviour
{
    [SerializeField] RankScore[] _ranks;

    private void Start()
    {
        var rank = Ranking.Ranks;
        for (int i = 0; i < rank.Count; i++)
        {
            Debug.Log(rank[i]);
            if (_ranks.Length > 0) _ranks[i]?.ImageUpdate(rank[i]);
        }
    }
}
