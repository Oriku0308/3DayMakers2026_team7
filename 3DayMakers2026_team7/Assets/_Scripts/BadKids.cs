using UnityEngine;

public class BadKids : MonoBehaviour
{
    public void Initialize()
    {
        Debug.Log("BadKids Initialized");
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
        if (collision.collider.CompareTag("Vinegar")) BadKidHit();
    }

    [ContextMenu("BadKidHit")]
    void BadKidHit()
    {
        EventHub.BadKidHitAct();
    }
}
