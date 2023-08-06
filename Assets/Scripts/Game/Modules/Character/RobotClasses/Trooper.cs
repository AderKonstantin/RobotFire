using System.Collections.Generic;
using UnityEngine;

public class Trooper : RobotClass
{


    // Start is called before the first frame update
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        robotStateManager = GetComponent<RobotStateManager>();

        GameManager.robotsAvailable.Add(this);
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log(robotStateManager.currentState);
    }
}
