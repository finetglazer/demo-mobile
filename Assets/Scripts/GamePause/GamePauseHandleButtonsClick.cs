using TMPro;
using UnityEngine;

public class GamePauseHandleButtonsClick : MonoBehaviour
{
    public TextMeshProUGUI textContinue;
    public TextMeshProUGUI textMainMenu;
    public TextMeshProUGUI textSetting;
    private int _currentRowIndex = 0;
    private readonly TextMeshProUGUI[] _uiGamePauseItems = new TextMeshProUGUI[3];
    void Awake()
    {
        _uiGamePauseItems[0] = textContinue;
        _uiGamePauseItems[1] = textMainMenu;
        _uiGamePauseItems[2] = textSetting;
    }
    void Update()
    {
        TurnOffEffectsOnAllRows();
        TurnOnEffectsOnCurrentRow();

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            _currentRowIndex = (_currentRowIndex + 1) % _uiGamePauseItems.Length;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            _currentRowIndex = (_currentRowIndex - 1 + _uiGamePauseItems.Length) % _uiGamePauseItems.Length;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (_currentRowIndex)
            {
                case 0:
                    OnContinueButtonClick();
                    break;
                case 1:
                    OnMainMenuButtonClick();
                    break;
                case 2:
                    OnSettingButtonClick();
                    break;
            }
        }
    }
    private void TurnOffEffectsOnAllRows()
    {
        foreach (var item in _uiGamePauseItems)
        {
            item.color = Color.white;
        }
    }
    private void TurnOnEffectsOnCurrentRow()
    {
        _uiGamePauseItems[_currentRowIndex].color = Color.yellow;
    }
    public void OnContinueButtonClick()
    {
        _currentRowIndex = 0;
    }
    public void OnMainMenuButtonClick()
    {
        _currentRowIndex = 1;
    }
    public void OnSettingButtonClick()
    {
        _currentRowIndex = 2;
    }
}