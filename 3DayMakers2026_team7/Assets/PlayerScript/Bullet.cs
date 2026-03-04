using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float leftLimitx = -10f;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }
    private void OnEnable()
    {
        rb.linearVelocity = transform.right * speed;
    }
    void Update()
    {
        //if (transform.position.x < leftLimitx)
        //{
        //    ReturnToPool();
        //    Debug.Log("消しました");
        //}
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("当たった相手:" + collision.gameObject.name);

        if (collision.gameObject.CompareTag("BadBoy") || collision.gameObject.CompareTag("GoodBoy"))
        {
            Debug.Log("タグ一致、消す");
            ReturnToPool();
        }
        //if (collision.gameObject.CompareTag("BadBoy"))
        //{
        //    Debug.Log("BadBoyに当たりました");
        //    Destroy(gameObject);
        //    return;
        //}
        //else if (collision.gameObject.CompareTag("GoodBoy"))
        //{
        //    Debug.Log("GoodBoyに当たりました");
        //    Destroy(gameObject); 
        //    return;
        //}
      
    }

    private void ReturnToPool()
    {
        rb.linearVelocity = Vector2.zero;
        gameObject.SetActive(false);  
    }

    public void Reflect(Vector2 normal)
    {
        Vector2 newDir = Vector2.Reflect(transform.right.normalized, normal);
        rb.linearVelocity = newDir * speed;
        transform.right = newDir;
    }
}
