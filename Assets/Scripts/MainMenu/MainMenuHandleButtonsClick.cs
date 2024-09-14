using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHandleButtonsClick : MonoBehaviour {
    public Image continueIcon;
    public Image newGameIcon;
    public Image settingIcon;
    public Image quitIcon;
    public TextMeshProUGUI continueText;
    public TextMeshProUGUI newGameText;
    public TextMeshProUGUI settingText;
    public TextMeshProUGUI quitText;
    public GameObject mainMenu;
    private readonly Tuple<Image, TextMeshProUGUI>[] _uiMenuItems = new Tuple<Image, TextMeshProUGUI>[4];
    private int _currentRowIndex = 0;
    void Awake()
    {
        _uiMenuItems[0] = Tuple.Create(continueIcon, continueText);
        _uiMenuItems[1] = Tuple.Create(newGameIcon, newGameText);
        _uiMenuItems[2] = Tuple.Create(settingIcon, settingText);
        _uiMenuItems[3] = Tuple.Create(quitIcon, quitText);
        Time.timeScale = 0; 
    }
    void Update()
    {
        TurnOffEffectsOnAllRows();
        TurnOnEffectsOnCurrentRow();

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            _currentRowIndex = (_currentRowIndex + 1) % _uiMenuItems.Length;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            _currentRowIndex = (_currentRowIndex - 1 + _uiMenuItems.Length) % _uiMenuItems.Length;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (_currentRowIndex)
            {
                case 0:
                    OnContinueButtonClick();
                    break;
                case 1:
                    OnNewGameButtonClick();
                    break;
                case 2:
                    OnSettingButtonClick();
                    break;
                case 3:
                    OnQuitButtonClick();
                    break;
            }
        }
    }
    private void TurnOffEffectsOnAllRows()
    {
        foreach (var item in _uiMenuItems)
        {
            item.Item1.enabled = false;
            item.Item2.color = Color.white;
        }
    }
    private void TurnOnEffectsOnCurrentRow()
    {
        _uiMenuItems[_currentRowIndex].Item1.enabled = true;
        _uiMenuItems[_currentRowIndex].Item2.color = Color.yellow;
    }
    public void OnContinueButtonClick()
    {
        _currentRowIndex = 0;
        Time.timeScale = 1;
        mainMenu.SetActive(false);
    }
    public void OnNewGameButtonClick()
    {
        _currentRowIndex = 1;
        Time.timeScale = 1;
        mainMenu.SetActive(false);
    }
    public void OnSettingButtonClick()
    {
        _currentRowIndex = 2;
    }
    public void OnQuitButtonClick()
    {
        _currentRowIndex = 3;
        Application.Quit();
    }
}