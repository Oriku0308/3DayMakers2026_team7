using UnityEngine;

public class GoodKids : MonoBehaviour
{
    public void Initialize()
    {
        Debug.Log("GoodKids Initialized");
    }

    private void Awake()
    {
        tag = "GoodBoy";
    }

    private void OnEnable()
    {
        Initialize();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Vinegar")) GoodKidHit();
    }

    [ContextMenu("GoodKidHit")]
    void GoodKidHit()
    {
        EventHub.GoodKidHitAct();
    }
}
