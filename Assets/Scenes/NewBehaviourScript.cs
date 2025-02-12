
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour //3D
{
    [SerializeField] private GameObject _myPrefab;
    private int _myPrefabCount = 0;
    private int _maxPrefabs = 8;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
    }

    //One solution(Good for spawning an obj in front of an existing obj) Good for managing user's inputs>>
    private void HandleMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (_myPrefabCount <= _maxPrefabs && Physics.Raycast(ray, out hit))
        {
            Instantiate(_myPrefab,hit.point , Quaternion.identity);
            Debug.Log(hit.collider.name);
            Debug.Log(hit.point);
            _myPrefabCount++;
        }
    }

    //Second solution(Good for spawning an obj in general) Good for creating the gam's background>>
    private void HandleMouseClick2()
    {
        if (_myPrefabCount < _maxPrefabs)
        {
            //Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 point = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            Instantiate(_myPrefab, point, Quaternion.identity);
            Debug.Log(point);
            _myPrefabCount++;
        }
    }
}
