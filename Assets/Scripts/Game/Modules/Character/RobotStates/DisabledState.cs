using UnityEngine;

public class DisabledState : RobotBaseState
{
    public override void EnterState(RobotStateManager robot)
    {
        Debug.Log("Robot is Disabled");
    }
    public override void UpdateState(RobotStateManager robot)
    {
    }
    public override void OnCollisionEnter(RobotStateManager robot)
    {
    }
}
