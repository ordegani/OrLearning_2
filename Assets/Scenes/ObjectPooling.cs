using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    //[SerializeField] private Material _someMaterial;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private List<GameObject> _bulletPool = new List<GameObject>();
    private int _poolSize = 10;
    Vector3 position;

    private void Start()
    {
        //create pool
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab);
            bullet.SetActive(false);
            _bulletPool.Add(bullet);
        }
    }

    private void Update()
    {
        GetBullet();
    }
    //function to use to instantiate new visible bullet in the game view
    private void HandleMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        if (Physics.Raycast(ray, out hit))
        {
            GameObject newPrefab = Instantiate(_bulletPrefab, hit.point, Quaternion.identity);
        }
    }

    //use bullet from pool
    private GameObject GetBullet()
    {
        foreach (GameObject bullet in _bulletPool)
        {
            if (!bullet.activeInHierarchy) // Find an inactive bullet
            {
                HandleMouseClick();
                bullet.SetActive(true);
                return bullet;
            }
        }

        // No inactive bullets available, create a new one (optional)
        GameObject newBullet = Instantiate(_bulletPrefab, position, Quaternion.identity);
        _bulletPool.Add(newBullet);
        return newBullet;
    }
}
