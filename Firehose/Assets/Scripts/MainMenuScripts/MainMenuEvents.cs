using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument _document;

    private Button _button;

    private bool keyPressed = false;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();

        _button = _document.rootVisualElement.Q("PressAnyButton") as Button;
        _firstMenuScreen = _document.rootVisualElement.Q("")
        _button.RegisterCallback<KeyDownEvent>(OnPressAnywhereButton);
    }

    private void OnPressAnywhereButton(KeyDownEvent evt)
    {
        //Debug.Log("Voc� pressionou o bot�o!");
    }

    private void OnStartGameButton(ClickEvent evt)
    {
        Debug.Log("Voc� clicou o bot�o de Come�ar o Jogo");
    }

    private void Update()
    {
        if(Input.anyKeyDown && !keyPressed)
        {
            keyPressed = true;
            Debug.Log("Tecla pressionada");
        }
        else
        {

        }
    }
}
