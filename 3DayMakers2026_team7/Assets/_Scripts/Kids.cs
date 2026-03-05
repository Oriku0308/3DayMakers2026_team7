using System.Threading.Tasks;
using UnityEngine;

public class Kids : MonoBehaviour
{
    [SerializeField] ParticleSystem _badParticle;
    [SerializeField] ParticleSystem _goodParticle;
    [SerializeField] Sprite _bad;
    [SerializeField] Sprite _good;
    [SerializeField, Tooltip("わるい子ならチェック")] bool _isBad;
    [SerializeField, Tooltip("わるい子の得点")] int _badScore = 100;
    [SerializeField, Tooltip("いい子の得点")] int _goodScore = -100;
    SpriteRenderer _spriteRenderer;
    Animator _animator;

    public async Task Initialize()
    {
        _badParticle?.Stop();
        _goodParticle?.Stop();
        if (_isBad)
        {
            tag = "BadBoy";
            _spriteRenderer.sprite = _bad;
            _badParticle?.Play();
        }
        else
        {
            tag = "GoodBoy";
            _spriteRenderer.sprite = _good;
            _goodParticle?.Play();
        }
        await DelayAnimationPlay();
        _animator.Play("Idle");
        Debug.Log("Kids Initialized");
    }

    async Task DelayAnimationPlay()
    {
        await Task.Delay(Random.Range(0, 500));
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private async void OnEnable()
    {
        await Initialize();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Vinegar"))
        {
            if (CompareTag("BadBoy"))
                BadKidHit();
            else
                GoodKidHit();
            _animator.SetTrigger("Hit");
        }
    }

    [ContextMenu("BadKidHit")]
    void BadKidHit()
    {
        _spriteRenderer.sprite = _good;
        tag = "GoodBoy";
        _badParticle?.Stop();
        _goodParticle?.Play();
        EventHub.BadKidHitAct();
        EventHub.ScoreChangedAct(_badScore);
    }

    [ContextMenu("GoodKidHit")]
    void GoodKidHit()
    {
        EventHub.GoodKidHitAct();
        EventHub.ScoreChangedAct(_goodScore);
    }
}
