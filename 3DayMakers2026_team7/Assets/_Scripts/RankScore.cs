using UnityEngine;
using UnityEngine.UI;

public class RankScore : MonoBehaviour
{
    [SerializeField] Sprite[] _numbers;
    [SerializeField] Image[] _images;

    public void ImageUpdate(int score)
    {
        //スコアに対して除算する値
        var num = 10;
        //1の位から確認する
        for (int j = _images.Length - 1; 0 <= j; j--)
        {
            //調べる位以下の数字のみを取得
            //23456で10の位を調べる時はmod = 56になる
            var mod = score % num;
            //取得した数字の余りを求める
            //56なら10で割る
            mod /= num / 10;
            //対応する画像に変更
            _images[j].sprite = _numbers[mod];
            //次の位を調べるための10倍
            num *= 10;
        }
    }
}
