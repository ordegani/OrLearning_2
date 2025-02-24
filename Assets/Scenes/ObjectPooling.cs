using System.Collections.Generic;
using UnityEngine;

//Task #8. 11.02.2025 - object pooling && Material block
public class ObjectPooling : MonoBehaviour
{
    //[SerializeField] private Material _material;
    [SerializeField] private GameObject _bulletPrefab;
    private List<GameObject> _bulletPool = new List<GameObject>();
    private int _poolSize = 10;
    Vector3 _position;
    GameObject _bullet;

    private void Start()
    {
        //create pool (no randomizing of colors yet)
        for (int i = 0; i < _poolSize; i++)
        {
            GameObject _bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            _bullet.SetActive(false);
            _bulletPool.Add(_bullet);
        }
}

private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
    }

    //use _bullet from pool (or create more if neede)
    private GameObject HandleMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            foreach (GameObject _bullet in _bulletPool)
            {
                if (!_bullet.activeInHierarchy)
                {
                    _bullet.SetActive(true);
                    _bullet.transform.position = hit.point;
                    MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
                    propertyBlock.SetColor("_Color", Random.ColorHSV());
                    _bullet.GetComponent<MeshRenderer>().SetPropertyBlock(propertyBlock);
                    //Debug.Log(_bullet.GetComponent<Renderer>().material.color);
                    return _bullet;
                }
            }
        }
        // No inactive _bullets available, create a new one (optional)
        GameObject new_bullet = Instantiate(_bulletPrefab, _position, Quaternion.identity);
        _bulletPool.Add(new_bullet);
        return _bullet;
    }
}

