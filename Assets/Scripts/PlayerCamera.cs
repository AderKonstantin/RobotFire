using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{

    // Here is the whole logic of character control: input, camera rotation.

    internal static CharacterInput characterInput;

    [SerializeField] private Transform _orientation;

    private float xRotation;
    private float yRotation;

    [SerializeField] internal float cameraSensitivityX = 3.0f;
    [SerializeField] internal float cameraSensitivityY = 3.0f;


    // Start is called before the first frame update
    void Start()
    {
        characterInput = new CharacterInput();
        characterInput.Robot.Enable();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Look();
    }
    private void Look()
    {
        Vector2 inputVector = characterInput.Robot.Look.ReadValue<Vector2>();

        float camDeltaX = inputVector.x * cameraSensitivityX * Time.deltaTime;
        float camDeltaY = inputVector.y * cameraSensitivityY * Time.deltaTime;

        yRotation += camDeltaX;
        xRotation -= camDeltaY;
        xRotation = Mathf.Clamp(xRotation, -89f, 89f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        _orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
