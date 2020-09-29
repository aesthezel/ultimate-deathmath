using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MathInputs : MonoBehaviour
{

    public TMP_InputField inputNumber;
    public TextMeshProUGUI resultScreen;

    public Button sumButton;
    public Button minusButton;
    public Button multiplyButton;
    public Button divideButton;
    public Button equalButton;

    int firstNumberContainer;
    int secondNumberContainer;
    char symbolContainer;

    bool finished;

    
    void Start()
    {
        DisableMathButtons(true);
        equalButton.interactable = false;
    }

    void DisableMathButtons(bool status)
    {

        if (status)
        {
            sumButton.interactable = false;
            minusButton.interactable = false;
            multiplyButton.interactable = false;
            divideButton.interactable = false;
            //equalButton.interactable = false;
        } 
        else
        {
            sumButton.interactable = true;
            minusButton.interactable = true;
            multiplyButton.interactable = true;
            divideButton.interactable = true;
            //equalButton.interactable = true;
        }    

    }

    public void OnTextEntry(TMP_InputField input)
    {
        if (!finished)
        {
            if(firstNumberContainer == 0)
            {
                if(input.text.Length == 0)
                {
                    DisableMathButtons(true);
                } 
                else
                {
                    DisableMathButtons(false);
                }
            }

        }
        else
        {
            DisableMathButtons(true);
            equalButton.interactable = false;
        }

    }


    public void OnPressSymbols(string symbol)
    {

        if(symbol != "=")
        {
            char symbolChar = Convert.ToChar(symbol);
            ContainText(inputNumber.text, symbolChar);
            equalButton.interactable = true;
        }
        else
        {
            secondNumberContainer = inputNumber.text == "" ? 0 : Convert.ToInt32(inputNumber.text);
            EditResult();
            resultScreen.text = Convert.ToString(MathOperation(firstNumberContainer, secondNumberContainer, symbolContainer));
            equalButton.interactable = false;
            inputNumber.interactable = false;

        }
    }

    public void ContainText(string textNumber, char symbol)
    {
        firstNumberContainer = Convert.ToInt32(textNumber);
        symbolContainer = symbol;
        DisableMathButtons(true);
        EditResult();

    }

    void EditResult()
    {

        switch (secondNumberContainer)
        {
            case 0:
            resultScreen.text = Convert.ToString(firstNumberContainer + " " + symbolContainer);
            inputNumber.text = "";
            break;
            default:
            resultScreen.text = Convert.ToString(firstNumberContainer + " " + symbolContainer + " " + secondNumberContainer);
            inputNumber.text = "";
            break;
        }
    }

    // Funcion final
    int MathOperation(int firstNumber, int secondNumber, char symbol)
    {
        int result;

        switch (symbol)
        {
            case '+':
                result = firstNumber + secondNumber;
                break;
            case '-':
                result = firstNumber - secondNumber;
                break;
            case '*':
                result = firstNumber * secondNumber;
                break;
            case '/':
                result = firstNumber / secondNumber;
                break;
            default:
                result = 0;
                break;
        }

        finished = true;

        return result;
    }
}
