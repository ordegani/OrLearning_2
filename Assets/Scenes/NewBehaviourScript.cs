
using System.Collections.Generic; // todo: you don't need them yet maybe
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour //3D
{
    [SerializeField] private GameObject _myPrefab;
    [SerializeField] private Camera _mainCamera;
    private int _myPrefabCount = 0;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            handleMouseClick2();
        }
    }

    //One solution (less priffered in this specific assigment, but good for spawning an obj in front of an existing obj)>>
    private void HandlMouseClick()
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (_myPrefabCount <= 9 && Physics.Raycast(ray, out hit))
        {
            Instantiate(_myPrefab, hit.point, Quaternion.identity);
            Debug.Log(hit.collider.name);
            Debug.Log(hit.point);
            _myPrefabCount++;
        }
    }

    //Second solution>>
    private void handleMouseClick2()
    {
        Vector3 touchPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Instantiate(_myPrefab, touchPos, Quaternion.identity);
        Debug.Log(touchPos);

    }
}
