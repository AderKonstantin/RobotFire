using UnityEngine;

public abstract class RobotBaseState
{
    public abstract void EnterState(RobotStateManager robot);
    public abstract void UpdateState(RobotStateManager robot);
    public abstract void OnCollisionEnter(RobotStateManager robot);
}
