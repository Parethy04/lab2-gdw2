using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MenuController : MonoBehaviour
{
    public GameObject _activeMenu;
    public List<KeyCode> _increaseVert;
    public List<KeyCode> _decreaseVert;
    public List<KeyCode> _increaseHoriz;
    public List<KeyCode> _decreaseHoriz;
    public List<KeyCode> _confirmButtons;

    private MenuDefinations _activeMenuDefination;
    private int _activeButton = 0;

    public void Start()
    {
        //update active menu defination at start
        UpdateActiveMenuDefination();
    }

    public void Update()
    {
        switch (_activeMenuDefination.GetMenuType())
        {
            case MenuType.HORIZONTAL:
                MenuInput(_increaseHoriz, _decreaseHoriz);
                break;
            case MenuType.VERTICAL:
                MenuInput(_increaseVert, _decreaseVert);
                break;
        }
    }

    private void MenuInput(List<KeyCode> increase, List<KeyCode> decrease)
    {
        int newActive = _activeButton;

        for (int i = 0; i < increase.Count; i++)
        {
            if (Input.GetKeyDown(increase[i]))
            {
                newActive = SwitchCurrentButton(1);
            }
        }

        for (int i = 0; i < decrease.Count; i++)
        {
            if (Input.GetKeyDown(decrease[i]))
            {
                newActive = SwitchCurrentButton(-1);
            }
        }

        for(int i = 0; i < _confirmButtons.Count; i++)
        {
            if (Input.GetKeyDown(_confirmButtons[i]))
            {
                ClickCurrentButton();
            }
        }

        _activeButton = newActive;
    }

    private int SwitchCurrentButton(int increment)
    {
        if (!_activeMenuDefination.GetButtonDefinations()[_activeButton].GetdisabledControls())
        {
            int newActive = Utility.WrapAround(_activeMenuDefination.GetbuttonCount(), _activeButton, increment);
            Debug.Log(newActive + " " + _activeButton + " " + increment);

            _activeMenuDefination.GetButtonDefinations()[_activeButton].Swappedoff();
            _activeMenuDefination.GetButtonDefinations()[newActive].SwappedTo();

            return newActive;
        }
        return _activeButton;
    }

    private void ClickCurrentButton()
    {
        if (!_activeMenuDefination.GetButtonDefinations()[_activeButton].GetdisabledControls())
        {
            _activeMenuDefination.GetButtonDefinations()[_activeButton].ClickButton();
        }
    }

    public void UpdateActiveMenuDefination()
    {
        _activeMenuDefination = _activeMenu.GetComponent<MenuDefinations>();
    }

    public void SetActiveMenu (GameObject activeMenu)
    {
        //set active menu
        _activeMenu = activeMenu;

        //make sure to update definations
        UpdateActiveMenuDefination();
    }
}
