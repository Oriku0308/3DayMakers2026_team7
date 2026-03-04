using UnityEngine;

public class BadKids : MonoBehaviour
{
    [SerializeField] Sprite _bad;
    [SerializeField] Sprite _good;
    SpriteRenderer _spriteRenderer;

    public void Initialize()
    {
        _spriteRenderer.sprite = _bad;
        Debug.Log("BadKids Initialized");
    }

    private void Awake()
    {
        tag = "BadBoy";
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        Initialize();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Vinegar")) BadKidHit();
    }

    [ContextMenu("BadKidHit")]
    void BadKidHit()
    {
        _spriteRenderer.sprite = _good;
        EventHub.BadKidHitAct();
    }
}
