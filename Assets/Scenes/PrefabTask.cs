using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabTask : MonoBehaviour
{
    [SerializeField] private GameObject _myPrefab;
    [SerializeField] private Canvas _canvas;
    private Vector3 _mousePos;
    private int _myPrefabCount = 0;

    void Update()
    {
        HandlMouseClick();
    }

    void HandlMouseClick()
    {
        // Detect left mouse button click and return the click location
        if (Input.GetMouseButtonDown(0) && _myPrefabCount <= 9)
        {
            _mousePos = Input.mousePosition;
            Debug.Log("mouse position (x,y) is:" + _mousePos.x + "," + _mousePos.y);
            //Instantiate _myPrefab and make it's position _mousePos
            Instantiate(_myPrefab, _mousePos, Quaternion.identity, _canvas.transform);
            //add to count to hadle 10 prefabs  instantiate limit in this task
            _myPrefabCount++;
            //Debug.Log(_myPrefab.transform.position);
        }
    }
}
