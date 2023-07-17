using UnityEngine;

public class ActiveState : RobotBaseState
{
    public override void EnterState(RobotStateManager robot)
    {
        Debug.Log("Robot is Active");
    }
    public override void UpdateState(RobotStateManager robot)
    {
    }
    public override void OnCollisionEnter(RobotStateManager robot)
    {
    }
}
