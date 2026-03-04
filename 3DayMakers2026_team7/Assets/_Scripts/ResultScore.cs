using UnityEngine;

public class ResultScore : MonoBehaviour
{
    [SerializeField] RankScore _score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _score.ImageUpdate(Ranking.PreScore);
    }
}
