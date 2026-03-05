using UnityEngine;

/// <summary>
/// Bullet専用のSE再生クラス
/// Bullet自身にアタッチする必要がある
/// </summary>
public class BulletSoundEffect : MonoBehaviour
{
    void Start()
    {
        Play(SEManager.SEType.BulletShot);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // BulletがWallタグのオブジェクトと衝突したときにSEを再生
        if (collision.gameObject.CompareTag("Wall"))
        {
            Play(SEManager.SEType.WallReflect);
        }
    }

    // SEManagerを探してSEを再生
    private void Play(SEManager.SEType type)
    {
        Object.FindAnyObjectByType<SEManager>()?.PlaySE(type);
    }
}
