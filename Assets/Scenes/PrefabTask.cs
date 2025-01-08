using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTask : MonoBehaviour
{
    [SerializeField] private GameObject _myPrefab;
    private Vector3 _mousePos;
    private int i;

void Update()
    {
        // Detect left mouse button click and return the click location
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button clicked!");
            _mousePos = Input.mousePosition;
            Debug.Log("mouse position (x,y) is:" + _mousePos.x + "," + _mousePos.y);
            i++;
        }
        while(i<9)
        {
            Instantiate(_myPrefab, new Vector3(_mousePos.x, _mousePos.y, 0), Quaternion.identity);
        }
    }
}
