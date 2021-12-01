using TMPro;
using UnityEngine;

public class CodeLockManager : MonoBehaviour
{
    public int rightCode;
    public int enteredCode;

    [SerializeField] private int firstNumber;
    [SerializeField] private int secondNumber;
    [SerializeField] private int thirdNumber;

    public bool isOpened;

    [SerializeField] private TMP_Text firstNumberText;
    [SerializeField] private TMP_Text secondNumberText;
    [SerializeField] private TMP_Text thirdNumberText;

    private void Update()
    {
        enteredCode = (firstNumber * 100) + (secondNumber * 10) + thirdNumber;
        firstNumberText.text = firstNumber.ToString();
        secondNumberText.text = secondNumber.ToString();
        thirdNumberText.text = thirdNumber.ToString();
        if(enteredCode == rightCode)
        {
            gameObject.SetActive(false);
            isOpened = true;
        }
        if(isOpened)
        {
            firstNumber = 0;
            secondNumber = 0;
            thirdNumber = 0;
        }
    }

    public void AddHundreds()
    {
        firstNumber += 1;
        if(firstNumber > 9)
        {
            firstNumber = 0;
        }
    }
    public void AddTens()
    {
        secondNumber += 1;
        if(secondNumber > 9)
        {
            secondNumber = 0;
        }
    }

    public void AddUnits()
    {
        thirdNumber += 1;
        if(thirdNumber > 9)
        {
            thirdNumber = 0;
        }
    }
}
