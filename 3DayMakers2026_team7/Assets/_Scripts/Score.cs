using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField, Tooltip("必ず0～9の順番")] Sprite[] _numbers;
    [SerializeField] Image[] _images;
    int _score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //シーンに入ったら描画初期化
        _score = 0;
        ImageUpdate();
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

    void ImageUpdate()
    {
        //スコアに対して除算する値
        var num = 10;
        //1の位から確認する
        for (int i = _images.Length - 1; 0 <= i; i--)
        {
            //調べる位以下の数字のみを取得
            //23456で10の位を調べる時はmod = 56になる
            var mod = _score % num;
            //取得した数字の余りを求める
            //56なら10で割る
            mod /= num / 10;
            //対応する画像に変更
            _images[i].sprite = _numbers[mod];
            //次の位を調べるための10倍
            num *= 10;
        }
    }

    void AddScore(int score)
    {
        _score += score;
        if (_score <= 0) _score = 0;
        ImageUpdate();
    }

    void Result()
    {
        Ranking.SetPreScore(_score);
        Ranking.Add(_score);
    }
}
