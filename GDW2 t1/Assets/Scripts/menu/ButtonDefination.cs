using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonDefination : MonoBehaviour
{
    public Color _unselectedTint = Color.grey;
    public Color _selectedTint = Color.white;
    public bool _selected = false;
    private Button _button;
    private Image _image;

    private bool _disabledControls = false;

    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();

        if (_selected)
        {
            _image.color = _selectedTint;
        }
        else
        {
            _image.color = _unselectedTint;
        }
    }

    public void SwappedTo()
    {
        _selected = true;

        _image.color = _selectedTint;
    }
    public void Swappedoff()
    {
        _selected = false;

        _image.color = _unselectedTint;
    }
    public void ClickButton()
    {
        if (!_disabledControls)
        {
            _disabledControls = true;

            _button.onClick.Invoke();

            _disabledControls = false;
        }
    }

    public bool GetdisabledControls()
    {
        return _disabledControls;
    }
}
