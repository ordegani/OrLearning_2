using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalculatorWithEvent : MonoBehaviour
{
    [SerializeField] private TMP_InputField _firstInputField;//I renamed to _firstInputField
    [SerializeField] private TMP_InputField _secondInputField;//I renamed to _secondInputField
    [SerializeField] private TextMeshProUGUI _resultField;
    [SerializeField] private Button _calculateButton;
    [SerializeField] private Button _calculateButtondisabler;
    [SerializeField] private TMP_Dropdown _operatorsDropdown;
    private float _result;//I changed to private


    private void OnEnable()//I changed to private
    {
        // todo: you have a subscription for the _calculateButton but not for the _calculateButtondisabler
        // todo: and make sure you use the correct method. when you unsubscribe and subscribe
        _calculateButton.onClick.AddListener(HandleCalculateButtonClick);//keep in the UI components use of - on Enable/Disable
                                                                         //less good: in case of use inside Start() - use AddListener but dont forget onClick.RemoveAllListeners()
                                                                         
    }

    private void OnDisable()
    {
        // todo: also, you don't have RemoveListener for the _calculateButton
        _calculateButtondisabler.onClick.RemoveListener(HandleCalculateButtonClick);
    }

    private void HandleCalculateButtonClick()//I renamed to HandleCalculateButtonClick().n event-driven frameworks, it's common to name event handlers with a verb and context (e.g., OnButtonClick, HandleEvent). "handle" is a convention for event being handled, "calculateButton" is the ui object that is pressed by the user. "click" is the user's action that triggers the event-the most important part.Explains it handles a button click.
    {
        float firstNumber = float.Parse(_firstInputField.text);//changed: no underscores inside the scope of the method. Only "PascalCasing".
        float secondNumber = float.Parse(_secondInputField.text);//changed: no underscores inside the scope of the method. Only "PascalCasing".
        int operatorsDropdownIndex = _operatorsDropdown.value;//changed: no underscores inside the scope of the method.Only "PascalCasing".
        string selectedOption = _operatorsDropdown.options[operatorsDropdownIndex].text;//changed: no underscores inside the scope of the method. Only "PascalCasing".
<<<<<<< HEAD
        bool isZero = false;

=======
        bool isZero = false; 
        
        bool CheckIfSecondNumberIsZero(float num2) // todo: move it to the separate method. Rename the method 
        {
            // todo: optimize it to a short version
            if (num2 == 0)
            {
                return true;
            }
            return false;
        }
        
>>>>>>> 7c2b2782e9ecd9362f74e0064d9ffa0d7bb1c580
        switch (selectedOption)
        {
            case "+":
                _result = firstNumber + secondNumber;

                break;
            case "-":
                _result = firstNumber - secondNumber;

                break;
            case "/":
<<<<<<< HEAD
                isZero = IsSecondNumberZero(secondNumber);
                _result = firstNumber / secondNumber;

=======
                isZero = CheckIfSecondNumberIsZero(secondNumber);  
                _result = firstNumber / secondNumber; // todo: add check if zero - we shouldn't calculate
>>>>>>> 7c2b2782e9ecd9362f74e0064d9ffa0d7bb1c580
                break;
            case "*":
                _result = firstNumber * secondNumber;
                break;
        }

        // todo: optimize it to a short version
        if (isZero) // todo: or we can move it to the Switch and call return if the second value is zero
        {
            _resultField.text = "Error:division by zero is impossible!";
        }
        else
        {
            _resultField.text = $"Result: {_result}";
        }
    }
<<<<<<< HEAD
    bool IsSecondNumberZero(float num2)
    {
        return (num2 == 0);
    }
=======
    
    // todo: after you do everything check if you still need "isZero" variable.
>>>>>>> 7c2b2782e9ecd9362f74e0064d9ffa0d7bb1c580
}
