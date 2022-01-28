using UnityEngine;

public class WalkToRandomLocationNode : ActionNode
{
    Vector3 positionToGoTo = new Vector3(0, 0, 0);
    public override void OnEntered()
    {
        positionToGoTo = AITargetLocations.Instance.GetRandomLocation();
    }

    public override void OnExit()
    {
        positionToGoTo = new Vector3(0, 0, 0);
    }

    public override NodeStates OnUpdate()
    {
        if (Vector3.Distance(parent.transform.position, positionToGoTo) > 0.1f)
        {
            parent.transform.position += (positionToGoTo - parent.transform.position).normalized * Time.deltaTime;
            return NodeStates.Running;
        }
        else
        {
            return NodeStates.Succeeded;
        }
    }
}
