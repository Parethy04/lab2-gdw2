using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MenuType
{
    HORIZONTAL,
    VERTICAL
}


public class MenuDefinations : MonoBehaviour
{
    public MenuType _menutype = MenuType.HORIZONTAL;
    public List<GameObject> _menuButtonObjects = new List<GameObject>();

    private List<ButtonDefination> _menuButtonDefinations = new List<ButtonDefination>();
    private List<Button> _menuButtons = new List<Button>();

    public void Start()
    {
        for (int i = 0; i < _menuButtonObjects.Count; i++)
        {
            _menuButtonDefinations.Add(_menuButtonObjects[i].GetComponent<ButtonDefination>());
            _menuButtons.Add(_menuButtonObjects[i].GetComponent<Button>());
        }
    }

    public MenuType GetMenuType()
    {
        return _menutype;
    }

    public int GetbuttonCount()
    {
        return _menuButtonObjects.Count;
    }

    public List<ButtonDefination> GetButtonDefinations()
    {
        return _menuButtonDefinations;
    }

    public List<Button> GetButtons()
    {
        return _menuButtons;
    }
}
