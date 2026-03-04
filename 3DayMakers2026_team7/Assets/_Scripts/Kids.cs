using UnityEngine;

public class Kids : MonoBehaviour
{
    [SerializeField] Sprite _bad;
    [SerializeField] Sprite _good;
    [SerializeField, Tooltip("わるい子ならチェック")] bool _isBad;
    [SerializeField, Tooltip("わるい子の得点")] int _badScore = 100;
    [SerializeField, Tooltip("いい子の得点")] int _goodScore = -100;
    SpriteRenderer _spriteRenderer;

    public void Initialize()
    {
        if (_isBad) tag = "BadBoy";
        _spriteRenderer.sprite = _bad;
        Debug.Log("Kids Initialized");
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Initialize();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Vinegar"))
        {
            if (CompareTag("BadBoy"))
                BadKidHit();
            else
                GoodKidHit();
        }
    }

    [ContextMenu("BadKidHit")]
    void BadKidHit()
    {
        _spriteRenderer.sprite = _good;
        tag = "GoodBoy";
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
