using UnityEngine;

public class InactiveState : RobotBaseState
{
    public override void EnterState(RobotStateManager robot)
    {
        Debug.Log("Robot is Inactive");
    }
    public override void UpdateState(RobotStateManager robot)
    {
    }
    public override void OnCollisionEnter(RobotStateManager robot)
    {
    }
}
