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
    private void Start()
    {
        rb.linearVelocity = transform.right * speed;
    }
    void Update()
    {
        if (transform.position.x < leftLimitx)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BadBoy"))
        {
            Debug.Log("BadBoy‚É“–‚½‚è‚Ü‚µ‚½");
            Destroy(gameObject);
            return;
        }
        else if (collision.gameObject.CompareTag("GoodBoy"))
        {
            Debug.Log("GoodBoy‚É“–‚½‚è‚Ü‚µ‚½");
            Destroy(gameObject); 
            return;
        }
        //if (collision.gameObject.CompareTag("Wall"))
        //{
        //    Conta
        //    Vector2 normal = collision.contacts[0].normal;
        //    Vector2 newDir = Vector2.Reflect(rb.linearVelocity.normalized, normal);
        //    rb.linearVelocity = newDir * speed;
        //}
    }

    public void Reflect(Vector2 normal)
    {
        Vector2 newDir = Vector2.Reflect(transform.right.normalized, normal);
        rb.linearVelocity = newDir * speed;
        transform.right = newDir;
    }
}
