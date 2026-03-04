using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private BulletPool bulletPool;
    [SerializeField] private Transform Point;
    [SerializeField] private float fireInterval = 1.5f;

    private float timer;
    void Update()
    {
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
}
