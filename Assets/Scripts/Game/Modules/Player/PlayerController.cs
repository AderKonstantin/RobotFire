using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Here is the whole logic of Player Controller: using Terminal, connecting to Robots

    internal static CharacterInput characterInput;

    internal enum robotClasses { Trooper, Medic, Engineer };
    [SerializeField] robotClasses currentClass;

    GameObject terminal;

    public bool isConnectedToRobot;

    private void Awake()
    {
        characterInput = new CharacterInput();
        characterInput.PlayerTerminal.Enable();
    }
    private void Start()
    {
        /*UI = GameObject.FindWithTag("Terminal");*/
        isConnectedToRobot = false;
        currentClass = robotClasses.Trooper; // Standard Class
        terminal = GameObject.FindWithTag("Terminal");
    }

    public void terminalSetDeactive() => terminal.SetActive(false);

    internal void ConnectToRobot(string output)
    {
        /*if (Robot.currentState == "hibernationState")
        {
            Connecting
        }*/
        Debug.Log(output);
    }
    internal void DisconnectFromRobot()
    {
        Debug.Log("Gameplay: Is dicconnecting from the Robot");
    }
    internal void ChangeRobotClass()
    {
        // Changing Robot Class
        switch(currentClass)
        {
            case robotClasses.Trooper:
                currentClass = robotClasses.Medic;
                break;
            case robotClasses.Medic:
                currentClass = robotClasses.Engineer;
                break;
            case robotClasses.Engineer:
                currentClass = robotClasses.Trooper;
                break;
            default: break;
        }
    }
    internal void TerminalDebugOutput(string output) => Debug.Log(output);

    void ConnectToRobotCam(Camera robotCam)
    {
        // When robot is Loading we change camera to robot's camera.
    }
}
