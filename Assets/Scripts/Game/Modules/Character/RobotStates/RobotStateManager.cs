using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotStateManager : MonoBehaviour
{
    public RobotBaseState currentState;
    public HibernationState hibernationState = new HibernationState();
    public ActiveState activeState = new ActiveState();
    public InactiveState inactiveState = new InactiveState();
    public DisabledState disabledState = new DisabledState();

    // Start is called before the first frame update
    void Start()
    {
        // Starting State for the Robot State Manager
        currentState = hibernationState;
        // "this" is the reference to the context (this EXACT Monobehaviour Script)
        currentState.EnterState(this); // Maybe bullshit for future? when it add the netcode.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchState(RobotBaseState state)
    {

    }
}
