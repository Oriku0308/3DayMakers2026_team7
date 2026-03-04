using UnityEngine;

public class Kids : MonoBehaviour
{
    [SerializeField] Sprite _bad;
    [SerializeField] Sprite _good;
    [SerializeField] bool _isBad;
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
    }

    [ContextMenu("GoodKidHit")]
    void GoodKidHit()
    {
        EventHub.GoodKidHitAct();
    }
}
