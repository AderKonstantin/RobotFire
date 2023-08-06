using UnityEngine;

public class Medic : RobotClass
{

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        robotStateManager = GetComponent<RobotStateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(robotStateManager.currentState);
    }
}
