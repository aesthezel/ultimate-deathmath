using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MathInputs : MonoBehaviour
{

    // Texto
    public TMP_InputField inputNumber;
    public TextMeshProUGUI resultScreen;

    // Botones
    public Button sumButton;
    public Button minusButton;
    public Button multiplyButton;
    public Button divideButton;
    public Button equalButton;

    // Contenedores
    int firstNumberContainer;
    int secondNumberContainer;
    char symbolContainer;

    // Modificadores de la partida
    int turn;
    bool finished;

    #region Funciones por defecto
    void Start()
    {
        DisableMathButtons(true);
        equalButton.interactable = false;
    }

    void Update()
    {
        if (finished)
        {
            return;
        } 
        else 
        {
            EditResult();
        }

        // resultScreen.text = inputNumber.text;
    }
    #endregion

    #region Interacciones con la interfaz
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

        if (symbol != "@")
        {
            if(symbol != "=")
            {
                char symbolChar = Convert.ToChar(symbol);
                ContainText(inputNumber.text, symbolChar);
                equalButton.interactable = true;
                turn = 1;
                inputNumber.text = "";
                //inputNumber.text = "";
            }
            else
            {
                secondNumberContainer = inputNumber.text == "" ? 0 : Convert.ToInt32(inputNumber.text);
                inputNumber.text = "";
                turn = 2;
                //EditResult();
                //resultScreen.text = Convert.ToString(MathOperation(firstNumberContainer, secondNumberContainer, symbolContainer));
                equalButton.interactable = false;
                inputNumber.interactable = false;

            }         
        } 
        else 
        {
            ResetCalc();
        }

    }
    #endregion

    #region Modificadores de entrada y calculadora
    public void ContainText(string textNumber, char symbol)
    {
        firstNumberContainer = Convert.ToInt32(textNumber);
        symbolContainer = symbol;
        DisableMathButtons(true);
        //EditResult();

    }

    void EditResult()
    {
        // switch (secondNumberContainer)
        // {
        //     case 0:
        //     resultScreen.text = Convert.ToString(firstNumberContainer + " " + symbolContainer);
        //     inputNumber.text = "";
        //     break;
        //     default:
        //     resultScreen.text = Convert.ToString(firstNumberContainer + " " + symbolContainer + " " + secondNumberContainer);
        //     inputNumber.text = "";
        //     break;
        // }

        CombatManager combat = GameObject.FindWithTag("GameController").GetComponent<CombatManager>();
        int result = 0;

        switch (turn)
        {
            case 0:
                resultScreen.text = inputNumber.text;
            break;
            case 1:
                resultScreen.text = Convert.ToString(firstNumberContainer + " " + symbolContainer + " " + inputNumber.text);
            break;
            default:
                MathFormulas mathF = new MathFormulas();

                result = mathF.TwoNumbersBasicOperations(firstNumberContainer, secondNumberContainer, symbolContainer);
                combat.Fighting(combat.entityTurn, 1, result, "Hited");
                resultScreen.text = Convert.ToString(result);

                finished = true;
            break;
        }
    }

    void ResetCalc()
    {
        turn = 0;
        inputNumber.text = "";
        firstNumberContainer = 0;
        secondNumberContainer = 0;
        symbolContainer = '_';
        inputNumber.interactable = true;
        finished = false;
    }
    #endregion
}
