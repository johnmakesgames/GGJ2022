using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaitAroundNode : ActionNode
{
    Vector3 startPos = new Vector3(0, 0, 0);
    public override void OnEntered()
    {
        startPos = parent.transform.position;
    }

    public override void OnExit()
    {
            
    }   

    public override NodeStates OnUpdate()
    {
        Vector3 positionToGoTo = startPos + new Vector3(Random.Range(0, 10), 0, Random.Range(0, 10));
        NavMeshPath path = new NavMeshPath();
        parent.GetComponent<NavMeshAgent>().CalculatePath(positionToGoTo, path);
        parent.GetComponent<NavMeshAgent>().SetPath(path);

        return NodeStates.Running;
    }
}
