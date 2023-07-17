using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Terminal : MonoBehaviour
{
    UIDocument terminalUI;
    Button BtnChangeRobotClass;
    Button BtnConnectToFirst;
    Button BtnConnectToBase;
    Button BtnConnectToLatest;

    PlayerController playerController;

    // Start is called before the first frame update
    void Awake()
    {
        terminalUI = GetComponent<UIDocument>();
        playerController = GetComponentInParent<PlayerController>();


        BtnChangeRobotClass = terminalUI.rootVisualElement.Q<Button>("ChangeRobotClass");
        BtnConnectToFirst = terminalUI.rootVisualElement.Q<Button>("ConnectToFirst");
        BtnConnectToBase = terminalUI.rootVisualElement.Q<Button>("ConnectToBase");
        BtnConnectToLatest = terminalUI.rootVisualElement.Q<Button>("ConnectToLatest");

        BtnChangeRobotClass.clicked += BtnChangeRobotClassOnClick; // () => { Do Something(); };
        BtnConnectToFirst.clicked += BtnConnectToFirstOnClick;
        BtnConnectToBase.clicked += BtnConnectToBaseOnClick;
        BtnConnectToLatest.clicked += BtnConnectToLatestOnClick;
    }

    private void BtnChangeRobotClassOnClick()
    {
        playerController.ChangeRobotClass();
        playerController.TerminalDebugOutput("Gameplay: Changing Robot Class ...");

    }
    private void BtnConnectToFirstOnClick()
    {
        playerController.TerminalDebugOutput("Gameplay: Is connecting to first available Robot");
        playerController.terminalSetDeactive();
    }
    private void BtnConnectToBaseOnClick()
    {
        playerController.TerminalDebugOutput("Gameplay: Is connecting to available Robot on base");
        playerController.terminalSetDeactive();
    }
    private void BtnConnectToLatestOnClick()
    {
        playerController.TerminalDebugOutput("Gameplay: Is connecting to latest available Robot");
        playerController.terminalSetDeactive();
    }
}
