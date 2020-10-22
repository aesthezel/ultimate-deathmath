using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathFormulas
{
    public int TwoNumbersBasicOperations(int firstNumber, int secondNumber, char symbol)
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

        return result;
    }
}
