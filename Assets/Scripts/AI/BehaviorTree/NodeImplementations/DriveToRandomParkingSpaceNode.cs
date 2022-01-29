using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveToRandomParkingSpaceNode : ActionNode
{
    Vector3 positionToGoTo = new Vector3(0, 0, 0);
    public override void OnEntered()
    {
        positionToGoTo = AITargetLocations.GetRandomLocation("CarDestination");
        UnityEngine.AI.NavMeshPath path = new UnityEngine.AI.NavMeshPath();
        parent.GetComponent<UnityEngine.AI.NavMeshAgent>().CalculatePath(positionToGoTo, path);
        parent.GetComponent<UnityEngine.AI.NavMeshAgent>().SetPath(path);
    }

    public override void OnExit()
    {
        positionToGoTo = new Vector3(0, 0, 0);
    }

    public override NodeStates OnUpdate()
    {
        float distance = Vector3.Distance(parent.transform.position, positionToGoTo);
        Debug.Log($"Distance to Goal {distance}");
        if (distance > 0.6f)
        {
            return NodeStates.Running;
        }
        else
        {
            //parent.GetComponent<NavMeshAgent>().ResetPath();
            return NodeStates.Succeeded;
        }
    }
}
