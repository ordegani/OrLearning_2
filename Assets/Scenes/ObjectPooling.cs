using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private List<GameObject> bulletPool = new List<GameObject>();
    private int poolSize = 10;
    Vector3 position;

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    public GameObject GetBullet()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (!bullet.activeInHierarchy) // Find an inactive bullet
            {
                bullet.transform.position = position;
                bullet.SetActive(true);
                return bullet;
            }
        }

        // No inactive bullets available, create a new one (optional)
        GameObject newBullet = Instantiate(bulletPrefab, position, Quaternion.identity);
        bulletPool.Add(newBullet);
        return newBullet;
    }
}
