using System;
using TMPro;
using UnityEngine;

public class JumpAndRunPowerButtons : MonoBehaviour
{
    public TMP_InputField inputField;
    private int _power;
    void Awake()
    {
        inputField.ActivateInputField();
        try 
        {
            _power = int.Parse(inputField.text);
        }
        catch (FormatException exception)
        {
            print(exception.ToString());
        }
    }
    public void OnIncreaseButtonClick()
    {
        _power = Mathf.Clamp(++_power, 0, 10);
        UpdateInputField();
    }
    public void OnDecreaseButtonClick()
    {
        _power = Mathf.Clamp(--_power, 0, 10);
        UpdateInputField();
    }
    private void UpdateInputField()
    {
        inputField.text = _power.ToString();
    }
}