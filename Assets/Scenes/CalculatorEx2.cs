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
        _calculateButton.onClick.AddListener(HandleCalculateButtonClick);//keep in the UI components use of - on Enable/Disable                                                                         //less good: in case of use inside Start() - use AddListener but dont forget onClick.RemoveAllListeners()
    }

    private void OnDisable()
    {
        _calculateButtondisabler.onClick.RemoveListener(HandleCalculateButtonClick);
    }

    private void HandleCalculateButtonClick()//I renamed to HandleCalculateButtonClick().n event-driven frameworks, it's common to name event handlers with a verb and context (e.g., OnButtonClick, HandleEvent). "handle" is a convention for event being handled, "calculateButton" is the ui object that is pressed by the user. "click" is the user's action that triggers the event-the most important part.Explains it handles a button click.
    {
        float firstNumber = float.Parse(_firstInputField.text);//changed: no underscores inside the scope of the method. Only "PascalCasing".
        float secondNumber = float.Parse(_secondInputField.text);//changed: no underscores inside the scope of the method. Only "PascalCasing".
        int operatorsDropdownIndex = _operatorsDropdown.value;//changed: no underscores inside the scope of the method.Only "PascalCasing".
        string selectedOption = _operatorsDropdown.options[operatorsDropdownIndex].text;//changed: no underscores inside the scope of the method. Only "PascalCasing".
        bool isZero = false;

        switch (selectedOption)
        {
            case "+":
                _result = firstNumber + secondNumber;

                break;
            case "-":
                _result = firstNumber - secondNumber;

                break;
            case "/":
                isZero = IsSecondNumberZero(secondNumber);
                _result = firstNumber / secondNumber;

                break;
            case "*":
                _result = firstNumber * secondNumber;

                break;
        }

        if (isZero)
        {
            _resultField.text = "Error:division by zero is impossible!";
        }
        else
        {
            _resultField.text = $"Result: {_result}";
        }
    }
    bool IsSecondNumberZero(float num2)
    {
        return (num2 == 0);
    }
}
