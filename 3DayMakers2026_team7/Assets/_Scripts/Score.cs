using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    TextMeshProUGUI _tmp;
    int _score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //シーンに入ったら描画初期化
        _tmp = GetComponent<TextMeshProUGUI>();
        _score = 0;
        TextUpdate();
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
        //何かゲームがスタートした時に必要な処理
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
