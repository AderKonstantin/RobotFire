using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotStateManager : MonoBehaviour
{
    RobotBaseState currentState;
    HibernationState hibernationState = new HibernationState();
    ActiveState activeState = new ActiveState();
    InactiveState inactiveState = new InactiveState();
    DisabledState disabledState = new DisabledState();

    // Start is called before the first frame update
    void Start()
    {
        // Starting State
        currentState = hibernationState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
