using UnityEngine;

public class GoodKids : MonoBehaviour
{
    public void Initialize()
    {
        Debug.Log("Enemy Initialized");
    }

    private void OnEnable()
    {
        EventHub.GameStartEvent += Initialize;
    }

    private void OnDisable()
    {
        EventHub.GameStartEvent -= Initialize;
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
