using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private int maxBullets = 5;

    private List<GameObject> bullets = new List<GameObject>();
    private int currentIndex = 0;

    public GameObject GetBullet(Vector3 pos, Quaternion rot)
    {
        // á@ Ç‹Çæè„å¿ñ¢ñûÇ»ÇÁê∂ê¨
        if (bullets.Count < maxBullets)
        {
            GameObject newBullet = Instantiate(BulletPrefab, pos, rot);
            bullets.Add(newBullet);
            return newBullet;
        }

        // áA îÒÉAÉNÉeÉBÉuíeÇíTÇ∑
        foreach (GameObject b in bullets)
        {
            if (!b.activeInHierarchy)
            {
                b.transform.position = pos;
                b.transform.rotation = rot;
                b.SetActive(true);
                return b;
            }
        }

        // áB ëSïîégópíÜÇ»ÇÁàÍî‘å√Ç¢íeÇã≠êßçƒóòóp
        GameObject reuseBullet = bullets[currentIndex];
        currentIndex = (currentIndex + 1) % maxBullets;

        reuseBullet.transform.position = pos;
        reuseBullet.transform.rotation = rot;
        reuseBullet.SetActive(true);

        return reuseBullet;
    }
}
