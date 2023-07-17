using UnityEngine;

public class HibernationState : RobotBaseState
{
    public override void EnterState(RobotStateManager robot)
    {
        Debug.Log("Robot is on Hibernation");
    }
    public override void UpdateState(RobotStateManager robot)
    {
    }
    public override void OnCollisionEnter(RobotStateManager robot)
    {
    }
}
