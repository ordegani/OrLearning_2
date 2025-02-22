using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    //[SerializeField] private Material _someMaterial;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private List<GameObject> _bulletPool = new List<GameObject>();
    private int _poolSize = 10;
    Vector3 position;
    GameObject bullet;

    private void Start()
    {
        //create pool
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            bullet.SetActive(false);
            _bulletPool.Add(bullet);
        }


        foreach (GameObject bullet in _bulletPool)
        {
            MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
            propertyBlock.SetColor("_Color", Random.ColorHSV());
            bullet.GetComponent<MeshRenderer>().SetPropertyBlock(propertyBlock);
        }
    }

    //function to use to instantiate new visible bullet in the game view
    private void HandleMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        //Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        if (Physics.Raycast(ray, out hit))
        {
            foreach (GameObject bullet in _bulletPool)
            {
                //FIX
                bullet.transform.position=hit.point;
            }
        }
    }



    //use bullet from pool - CHANGE

    // No inactive bullets available, create a new one (optional) - OK
    //if (Input.GetMouseButtonDown(0) && bullet.activeInHierarchy)
    //{
    //    GameObject newBullet = Instantiate(_bulletPrefab, position, Quaternion.identity);
    //    _bulletPool.Add(newBullet);
    //}
}
