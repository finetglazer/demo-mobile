using TMPro;
using UnityEngine;

public class HandleEditInputField : MonoBehaviour
{
    public TMP_InputField inputField;
    private int _power;
    public void OnEditFinished()
    {
        try 
        {
            _power = int.Parse(inputField.text);
        }
        catch (System.Exception exception)
        {
            print(exception);
        }
        _power = Mathf.Min(_power, 10);
        _power = Mathf.Max(_power, 0);
        inputField.text = _power.ToString();
    }
}