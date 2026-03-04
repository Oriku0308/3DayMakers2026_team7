using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    TextMeshProUGUI _tmp;
    int _score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _tmp = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        EventHub.GameStartEvent += Initialize;
        EventHub.ScoreChangedEvent += AddScore;
        EventHub.GameEndEvent += Result;
    }

    private void OnDisable()
    {
        EventHub.GameStartEvent -= Initialize;
        EventHub.ScoreChangedEvent -= AddScore;
        EventHub.GameEndEvent -= Result;
    }

    void Initialize()
    {
        _score = 0;
        TextUpdate();
    }

    void TextUpdate()
    {
        _tmp.text = "Score : " + _score.ToString("00000");
    }

    void AddScore(int score)
    {
        _score += score;
        if (_score <= 0) _score = 0;
        TextUpdate();
    }

    void Result()
    {
        Ranking.SetPreScore(_score);
    }
}
