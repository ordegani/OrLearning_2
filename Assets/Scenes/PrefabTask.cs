using System.Collections; // todo: you don't need them
using System.Collections.Generic; // todo: you don't need them yet maybe
using UnityEngine;

public class PrefabTask : MonoBehaviour
{
    [SerializeField] private GameObject _myPrefab;
    private Vector3 _mousePos;

    // there is no difference between 'i' and '_mousePos' in terms of the naming.
    // so the name should be '_i'.
    // please keep in mind that we use naming without underscore and lowercase 
    // only if the variable is local (which means it's inside of the method)
    // also, please use different name of the variable. It is hard to understand what is 'i' 
    // you can use '_index'
    private int i = 0; 

    void Update() // todo: in the previous script "CalculatorEx2.cs" you've changed this to 'private', please use this rule here too.
    {
        HandlMouseClick(); // todo: rename. Have typo error ('Handle' instead of 'Handl')
        
        // in my case I usually write the following way, but it's up to you:

        // if (Input.GetMouseButtonDown(0))
        // {
        //     HandlMouseClick();
        // }
        
        // inside of the 'HandlMouseClick();'
        // we can write the checking of the index (which is now - i) and all next calculation/adjustments
        
        // the thing is when you work with buttons you making something the same (_button.onClick.AddListener(HandleButtonClick);) 
        // when you do 'if (Input.GetMouseButtonDown(0))' inside of the Update() method which basically by an idea working the same way.
    }

    void HandlMouseClick()
    {
        // Detect left mouse button click and return the click location
        if (Input.GetMouseButtonDown(0) && i <= 9)
        {
            _mousePos = Input.mousePosition;
            Debug.Log("mouse position (x,y) is:" + _mousePos.x + "," + _mousePos.y);
            //Instantiate _myPrefab and make it's position _mousePos
            
            // todo: instantiate is returning the generic type (<T>) which can be whatever is needed for us
            // todo: for now we need to get spawned object and make it part of the canvas
            // also, if it will be hard, than you check this documentation (second and third examples)
            // https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Object.Instantiate.html
            // if you still don't know how to do it, please read the next link:
            // https://discussions.unity.com/t/how-to-parent-spawned-object-from-array-solved/826062/3
            Instantiate(_myPrefab, _mousePos, Quaternion.identity); 
            
            //add to count to hadle 10 prefabs  instantiate limit in this task
            i++;
            //Debug.Log(_myPrefab.transform.position);
        }
    }
    
    
    // you can delete this script from the prefab. (you have it inside of the canvas)
}
