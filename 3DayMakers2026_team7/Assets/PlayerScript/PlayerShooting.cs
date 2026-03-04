using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private Transform Point;
    [SerializeField] private float fireInterval = 1.5f;

    private float timer;
    bool _isShootable;

    private void Awake()
    {
        Debug.Log("ショット待機");
    }

    private void OnEnable()
    {
        EventHub.GameStartEvent += Init;
        EventHub.GameEndEvent += GameEnd;
    }

    private void OnDisable()
    {
        EventHub.GameStartEvent -= Init;
        EventHub.GameEndEvent -= GameEnd;
    }

    void Update()
    {
        if (!_isShootable) return;
        timer += Time.deltaTime;

        if (Keyboard.current.spaceKey.wasPressedThisFrame && timer > fireInterval)
        {
            Shoot();
            timer = 0f;
        }
    }

    private void Shoot()
    {
        bulletPool.GetBullet(Point.position, Point.rotation);
    }

    void Init()
    {
        _isShootable = true;
        timer = fireInterval;
        Debug.Log("ショット可能");
    }

    void GameEnd()
    {
        _isShootable = false;
    }
}
